using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;
using fanta_mcp;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);

builder.Services.AddMcpServer()
                .WithStdioServerTransport()
                .WithToolsFromAssembly();

builder.Services.AddSingleton(_=>
{
    var client = new HttpClient() { BaseAddress = new Uri(FantaConstants.BaseUrl) };
    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("fanta-tool",FantaConstants.Version));
    client.DefaultRequestHeaders.Add("App-key","");
    return client;
});

var app = builder.Build();

await app.RunAsync();