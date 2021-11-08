using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleJwtAuth.Core.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleJwtAuth.Core.Authorization;
public class TokenHelper : ITokenHelper
{
    private readonly IOptions<JwtConfig> _options;

    public TokenHelper(IOptions<JwtConfig> options)
    {
        _options = options;
    }

    public Token Create(Claim[] claims)
    {
        var timestamp = TimeStampHelper.ConvertJavaTimeStamp(DateTime.Now.AddMinutes(_options.Value.RefreshExpires)).ToString();
        claims = claims.Append(new Claim(AuthConst.RefreshExpires, timestamp)).ToArray();

        var now = DateTime.Now;
        var expires = now.AddMinutes(_options.Value.Expires);

        var token = new JwtSecurityToken(
            issuer: _options.Value.Issuer,
            audience: _options.Value.Audience,
            claims: claims,
            notBefore: now,
            expires: expires,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.IssuerSigningKey)), SecurityAlgorithms.HmacSha256)
        );
        return new Token
        {
            AccessContent = new JwtSecurityTokenHandler().WriteToken(token),
            Expires = expires
        };
    }

    public Claim[] Decode(string jwtToken)
    {
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = jwtSecurityTokenHandler.ReadJwtToken(jwtToken);
        return jwtSecurityToken?.Claims?.ToArray();
    }
}
