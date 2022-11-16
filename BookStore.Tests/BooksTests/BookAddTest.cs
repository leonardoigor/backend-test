using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using BookStore.Domain.Services;
using Moq;

namespace BookStore.Tests.BooksTests;

public class BookAddTest
{
    IBookService _bookService;
    IBookRepository _bookRepository;
    [SetUp]
    public void Setup()
    {
        _bookRepository=Mock.Of<IBookRepository>();
        _bookService = new BookService(_bookRepository);
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
