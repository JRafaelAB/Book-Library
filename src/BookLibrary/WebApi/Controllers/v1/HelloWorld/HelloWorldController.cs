using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers.v1.HelloWorld;

[ApiVersion("1.0")]
[ApiController]
[Route("v{version:apiVersion}/[controller]")]
public class HelloWorldController : ValidatorControllerBase
{
    [HttpGet]
    public IActionResult GetHelloWorld()
    {
        return Ok("Hello World!");
    }
}
