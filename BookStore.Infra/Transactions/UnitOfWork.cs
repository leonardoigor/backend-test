using BookStore.Domain.Interfaces.Transactions;
using BookStore.Infra.Persistence;

namespace BookStore.Infra.Transactions;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookContext _context;

    public UnitOfWork(BookContext context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
}
