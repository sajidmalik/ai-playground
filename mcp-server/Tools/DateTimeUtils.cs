using System.ComponentModel;
using ModelContextProtocol.Server;

namespace mcp_server.Tools;

[McpServerToolType]
internal sealed class DateTimeUtils
{
    [McpServerTool, Description("Retrieves the current date time in UTC.")]
    public static string GetCurrentDateTimeInUTC()
    {
        return DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
    }
}