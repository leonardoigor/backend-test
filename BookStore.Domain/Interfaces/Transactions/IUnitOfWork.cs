namespace BookStore.Domain.Interfaces.Transactions;

public interface IUnitOfWork
{
    void Commit();
}
