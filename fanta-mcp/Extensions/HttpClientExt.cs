using System.Net.Http.Json;
using System.Text.Json;
using fanta_mcp.Dto;

namespace fanta_mcp.Extensions;

public static class HttpClientExt
{
    public static async Task<LoginResponseDto?> FantaLegheLogin(this HttpClient client, LoginRequestDto request, CancellationToken cancellationToken = default)
    {
        var response = await client.PostAsJsonAsync("onboarding/v1/login",request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<LoginResponseDto>(
        cancellationToken: cancellationToken);
    }
}