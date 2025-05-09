using Huawei.E3372.Manager.Domain.Modem;
using Huawei.E3372.Manager.Domain.Modem.Api.WebServer;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Collections.Frozen;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.ModemClients;

public class E3372hClient(
    IMemoryCache memoryCache,
    ILogger<E3372hClient> logger)
    : IModemClient
{
    internal static readonly IReadOnlyDictionary<Type, XmlSerializer> TypeToXmlSerializer = ModemUriConstants.TypeToRelativeUri
        .ToDictionary(kvp => kvp.Key, kvp => new XmlSerializer(kvp.Key))
        .ToFrozenDictionary();
    internal static readonly XmlSerializer ErrorXmlSerializer = new XmlSerializer(typeof(ErrorResponse));

    public async Task<IModemGetResponse> GetAsync<TModemGetResponse>(
        Uri baseUri,
        CancellationToken cancellationToken = default)
        where TModemGetResponse : IModemGetResponse
    {
        using var httpClientHandler = new HttpClientHandler() { CookieContainer = new CookieContainer() };
        using var httpClient = new HttpClient(httpClientHandler) { BaseAddress = baseUri };

        var sessionId = await GetSessionIdAsync(baseUri, httpClient, cancellationToken);
        httpClientHandler.CookieContainer.Add(baseUri, new Cookie("SessionID", sessionId));

        var relativeUri = ModemUriConstants.TypeToRelativeUri[typeof(TModemGetResponse)];
        var request = new HttpRequestMessage(HttpMethod.Get, relativeUri);

        using var response = await httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);

        using var reader = new StringReader(responseText);
        using var xmlReader = XmlReader.Create(reader);
        var xmlSerializer = TypeToXmlSerializer[typeof(TModemGetResponse)];

        if (xmlSerializer.CanDeserialize(xmlReader))
            return (TModemGetResponse)xmlSerializer.Deserialize(xmlReader)!;

        if (ErrorXmlSerializer.CanDeserialize(xmlReader))
        {
            var error = (ErrorResponse)ErrorXmlSerializer.Deserialize(xmlReader)!;
            logger.LogError("Error response returned by modem. Code: {Code}. Message: {Message}", error.Code, error.Message);
        }
        else
        {
            logger.LogError("Failed to deserialize data from modem. Response: {Response}", responseText);
        }

        throw new HttpRequestException("Failed to deserialize data from modem", null, response.StatusCode);
    }

    public async Task<IModemPostResponse> PostAsync<TModelPostRequest, TModelPostResponse>(
        Uri baseUri,
        TModelPostRequest model,
        CancellationToken cancellationToken = default)
        where TModelPostRequest : IModemPostRequest
        where TModelPostResponse : IModemPostResponse
    {
        using var httpClientHandler = new HttpClientHandler() { CookieContainer = new CookieContainer() };
        using var httpClient = new HttpClient(httpClientHandler) { BaseAddress = baseUri };

        var sessionId = await GetSessionIdAsync(baseUri, httpClient, cancellationToken);
        httpClientHandler.CookieContainer.Add(baseUri, new Cookie("SessionID", sessionId));

        var relativeUri = ModemUriConstants.TypeToRelativeUri[typeof(TModelPostResponse)];
        var request = new HttpRequestMessage(HttpMethod.Post, relativeUri);
        request.Content = new StringContent("");

        using var response = await httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);

        using var reader = new StringReader(responseText);
        using var xmlReader = XmlReader.Create(reader);
        var xmlSerializer = TypeToXmlSerializer[typeof(TModelPostResponse)];

        if (xmlSerializer.CanDeserialize(xmlReader))
            return (TModelPostResponse)xmlSerializer.Deserialize(xmlReader)!;

        if (ErrorXmlSerializer.CanDeserialize(xmlReader))
        {
            var error = (ErrorResponse)ErrorXmlSerializer.Deserialize(xmlReader)!;
            logger.LogError("Error response returned by modem. Code: {Code}. Message: {Message}", error.Code, error.Message);
        }
        else
        {
            logger.LogError("Failed to deserialize data from modem. Response: {Response}", responseText);
        }

        throw new HttpRequestException("Failed to deserialize data from modem", null, response.StatusCode);


    }

    internal async ValueTask<string> GetSessionIdAsync(
        Uri baseUri,
        HttpClient httpClient,
        CancellationToken cancellationToken = default)
    {
        var key = $"SessionID_{baseUri.Host}";

        if (memoryCache.TryGetValue(key, out string sessionId))
            return sessionId!;

        var relativeUri = ModemUriConstants.TypeToRelativeUri[typeof(SessionTokenInfoResponse)];
        var request = new HttpRequestMessage(HttpMethod.Get, relativeUri);

        using var response = await httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);

        using var reader = new StringReader(responseText);
        using var xmlReader = XmlReader.Create(reader);
        var xmlSerializer = TypeToXmlSerializer[typeof(SessionTokenInfoResponse)];

        var sessionTokenInfo = (SessionTokenInfoResponse)xmlSerializer.Deserialize(xmlReader)!;
        sessionId = sessionTokenInfo.SessionInfo!.Substring("SessionID=".Length);
        memoryCache.Set(key, sessionId);

        return sessionId;
    }
}