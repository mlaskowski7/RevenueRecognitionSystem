using Microsoft.Data.SqlClient;
using RevenueRecognitionSystem.Application.Utils;

namespace RevenueRecognitionSystem.Infrastructure.Utils;

public static class DbOperationsUtils
{
    public static async Task<(TResult?, Error?)> TryAsync<TResult>(Func<Task<TResult?>> action) where TResult : class
    {
        try
        {
            var result = await action();
            return (result, null);
        }
        catch (SqlException)
        {
            return (null, Error.ServerError("Unexpected exception occurred during db access"));
        }
    }

    public static async Task<Error?> TryAsync(Func<Task> action)
    {
        try
        {
            await action();
            return null;
        }
        catch (SqlException)
        {
            return Error.ServerError("Unexpected exception occurred during db access");
        }
    }
}