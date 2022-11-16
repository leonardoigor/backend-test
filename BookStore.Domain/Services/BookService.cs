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
        if (bookAddDTO == null)
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

        var result = _bookRepository.Add(book);
        if (result == null)
        {
            AddNotification("Book", "Livro não cadastrado");
            return false;
        }

        return true;
    }

    public bool Delete(Guid guid)
    {
        var book = _bookRepository.GetById(guid);
        if (book == null || guid == Guid.Empty)
        {
            AddNotification("Book", "Livro não encontrado");
            return false;
        }

        return _bookRepository.Remove(book);
    }


    public bool Update(BookUpdateDTO request)
    {
        BookEntity book;
        if (request == null || request.Id == Guid.Empty)
        {
            AddNotification("Book", "Livro não informado");
            return false;
        }

        book = _bookRepository.GetById(request.Id);
        if (book == null)
        {
            AddNotification("Book", "Livro não encontrado");
            return false;
        }

        book.Authors = string.Join(",", request.Authors.ToArray());
        book.Title = request.Title;
        book.Categories = string.Join(",", request.Categories.ToArray());
        book.Status = request.Status;
        book.LongDescription = request.LongDescription;
        book.PublishedDate = request.PublishedDate;
        book.ShortDescription = request.ShortDescription;
        book.ThumbnailUrl = request.ThumbnailUrl;
        var result = _bookRepository.Edit(book);
        if (result == null)
        {
            AddNotification("Book", "Livro não atualizado");
            return false;
        }

        return true;
    }

    public List<BookUpdateDTO> GetAll(int page, int pageSize)
    {
        var books = _bookRepository.List();
        var total = books.Count();
        var totalPages = (int)Math.Ceiling((double)total / pageSize);
        var booksPage = books.OrderByDescending(x => x.Title).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return booksPage.Select(x => (BookUpdateDTO)x).ToList();
    }
}
