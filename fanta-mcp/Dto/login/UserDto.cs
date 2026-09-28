using System.Text.Json;
using System.Text.Json.Serialization;

namespace fanta_mcp.Dto;
public sealed record UserDto
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("username")]
    public required string Username { get; init; }

    [JsonPropertyName("email")]
    public required string Email { get; init; }

    [JsonPropertyName("confermato")]
    public int Confirmed { get; init; }

    [JsonPropertyName("marketing")]
    public int Marketing { get; init; }

    [JsonPropertyName("regalo")]
    public int Gift { get; init; }

    [JsonPropertyName("utente_token")]
    public required string UserToken { get; init; }

    [JsonPropertyName("squadra")]
    public required string Team { get; init; }

    [JsonPropertyName("provincia")]
    public required string Province { get; init; }

    [JsonPropertyName("nascita")]
    public required string BirthYear { get; init; }

    [JsonPropertyName("data_c")]
    public DateTime CreatedAt { get; init; }

    [JsonPropertyName("data_m")]
    public DateTime ModifiedAt { get; init; }

    [JsonPropertyName("social")]
    public required IReadOnlyList<JsonElement> Social { get; init; }

    [JsonPropertyName("purchases")]
    public required IReadOnlyList<JsonElement> Purchases { get; init; }
}