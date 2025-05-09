using Huawei.E3372.Manager.Domain.Modem;

namespace Huawei.E3372.Manager.Logic.ModemClients;

public interface IModemClient
{
    public Task<IModemGetResponse> GetAsync<TModemGetResponse>(
        Uri baseUri,
        CancellationToken cancellationToken = default)
        where TModemGetResponse : IModemGetResponse;

    public Task<IModemPostResponse> PostAsync<TModelPostRequest, TModelPostResponse>(
        Uri baseUri,
        TModelPostRequest model,
        CancellationToken cancellationToken = default)
        where TModelPostRequest : IModemPostRequest
        where TModelPostResponse : IModemPostResponse;
}