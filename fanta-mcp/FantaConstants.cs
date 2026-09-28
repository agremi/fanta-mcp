namespace fanta_mcp;

public static class FantaConstants
{
    public const string BaseUrl = "https://apileague.fantacalcio.it/";
    public const string Version = "1.0";
    public static readonly Dictionary<string, string> URIS = new()
    {
        { "login", "onboarding/v1/login" }
    };
}
