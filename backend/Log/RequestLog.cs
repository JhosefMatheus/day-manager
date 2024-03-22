using System.IO.Pipelines;
using System.Text.Json;
using Microsoft.Extensions.Primitives;

namespace backend.Log;

public class RequestLog
{
    public static void Log(Exception exception, HttpRequest request)
    {
        request.EnableBuffering();

        DateTime dateTime = DateTime.Now;

        string requestPath = request.Path;
        string requestMethod = request.Method;

        List<KeyValuePair<string, StringValues>> requestQuery = request
            .Query.ToList<KeyValuePair<string, StringValues>>();

        List<KeyValuePair<string, StringValues>> requestHeaders = request
            .Headers.ToList<KeyValuePair<string, StringValues>>();

        Stream requestBody = request.Body;

        string exceptionMessage = exception.Message;
        string exceptionStackTrace = exception.StackTrace;

        string logText = "";

        logText += "DateTime: " + dateTime.ToString("dd/MM/yyyy HH:mm:ss") + "\n";

        logText += "Request:\n";
        logText += "\tPath: " + requestPath + "\n";
        logText += "\tMethod: " + requestMethod + "\n";

        string requestQueryLogText = GenerateRequestQueryLogText(requestQuery);

        logText += requestQueryLogText;

        string requestHeadersLogText = GenerateRequestHeadersLogText(requestHeaders);

        logText += requestHeadersLogText;

        string requestBodyLogText = GenerateRequestBodyLogText(requestBody);

        logText += requestBodyLogText;

        logText += "Exception:\n";
        logText += "\tMessage: " + exceptionMessage + "\n";
        logText += "\tStackTrace: " + exceptionStackTrace + "\n\n";

        using (StreamWriter writer = new StreamWriter("error.log", true))
        {
            writer.WriteLine(logText);
        }
    }

    private static string GenerateRequestQueryLogText(List<KeyValuePair<string, StringValues>> requestQuery)
    {
        string logText = "\tQuery:\n";

        requestQuery.ForEach((KeyValuePair<string, StringValues> e) =>
        {
            logText += "\t\t" + e.Key + ": " + e.Value + "\n";
        });

        return logText;
    }

    private static string GenerateRequestHeadersLogText(List<KeyValuePair<string, StringValues>> requestHeaders)
    {
        string logText = "\tHeaders:\n";

        requestHeaders.ForEach((KeyValuePair<string, StringValues> e) =>
        {
            logText += "\t\t" + e.Key + ": " + e.Value + "\n";
        });

        return logText;
    }

    private static string GenerateRequestBodyLogText(Stream requestBody)
    {
        string logText = "\tBody:\n";

        requestBody.Seek(0, SeekOrigin.Begin);

        using (StreamReader reader = new StreamReader(requestBody))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                logText += "\t\t" + line + "\n";
            }
        }

        return logText;
    }
}