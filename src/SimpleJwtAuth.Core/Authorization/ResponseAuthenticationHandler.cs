using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleJwtAuth.Core.ActionResult;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleJwtAuth.Core.Authorization;

/// <summary>
/// 响应认证处理器
/// </summary>
public class ResponseAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public ResponseAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock
    ) : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        throw new NotImplementedException();
    }

    protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
    {
        Response.ContentType = "application/json";
        Response.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized;

        var json = Result<ExceptionResult>.FromCode(ResultCode.Unauthorized);

        await Response.WriteAsync(JsonSerializer.Serialize(json, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter() }
        }));
    }

    protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
    {
        Response.ContentType = "application/json";
        Response.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status403Forbidden;

        var json = Result<ExceptionResult>.FromCode(ResultCode.Forbidden);

        await Response.WriteAsync(JsonSerializer.Serialize(json, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter() }
        }));
    }
}
