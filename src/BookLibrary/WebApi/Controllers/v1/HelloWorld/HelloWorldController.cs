using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers.v1.HelloWorld;

[ApiController]
[Route("[controller]")]
public class HelloWorldController : ValidatorControllerBase
{
    [HttpGet]
    public IActionResult GetHelloWorld()
    {
        return Ok("Hello World!");
    }
}
