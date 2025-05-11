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

public record ServiceDataResult<TData>
    : ServiceResult
    where TData : class
{
    public TData? Data { get; init; }

    public ServiceDataResult(TData data) : base()
    {
        IsSuccess = true;
        Data = data;
    }

    public ServiceDataResult(ServiceResultErrorCode code, string? message = null, TData? data = null) : base(code, message)
    {
        Data = data;
    }

    public static ServiceDataResult<TData> Success(TData result) => new ServiceDataResult<TData>(result);
    public static ServiceDataResult<TData> Failure(ServiceResultErrorCode code, string? message = null, TData? data = null) => new ServiceDataResult<TData>(code, message, data);    
}

public enum ServiceResultErrorCode
{
    Duplicate,
    LocalNotFound,
    RemoteNotFound,
}