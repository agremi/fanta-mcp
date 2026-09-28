namespace fanta_mcp.Dto;

public sealed record LoginRequestDto
{
    public required string username;
    public required string password;
}