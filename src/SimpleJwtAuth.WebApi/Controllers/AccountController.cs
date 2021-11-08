using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleJwtAuth.Core.ActionResult;
using SimpleJwtAuth.Core.Authorization;
using SimpleJwtAuth.Core.Extensions;
using SimpleJwtAuth.WebApi.ViewModels;
using System.Security.Claims;

namespace SimpleJwtAuth.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly ITokenHelper _tokenHelper;

    public AccountController(ITokenHelper tokenHelper)
    {
        _tokenHelper = tokenHelper;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Result<Token>>> Login([FromBody] LoginDto model)
    {
        // 校验

        // 报错

        //if (!ModelState.IsValid)

        // ... 用户信息

        var token = _tokenHelper.Create(new[]
        {
            new Claim("UserId", "user.Id.ToString()"),
            new Claim(JwtClaimTypes.Name, "userName"),
            new Claim(ClaimTypes.Role, "User"),
        });

        return Result<Token>.Ok(token);
    }


    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Result<Token>>> RefreshToken([FromBody] RefreshTokenDto model)
    {
        // 校验

        // 报错

        var userClaims = _tokenHelper.Decode(model.Token);

        var refreshExpires = userClaims.FirstOrDefault(a => a.Type == AuthConst.RefreshExpires)?.Value;
        if (string.IsNullOrEmpty(refreshExpires))
        {
            return Ok(Result<object>.FromError("token 超时"));
        }

        if (!double.TryParse(refreshExpires, out var expire) || TimeStampHelper.JavaTimeStampToDateTime(expire) <= DateTime.Now)
        {
            return Ok(Result<object>.FromError("token 超时"));
        }


        var UserId = userClaims.FirstOrDefault(x=>x.Type == "UserId")?.Value;
        // ... 用户信息

        var token = _tokenHelper.Create(new[]
{
            new Claim("UserId", "user.Id.ToString()"),
            new Claim(JwtClaimTypes.Name, "userName"),
            new Claim(ClaimTypes.Role, "User"),
        });

        return Result<Token>.Ok(token);
    }
}
