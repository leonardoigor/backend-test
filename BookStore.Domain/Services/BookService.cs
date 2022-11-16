using BookStore.Domain.Arguments.Books;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;

namespace BookStore.Domain.Services;

public class BookService : Notifiable, IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public bool Add(BookAddDTO bookAddDTO)
    {
        if(bookAddDTO == null)
        {
            AddNotification("Book", "Livro não informado");
            return false;
        }
        var book = (BookEntity)bookAddDTO;

        if (book.IsInvalid())
        {
            AddNotifications(book);
            return false;
        }
        var result= _bookRepository.Add(book);
        if (result == null)
        {
            AddNotification("Book", "Livro não cadastrado");
            return false;
        }

        return true;
    }
}
