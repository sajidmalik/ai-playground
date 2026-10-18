using ModelContextProtocol.Server;
using System.ComponentModel;

namespace mcp_server.Tools;

[McpServerToolType]
internal sealed class WeatherUtils
{
    [McpServerTool, Description("Gets the current weather for the specified city and specified date time.")]
    public static string GetWeatherForCity(string city, string currentTimeInUTC)
    {
        return city switch
        {
            "Abu Dhabhi" => "50 and Sunny",
            "London" => "32 and rainy"
        };
    }
}