using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using ModelContextProtocol;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using fanta_mcp;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);

builder.Services.AddMcpServer()
                .WithStdioServerTransport()
                .WithToolsFromAssembly();

builder.Services.AddSingleton(_ =>
{
    var client = new HttpClient() { BaseAddress = new Uri(FantaConstants.BaseUrl) };
    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("fanta-tool",FantaConstants.Version));
    return client;
});

var app = builder.Build();

await app.RunAsync();