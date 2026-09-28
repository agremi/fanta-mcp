using System.Net.Http.Json;
using System.Text.RegularExpressions;
using fanta_mcp.Dto;

namespace fanta_mcp.Clients;

public sealed partial class LegheFantacalcioClient
{
    private readonly HttpClient _apiClient;
    private readonly HttpClient _fantacalcioWebClient;

    [GeneratedRegex(
        """\b["']?authAppKey["']?\s*:\s*["']([A-Za-z0-9_-]{16,128})["']"""
    )]
    private partial Regex AppKeyRegex();

    public LegheFantacalcioClient(IHttpClientFactory clientFactory)
    {
        _apiClient = clientFactory.CreateClient("LegheApiClient");
        _fantacalcioWebClient = clientFactory.CreateClient("FantacalcioWebClient");
    }

    public async Task<LoginResponseDto?> FantaLegheLogin(LoginRequestDto loginRequest, CancellationToken cancellationToken = default)
    {
        var appKey = await ObtainAppKey(cancellationToken);

        using var request = new HttpRequestMessage(
        HttpMethod.Post,
        FantaConstants.URIS["login"]);
        request.Headers.Add("App_key", appKey);
        request.Content = JsonContent.Create(loginRequest);

        var response = await _apiClient.PostAsJsonAsync(FantaConstants.URIS["login"], request, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<LoginResponseDto>(cancellationToken: cancellationToken);
    }
    private async Task<string> ObtainAppKey(CancellationToken cancellationToken = default)
    {
        using var response = await _fantacalcioWebClient.GetAsync(
        "https://leghe.fantacalcio.it/login",
        cancellationToken);

        response.EnsureSuccessStatusCode();

        var html = await response.Content.ReadAsStringAsync(
            cancellationToken);

        var match = AppKeyRegex().Match(html);

        if (!match.Success)
        {
            throw new InvalidOperationException(
                "authAppKey non trovata nella pagina.");
        }
        return match.Groups[1].Value;
    }
}