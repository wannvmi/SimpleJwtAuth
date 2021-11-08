using SimpleJwtAuth.Core.Extensions;

namespace SimpleJwtAuth.Core.ActionResult;

/// <summary>
/// {"Success":true,"Code":"200","Message":"ok",Data:{}}
/// </summary>
/// <typeparam name="T"></typeparam>
public class Result<T>
{
    /// <summary>
    /// 是否成功
    /// </summary>
    public bool Success => Code == ResultCode.Ok;

    /// <summary>
    /// 结果码
    /// </summary>
    public ResultCode Code { get; set; }

    /// <summary>
    /// 提示信息
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// 返回业务数据
    /// </summary>
    public T Data { get; set; }

    public Result(T data)
    {
        Code = ResultCode.Ok;
        Message = ResultCode.Ok.GetDescription();
        this.Data = data;
    }

    public Result(ResultCode code, string message, T data)
    {
        Code = code;
        Message = message ?? code.GetDescription();
        Data = data;
    }

    public static Result<T> FromCode(ResultCode code, string message = null, T data = default)
    {
        return new Result<T>(code, message, data);
    }

    public static Result<T> Ok(T data)
    {
        return new Result<T>(data);
    }

    public static Result<T> FromError(string message = null, T data = default)
    {
        return new Result<T>(ResultCode.Fail, message, data);
    }

}
