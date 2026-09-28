using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);

builder.Services.AddMcpServer()
                .WithStdioServerTransport()
                .WithToolsFromAssembly();

builder.Services.AddHttpClient("LegheApiClient", client =>
{
    client.BaseAddress = new Uri("https://apileague.fantacalcio.it/");
});

builder.Services.AddHttpClient("FantacalcioWebClient", client =>
{
    client.BaseAddress = new Uri("https://leghe.fantacalcio.it/");

    client.DefaultRequestHeaders.UserAgent.ParseAdd(
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) " +
        "AppleWebKit/537.36 (KHTML, like Gecko) " +
        "Chrome/151.0.0.0 Safari/537.36");

    client.DefaultRequestHeaders.Accept.ParseAdd(
        "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");

    client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(
        "it-IT,it;q=0.5");
});

var app = builder.Build();

await app.RunAsync();