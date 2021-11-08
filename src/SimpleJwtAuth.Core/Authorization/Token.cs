namespace SimpleJwtAuth.Core.Authorization;
public class Token
{
    public string AccessContent { get; set; }

    public DateTimeOffset Expires { get; set; }
}

