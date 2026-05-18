using System.Diagnostics;
using System.Text.Json;
using Study.LabWork2.Abstractions.Feature.Task2;
using Study.LabWork2.Abstractions.Feature.Task2.DtoModels;

namespace Study.LabWork2.Feature.Task2;

public sealed class AsynchronousServerRequestApp : IServerRequestApp
{
    public ExecutionResultDto<TResponse> ExecuteRequests<TResponse>(ServerConfigDto[] servers)
    {
        return ExecuteAllAsync<TResponse>(servers).GetAwaiter().GetResult();
    }

    public string GetVersion()
    {
        return "Asynchronous";
    }

    private async Task<ExecutionResultDto<TResponse>> ExecuteAllAsync<TResponse>(ServerConfigDto[] servers)
    {
        CheckServers(servers);

        var timer = Stopwatch.StartNew();

        using var client = new HttpClient();

        Task<SingleRequestInfo<TResponse>>[] operations = servers
            .Select(server => LoadFromServerAsync<TResponse>(client, server))
            .ToArray();

        SingleRequestInfo<TResponse>[] finishedOperations = await Task.WhenAll(operations);

        timer.Stop();

        var answers = new List<TResponse>();
        int successes = 0;
        int failures = 0;

        foreach (SingleRequestInfo<TResponse> operation in finishedOperations)
        {
            if (operation.Success && operation.Value != null)
            {
                answers.Add(operation.Value);
                successes++;
            }
            else
            {
                failures++;
            }
        }

        Console.WriteLine($"Общее время асинхронной версии: {timer.Elapsed}");

        return new ExecutionResultDto<TResponse>
        {
            Responses = answers,
            TotalExecutionTime = timer.Elapsed,
            SuccessfulRequests = successes,
            FailedRequests = failures,
            Version = GetVersion()
        };
    }

    private static async Task<SingleRequestInfo<TResponse>> LoadFromServerAsync<TResponse>(
        HttpClient client,
        ServerConfigDto server)
    {
        Console.WriteLine($"Асинхронный запрос: {server.Name} — {server.Url}");

        try
        {
            using HttpResponseMessage response = await client.GetAsync(server.Url);
            string json = await response.Content.ReadAsStringAsync();

            Console.WriteLine(json);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Ошибка HTTP: {(int)response.StatusCode} {response.ReasonPhrase}");
                return SingleRequestInfo<TResponse>.CreateFail();
            }

            TResponse parsed = ParseJson<TResponse>(json);

            return SingleRequestInfo<TResponse>.CreateSuccess(parsed);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Ошибка запроса к {server.Url}: {exception.Message}");
            return SingleRequestInfo<TResponse>.CreateFail();
        }
    }

    private static TResponse ParseJson<TResponse>(string json)
    {
        TResponse? value = JsonSerializer.Deserialize<TResponse>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (value == null)
        {
            throw new InvalidOperationException("Ответ сервера не удалось разобрать.");
        }

        return value;
    }

    private static void CheckServers(ServerConfigDto[] servers)
    {
        if (servers == null || servers.Length == 0)
        {
            throw new ArgumentException("Не передан список серверов.");
        }

        foreach (ServerConfigDto server in servers)
        {
            if (!server.IsValid())
            {
                throw new ArgumentException($"Некорректная конфигурация сервера: {server}");
            }
        }
    }

    private sealed class SingleRequestInfo<T>
    {
        public bool Success { get; private init; }

        public T? Value { get; private init; }

        public static SingleRequestInfo<T> CreateSuccess(T value)
        {
            return new SingleRequestInfo<T>
            {
                Success = true,
                Value = value
            };
        }

        public static SingleRequestInfo<T> CreateFail()
        {
            return new SingleRequestInfo<T>
            {
                Success = false,
                Value = default
            };
        }
    }
}
