using System.Text.Json;
using System.Text.Json.Serialization;

namespace fanta_mcp.Dto;
public sealed record LoginDataDto
{
    [JsonPropertyName("state_auth")]
    public long StateAuth { get; init; }

    [JsonPropertyName("token_auth")]
    public required string TokenAuth { get; init; }

    [JsonPropertyName("sendbird_token")]
    public required string SendbirdToken { get; init; }

    [JsonPropertyName("utente")]
    public required UserDto User { get; init; }

    [JsonPropertyName("leghe")]
    public required IReadOnlyList<LeagueDto> Leagues { get; init; }

    [JsonPropertyName("acquisti")]
    public required IReadOnlyList<JsonElement> Purchases { get; init; }

    [JsonPropertyName("message_ids")]
    public required IReadOnlyList<JsonElement> MessageIds { get; init; }

    [JsonPropertyName("jwt")]
    public required string Jwt { get; init; }
}