namespace Huawei.E3372.Manager.Logic;

public record ServiceResult
{
    public bool IsSuccess { get; init; }
    public ServiceResultErrorCode? ErrorCode { get; init; }
    public string? ErrorMessage { get; init; }

    public ServiceResult()
    {
        IsSuccess = true;
    }
    public ServiceResult(ServiceResultErrorCode code, string? message)
    {
        IsSuccess = false;
        ErrorCode = code;
        ErrorMessage = message;
    }

    public static ServiceResult Success() => new ServiceResult();
    public static ServiceResult Failure(ServiceResultErrorCode code, string? message = null) => new ServiceResult(code, message);
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

    public ServiceDataResult(ServiceResultErrorCode code, string? message = null, TResult? result = null) : base(code, message)
    {
        Result = result;
    }

    public static ServiceDataResult<TResult> Success(TResult result) => new ServiceDataResult<TResult>(result);
    public static ServiceDataResult<TResult> Failure(ServiceResultErrorCode code) => new ServiceDataResult<TResult>(code);
    public static ServiceDataResult<TResult> Failure(ServiceResultErrorCode code, TResult? result = null) => new ServiceDataResult<TResult>(code, result: result);
    public static ServiceDataResult<TResult> Failure(ServiceResultErrorCode code, string? message = null, TResult? result = null) => new ServiceDataResult<TResult>(code, message, result);    
}

public enum ServiceResultErrorCode
{
    Duplicate,
    LocalNotFound,
    RemoteNotFound,
}