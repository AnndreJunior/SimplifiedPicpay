using Microsoft.AspNetCore.Mvc;

namespace SimplifiedPicPay.Api.Controllers;

[Route("[controller]")]
[ApiController]
public abstract class ApiController : ControllerBase
{
    protected ApiController()
    {
    }
}
