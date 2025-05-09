using Huawei.E3372.Manager.Domain.Modem;
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
    internal static readonly XmlSerializer ErrorXmlSerializer = new XmlSerializer(typeof(Error));

    public async Task<IModemResponse> GetAsync<TModemResponse>(
        Uri baseUri,
        CancellationToken cancellationToken = default)
        where TModemResponse : IModemResponse
    {
        using var httpClientHandler = new HttpClientHandler() { CookieContainer = new CookieContainer() };
        using var httpClient = new HttpClient(httpClientHandler) { BaseAddress = baseUri };        

        var sessionId = await GetSessionIdAsync(baseUri, httpClient, cancellationToken);
        httpClientHandler.CookieContainer.Add(baseUri, new Cookie("SessionID", sessionId));

        var relativeUri = ModemUriConstants.TypeToRelativeUri[typeof(TModemResponse)];
        var request = new HttpRequestMessage(HttpMethod.Get, relativeUri);

        using var response = await httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);

        using var reader = new StringReader(responseText);
        using var xmlReader = XmlReader.Create(reader);
        var xmlSerializer = TypeToXmlSerializer[typeof(TModemResponse)];

        if (xmlSerializer.CanDeserialize(xmlReader))
            return (TModemResponse)xmlSerializer.Deserialize(xmlReader)!;

        if (ErrorXmlSerializer.CanDeserialize(xmlReader))
        {
            var error = (Error)ErrorXmlSerializer.Deserialize(xmlReader)!;
            logger.LogError("Error response returned by modem. Code: {Code}. Message: {Message}", error.Code, error.Message);
            return error;
        }

        logger.LogError("Failed to deserialize data from modem. Response: {Response}", responseText);
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

        var relativeUri = ModemUriConstants.TypeToRelativeUri[typeof(SessionTokenInfo)];
        var request = new HttpRequestMessage(HttpMethod.Get, relativeUri);

        using var response = await httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);

        using var reader = new StringReader(responseText);
        using var xmlReader = XmlReader.Create(reader);
        var xmlSerializer = TypeToXmlSerializer[typeof(SessionTokenInfo)];

        var sessionTokenInfo = (SessionTokenInfo)xmlSerializer.Deserialize(xmlReader)!;
        sessionId = sessionTokenInfo.SessionInfo!.Substring("SessionID=".Length);
        memoryCache.Set(key, sessionId);

        return sessionId;
    }
}