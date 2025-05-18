namespace SimplifiedPicPay.Api.Common.Helpers;

public static class CustomErrors
{
    public static IResult HandleFailure(Result result)
    {
        if (result.Error.Type == ErrorType.Failure)
        {
            return Results.Problem(
                title: "Server error",
                detail: "An unexpected error occurred",
                statusCode: GetStatus(result.Error.Type));
        }
        return Results.Problem(
            title: result.Error.Code,
            detail: result.Error.Message,
            statusCode: GetStatus(result.Error.Type));
    }

    private static int GetStatus(ErrorType type) =>
        type switch
        {
            _ => StatusCodes.Status500InternalServerError
        };
}
