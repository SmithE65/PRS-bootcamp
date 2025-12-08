namespace Prs.Bff.Api.Configuration;

public class SpaAuthOptions
{
    public string Authority { get; set; }
    public string ClientId { get; set; }
    public string Scope { get; set; }
}

public class AuthenticationOptions
{
    public const string Authentication = "Authentication";

    public string Authority { get; set; }
    public string Audience { get; set; }
    public SpaAuthOptions Spa {  get; set; }
}
