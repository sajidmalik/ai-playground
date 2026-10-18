using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mcp_server.Tools;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<WeatherUtils>()
    .WithTools<DateTimeUtils>();

await builder
    .Build()
    .RunAsync();