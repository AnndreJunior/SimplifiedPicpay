using Microsoft.AspNetCore.Mvc;

namespace SimplifiedPicPay.Api.Controllers;

[Route("[controller]")]
[ApiController]
public abstract class ApiController : ControllerBase
{
    protected ApiController()
    {
    }

    protected IActionResult HandleFailure(Result result)
    {
        if (result.Error.Type == ErrorType.Failure)
        {
            return Problem(
                title: "InternalServerError",
                detail: "Something went wrong",
                statusCode: GetStatusCode(result.Error.Type));
        }
        var error = result.Error;
        return Problem(
            title: error.Code,
            detail: error.Message,
            statusCode: GetStatusCode(error.Type));
    }

    private static int GetStatusCode(ErrorType type) =>
        type switch
        {
            ErrorType.UnprocessableEntity => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
}
