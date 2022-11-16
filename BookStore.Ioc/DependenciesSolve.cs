using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Repositories.Base;
using BookStore.Domain.Interfaces.Services;
using BookStore.Domain.Interfaces.Transactions;
using BookStore.Domain.Services;
using BookStore.Infra.Persistence;
using BookStore.Infra.Persistence.Repositories;
using BookStore.Infra.Persistence.Repositories.Base;
using BookStore.Infra.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Ioc;

public static class DependenciesSolve
{
    public static IServiceCollection SolveDepencies(this IServiceCollection ser)
    {
        ser.AddScoped<BookContext>();
        ser.AddTransient<IUnitOfWork, UnitOfWork>();

        // add repositories
        ser.AddTransient(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

        ser.AddTransient<IBookRepository, BookRepository>();

        //add services
        ser.AddTransient<IBookService, BookService>();

        return ser;
    }
}
