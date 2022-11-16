using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories.Base;

namespace BookStore.Domain.Interfaces.Repositories;

public interface IBookRepository : IRepositoryBase<BookEntity, Guid>

{
}
