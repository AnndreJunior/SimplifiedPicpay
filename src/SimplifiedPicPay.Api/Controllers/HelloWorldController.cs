using Microsoft.AspNetCore.Mvc;

namespace SimplifiedPicPay.Api.Controllers;

[Route("hello-world")]
public class HelloWorldController : ApiController
{
    [HttpGet]
    public string SayHello()
    {
        return "Hello World!";
    }
}
