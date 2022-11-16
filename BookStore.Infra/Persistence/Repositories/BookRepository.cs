using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Infra.Persistence.Repositories.Base;

namespace BookStore.Infra.Persistence.Repositories;

public class BookRepository : RepositoryBase<BookEntity, Guid>, IBookRepository
{
    protected readonly BookContext _context;

    public BookRepository(BookContext context) : base(context)
    {
        _context = context;
    }
}
