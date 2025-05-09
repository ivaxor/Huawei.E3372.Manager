using Huawei.E3372.Manager.Domain.Modem;
using Huawei.E3372.Manager.Domain.Modem.Api.WebServer;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Collections.Frozen;
using System.Net;
using System.Net.Mime;
using System.Text;
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

    public async Task<TModemGetResponse> GetAsync<TModemGetResponse>(
        Uri baseUri,
        CancellationToken cancellationToken = default)
        where TModemGetResponse : IModemGetResponse
    {
        using var httpClient = await CreateHttpClientForGetAsync(baseUri, cancellationToken);

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

    public async Task<TModelPostResponse> PostAsync<TModelPostRequest, TModelPostResponse>(
        Uri baseUri,
        TModelPostRequest model,
        CancellationToken cancellationToken = default)
        where TModelPostRequest : IModemPostRequest
        where TModelPostResponse : IModemPostResponse
    {
        using var httpClient = await CreateHttpClientForPostAsync(baseUri, cancellationToken);

        var relativeUri = ModemUriConstants.TypeToRelativeUri[typeof(TModelPostResponse)];
        var request = new HttpRequestMessage(HttpMethod.Post, relativeUri);

        var xmlRequestSerializer = new XmlSerializer(model.GetType());
        using var writer = new StringWriter();
        xmlRequestSerializer.Serialize(writer, model);
        request.Content = new StringContent(writer.ToString(), Encoding.UTF8, MediaTypeNames.Application.Xml);

        using var response = await httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);

        using var reader = new StringReader(responseText);
        using var xmlReader = XmlReader.Create(reader);
        var xmlResponseSerializer = TypeToXmlSerializer[typeof(TModelPostResponse)];

        if (xmlResponseSerializer.CanDeserialize(xmlReader))
            return (TModelPostResponse)xmlResponseSerializer.Deserialize(xmlReader)!;

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

    internal async Task<HttpClient> CreateHttpClientForGetAsync(
        Uri baseUri,
        CancellationToken cancellationToken = default)
    {
        var httpClientHandler = new HttpClientHandler() { CookieContainer = new CookieContainer() };
        var httpClient = new HttpClient(httpClientHandler) { BaseAddress = baseUri };

        var sessionTokenInfo = await GetCachedSessionTokenInfoAsync(baseUri, httpClient, cancellationToken);
        var sessionId = sessionTokenInfo.SessionInfo!.Substring("SessionID=".Length);
        httpClientHandler.CookieContainer.Add(baseUri, new Cookie("SessionID", sessionId));

        return httpClient;
    }

    internal async Task<HttpClient> CreateHttpClientForPostAsync(
        Uri baseUri,
        CancellationToken cancellationToken = default)
    {
        var httpClientHandler = new HttpClientHandler() { CookieContainer = new CookieContainer() };
        var httpClient = new HttpClient(httpClientHandler) { BaseAddress = baseUri };

        var sessionTokenInfo = await GetSessionTokenInfoAsync(httpClient, cancellationToken);
        var sessionId = sessionTokenInfo.SessionInfo!.Substring("SessionID=".Length);
        httpClientHandler.CookieContainer.Add(baseUri, new Cookie("SessionID", sessionId));
        httpClient.DefaultRequestHeaders.Add("__requestverificationtoken", sessionTokenInfo.TokenInfo);

        return httpClient;
    }

    internal Task<SessionTokenInfoResponse> GetCachedSessionTokenInfoAsync(
        Uri baseUri,
        HttpClient httpClient,
        CancellationToken cancellationToken = default)
    {
        return memoryCache.GetOrCreateAsync(
            $"{nameof(SessionTokenInfoResponse)}_{baseUri.Host}",
            c => GetSessionTokenInfoAsync(httpClient, cancellationToken))!;
    }

    internal async Task<SessionTokenInfoResponse> GetSessionTokenInfoAsync(
        HttpClient httpClient,
        CancellationToken cancellationToken = default)
    {
        var relativeUri = ModemUriConstants.TypeToRelativeUri[typeof(SessionTokenInfoResponse)];
        var request = new HttpRequestMessage(HttpMethod.Get, relativeUri);

        using var response = await httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);

        using var reader = new StringReader(responseText);
        using var xmlReader = XmlReader.Create(reader);
        var xmlSerializer = TypeToXmlSerializer[typeof(SessionTokenInfoResponse)];

        return (SessionTokenInfoResponse)xmlSerializer.Deserialize(xmlReader)!;
    }
}