using System.ComponentModel;

namespace SimpleJwtAuth.Core.ActionResult;
public enum ResultCode
{

    /// <summary>
    /// 操作成功
    ///</summary>
    [Description("Success")]
    Ok = 200,

    /// <summary>
    /// 操作失败
    ///</summary>
    [Description("Fail")]
    Fail = 500,

    /// <summary>
    /// 已创建
    ///</summary>
    [Description("Created")]
    Created = 201,

    /// <summary>
    /// 已接受
    ///</summary>
    [Description("Accepted")]
    Accepted = 202,

    /// <summary>
    /// 无内容
    ///</summary>
    [Description("NoContent")]
    NoContent = 204,

    /// <summary>
    /// 请求无效
    ///</summary>
    [Description("BadRequest")]
    BadRequest = 400,

    /// <summary>
    /// 未登录
    ///</summary>
    [Description("Unauthorized")]
    Unauthorized = 401,

    /// <summary>
    /// 未授权
    ///</summary>
    [Description("Forbidden")]
    Forbidden = 403,

    /// <summary>
    /// 不存在
    ///</summary>
    [Description("NotFound")]
    NotFound = 404,


    /// <summary>
    /// 其他客户端登录中
    ///</summary>
    [Description("OtherLogin")]
    OtherLogin = 1000,
}
