using Microsoft.AspNetCore.Mvc;

namespace SimplifiedPicPay.Api.Extensions;

public static class ResultExtensions
{
    public static async Task<Result> Bind<TIn>(
        this Result<TIn> result,
        Func<TIn, Task<Result>> func)
    {
        if (result.IsFailure)
        {
            var error = result.Error;
            return Result.Failure(new Error(
                error.Code,
                error.Message,
                ErrorType.UnprocessableEntity));
        }
        return await func(result.Value);
    }

    public static async Task<Result<TOut>> Bind<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, Task<Result<TOut>>> func)
    {
        if (result.IsFailure)
        {
            var error = result.Error;
            return Result.Failure<TOut>(new Error(
                error.Code,
                error.Message,
                ErrorType.UnprocessableEntity));
        }
        return await func(result.Value);
    }

    public static async Task<IActionResult> Match(
        this Task<Result> resultTask,
        Func<IActionResult> onSuccess,
        Func<Result, IActionResult> onFailure)
    {
        var result = await resultTask;
        return result.IsSuccess ? onSuccess() : onFailure(result);
    }

    public static async Task<IActionResult> Match<TIn>(
        this Task<Result<TIn>> resultTask,
        Func<TIn, IActionResult> onSuccess,
        Func<Result, IActionResult> onFailure)
    {
        var result = await resultTask;
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result);
    }
}
