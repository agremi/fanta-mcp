using System.Text.Json;
using System.Text.Json.Serialization;

namespace fanta_mcp.Dto;
public sealed record LeagueDto
{
    [JsonPropertyName("visibile")]
    public bool Visible { get; init; }

    [JsonPropertyName("ordine")]
    public int Order { get; init; }

    [JsonPropertyName("admin")]
    public int Admin { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("id_squadra")]
    public long TeamId { get; init; }

    [JsonPropertyName("sponsor_id")]
    public int SponsorId { get; init; }

    [JsonPropertyName("sponsor_v")]
    public int SponsorVersion { get; init; }

    [JsonPropertyName("tipo_lega")]
    public int LeagueType { get; init; }

    [JsonPropertyName("tipo_gioco")]
    public int GameType { get; init; }

    [JsonPropertyName("nome")]
    public required string Name { get; init; }

    [JsonPropertyName("alias")]
    public required string Alias { get; init; }

    [JsonPropertyName("divisione")]
    public required string Division { get; init; }

    [JsonPropertyName("ordine_comp")]
    public required string CompetitionOrder { get; init; }

    [JsonPropertyName("link")]
    public required string Link { get; init; }

    [JsonPropertyName("logo")]
    public required string Logo { get; init; }

    [JsonPropertyName("jwt")]
    public required string Jwt { get; init; }

    [JsonPropertyName("token")]
    public required string Token { get; init; }
}