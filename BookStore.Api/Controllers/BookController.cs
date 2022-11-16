using BookStore.Api.Controllers.Base;
using BookStore.Domain.Arguments.Books;
using BookStore.Domain.Interfaces.Services;
using BookStore.Domain.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBaseApiController
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _service;

    public BookController(ILogger<BookController> logger, IUnitOfWork transaction, IBookService service)
        : base(transaction)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet(Name = "getAllBooks")]
    public IEnumerable<BookUpdateDTO> Get(int page, int size)
    {
        return _service.GetAll(page, size);
    }
}
