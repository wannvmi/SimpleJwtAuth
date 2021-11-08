using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJwtAuth.Core.Authorization;
public class JwtConfig
{
    /// <summary>
    /// 发行者
    /// </summary>
    public string Issuer { get; set; }

    /// <summary>
    /// 订阅者
    /// </summary>
    public string Audience { get; set; }

    /// <summary>
    /// 密钥
    /// </summary>
    public string IssuerSigningKey { get; set; }

    /// <summary>
    /// 有效期(分钟)
    /// </summary>
    public int Expires { get; set; } = 120;

    /// <summary>
    /// 刷新有效期(分钟)
    /// </summary>
    public int RefreshExpires { get; set; } = 43200;
}
