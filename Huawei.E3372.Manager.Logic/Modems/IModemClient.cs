using Huawei.E3372.Manager.Logic.Modems.Models;

namespace Huawei.E3372.Manager.Logic.Modems;

public interface IModemClient
{
    public Task<TModemGetResponse> GetAsync<TModemGetResponse>(
        Uri baseUri,
        CancellationToken cancellationToken = default)
        where TModemGetResponse : IModemGetResponse;

    public Task<TModelPostResponse> PostAsync<TModelPostRequest, TModelPostResponse>(
        Uri baseUri,
        TModelPostRequest model,
        CancellationToken cancellationToken = default)
        where TModelPostRequest : IModemPostRequest
        where TModelPostResponse : IModemPostResponse;
}