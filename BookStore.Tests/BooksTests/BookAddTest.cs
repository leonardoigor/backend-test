using BookStore.Domain.Arguments.Books;
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
    public void MustReturnFalseWithErrorNotificationIfPassNullOrInvalidRequest()
    {
        bool result=_bookService.Add(null);
        Assert.IsFalse(result);
        Assert.IsTrue(_bookService.Notifications.Any());
        _bookService.ClearNotifications();
        BookAddDTO request = new BookAddDTO();
        result=_bookService.Add(request);
        Assert.IsFalse(result);
        Assert.IsTrue(_bookService.Notifications.Any());
        Assert.Pass();
    }



    [TearDown]
    public void TearDown()
    {
        _bookRepository = null;
        _bookService = null;
    }
}
