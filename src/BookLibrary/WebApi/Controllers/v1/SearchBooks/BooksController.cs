using Application.UseCases.SearchBooks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers.v1.SearchBooks;

[ApiVersion("1.0")]
[ApiController]
[Route("v{version:apiVersion}/[controller]")]
public class BooksController : ValidatorControllerBase
{
    private readonly ISearchBooksUseCase _useCase;

    public BooksController(ISearchBooksUseCase useCase)
    {
        _useCase = useCase;
    }
    
    [HttpGet("/{searchKey}/{page:int}")]
    public async Task<IActionResult> SearchBooks([FromRoute] string searchKey, [FromRoute] int page = 1)
    {
        return Ok(await _useCase.Execute(searchKey, page));
    }
}
