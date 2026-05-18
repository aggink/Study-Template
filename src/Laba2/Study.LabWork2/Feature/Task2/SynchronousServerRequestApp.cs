using System.Diagnostics;
using System.Text.Json;
using Study.LabWork2.Abstractions.Feature.Task2;
using Study.LabWork2.Abstractions.Feature.Task2.DtoModels;

namespace Study.LabWork2.Feature.Task2;

public sealed class SynchronousServerRequestApp : IServerRequestApp
{
    public ExecutionResultDto<TResponse> ExecuteRequests<TResponse>(ServerConfigDto[] servers)
    {
        CheckServers(servers);

        var collectedResponses = new List<TResponse>();
        int okCount = 0;
        int errorCount = 0;

        using var client = new HttpClient();

        var timer = Stopwatch.StartNew();

        foreach (ServerConfigDto server in servers)
        {
            Console.WriteLine($"Синхронный запрос: {server.Name} — {server.Url}");

            try
            {
                using HttpResponseMessage response = client
                    .GetAsync(server.Url)
                    .GetAwaiter()
                    .GetResult();

                string body = response.Content
                    .ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();

                Console.WriteLine(body);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Ошибка HTTP: {(int)response.StatusCode} {response.ReasonPhrase}");

                    errorCount++;
                    break;
                }

                TResponse parsed = ConvertJson<TResponse>(body);

                collectedResponses.Add(parsed);
                okCount++;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Ошибка запроса к {server.Url}: {exception.Message}");

                errorCount++;
                break;
            }
        }

        timer.Stop();

        Console.WriteLine($"Общее время синхронной версии: {timer.Elapsed}");

        return new ExecutionResultDto<TResponse>
        {
            Responses = collectedResponses,
            TotalExecutionTime = timer.Elapsed,
            SuccessfulRequests = okCount,
            FailedRequests = errorCount,
            Version = GetVersion()
        };
    }

    public string GetVersion()
    {
        return "Synchronous";
    }

    private static TResponse ConvertJson<TResponse>(string json)
    {
        TResponse? result = JsonSerializer.Deserialize<TResponse>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (result == null)
        {
            throw new InvalidOperationException("JSON-ответ не удалось преобразовать к нужному типу.");
        }

        return result;
    }

    private static void CheckServers(ServerConfigDto[] servers)
    {
        if (servers == null || servers.Length == 0)
        {
            throw new ArgumentException("Список серверов пуст.");
        }

        foreach (ServerConfigDto server in servers)
        {
            if (!server.IsValid())
            {
                throw new ArgumentException($"Некорректный сервер: {server}");
            }
        }
    }
}
