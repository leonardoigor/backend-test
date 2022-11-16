using BookStore.Domain.Interfaces.Repositories.Base;
using BookStore.Infra.Persistence;
using BookStore.Infra.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Ioc;

public static class DependenciesSolve
{
    public static IServiceCollection SolveDepencies(this IServiceCollection ser)
    {
        ser.AddScoped<BookContext>();
        // ser.AddTransient<IUnitOfWork, UnitOfWork>();

        // add repositories
        ser.AddTransient(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

        // ser.AddTransient<IPostRepository, PostRepository>();

        //add services
        // ser.AddTransient<IPostService, PostService>();
        //ser.AddTransient<IReactionService, ReactionService>();

        return ser;
    }
}
