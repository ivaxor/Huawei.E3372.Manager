namespace Huawei.E3372.Manager.Logic;

public record ServiceResult<TResult>
    where TResult : class
{
    public bool IsSuccess { get; init; }
    public TResult? Result { get; init; }
    public ServiceResultErrorCode? ErrorCode { get; init; }

    public ServiceResult(TResult result)
    {
        IsSuccess = true;
        Result = result;
    }

    public ServiceResult(ServiceResultErrorCode errorCode, TResult? result = null)
    {
        IsSuccess = false;
        ErrorCode = errorCode;
        Result = result;
    }

    public static ServiceResult<TResult> Success(TResult result) => new ServiceResult<TResult>(result);
    public static ServiceResult<TResult> Failure(ServiceResultErrorCode errorCode, TResult? result = null) => new ServiceResult<TResult>(errorCode, result);
}

public enum ServiceResultErrorCode
{
    Duplicate,
    LocalNotFound,
    RemoteNotFound,
}