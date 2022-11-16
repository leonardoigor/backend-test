using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;

namespace BookStore.Domain.Services;

public class BookService:Notifiable,IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
}
