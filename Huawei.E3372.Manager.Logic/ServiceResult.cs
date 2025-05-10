namespace Huawei.E3372.Manager.Logic;

public record ServiceResult
{
    public bool IsSuccess { get; init; }
    public ServiceResultErrorCode? ErrorCode { get; init; }

    public ServiceResult()
    {
        IsSuccess = true;
    }
    public ServiceResult(ServiceResultErrorCode errorCode)
    {
        IsSuccess = false;
        ErrorCode = errorCode;
    }

    public static ServiceResult Success() => new ServiceResult();
    public static ServiceResult Failure(ServiceResultErrorCode errorCode) => new ServiceResult(errorCode);
}

public record ServiceDataResult<TResult>
    : ServiceResult
    where TResult : class
{
    public TResult? Result { get; init; }

    public ServiceDataResult(TResult result) : base()
    {
        IsSuccess = true;
        Result = result;
    }

    public ServiceDataResult(ServiceResultErrorCode errorCode, TResult? result = null) : base(errorCode)
    {
        Result = result;
    }

    public static ServiceDataResult<TResult> Success(TResult result) => new ServiceDataResult<TResult>(result);
    public static ServiceDataResult<TResult> Failure(ServiceResultErrorCode errorCode, TResult? result = null) => new ServiceDataResult<TResult>(errorCode, result);
}

public enum ServiceResultErrorCode
{
    Duplicate,
    LocalNotFound,
    RemoteNotFound,
}