using System.ComponentModel.DataAnnotations;

namespace SimpleJwtAuth.WebApi.ViewModels;
public class LoginDto
{
    /// <summary>
    /// 登录名
    /// </summary>
    [Required]
    public string LoginName { set; get; }

    /// <summary>
    /// 密码
    /// </summary>
    [Required]
    public string Password { set; get; }
}
