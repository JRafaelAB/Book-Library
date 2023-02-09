using Application.UseCases.GetAllBooks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers.v1.GetAllBooks;

[ApiVersion("1.0")]
[ApiController]
[Route("v{version:apiVersion}/[controller]")]
public class BooksController : ValidatorControllerBase
{
    private readonly IGetAllBooksUseCase _useCase;

    public BooksController(IGetAllBooksUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("{page:int}")]
    public async Task<IActionResult> GetAllBooks([FromRoute] int page = 1, [FromQuery] int itemsPerPage = 6)
    {
        return Ok(await _useCase.Execute(page, itemsPerPage));
    }
}
