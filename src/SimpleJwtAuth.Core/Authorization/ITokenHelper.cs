using System.Security.Claims;

namespace SimpleJwtAuth.Core.Authorization;
public interface ITokenHelper
{
    Token Create(Claim[] claims);

    Claim[] Decode(string jwtToken);
}
