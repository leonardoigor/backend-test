using BookStore.Domain.Arguments.Books;
using BookStore.Domain.Interfaces.Services.Base;

namespace BookStore.Domain.Interfaces.Services;

public interface IBookService : IServiceBase
{
    bool Add(BookAddDTO bookAddDTO);
    bool Delete(Guid guid);
    bool Update(BookUpdateDTO request);
}
