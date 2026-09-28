using System.Text.Json;
using System.Text.Json.Serialization;

namespace fanta_mcp.Dto;
public sealed record LoginResponseDto
{
    [JsonPropertyName("state")]
    public long State { get; init; }

    [JsonPropertyName("success")]
    public bool Success { get; init; }

    [JsonPropertyName("update")]
    public bool Update { get; init; }

    [JsonPropertyName("data")]
    public required LoginDataDto Data { get; init; }

    [JsonPropertyName("error_msgs")]
    public JsonElement? ErrorMessages { get; init; }
}