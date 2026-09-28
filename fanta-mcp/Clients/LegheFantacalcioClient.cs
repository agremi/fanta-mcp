using System.Net.Http.Json;
using fanta_mcp;
using fanta_mcp.Dto;

namespace fanta_mco.Clients;

public sealed class LegheFantacalcioClient
{
    private HttpClient _client;
    public LegheFantacalcioClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<LoginResponseDto?> FantaLegheLogin(LoginRequestDto request, CancellationToken cancellationToken = default)
    {
        var response = await _client.PostAsJsonAsync(FantaConstants.URIS["login"], request, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<LoginResponseDto>(cancellationToken: cancellationToken);
    }
}