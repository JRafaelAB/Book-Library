using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers.v1.SearchBooks;

[ApiVersion("1.0")]
[ApiController]
[Route("v{version:apiVersion}/[controller]")]
public class BooksController : ValidatorControllerBase
{
    [HttpGet]
    public IActionResult GetHelloWorld()
    {
        return Ok("Hello World!");
    }
}
