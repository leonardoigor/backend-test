using BookStore.Domain.Arguments.Books;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using BookStore.Domain.Services;
using Moq;

namespace BookStore.Tests.BooksTests;

public class BookAddTest
{
    private IBookRepository _bookRepository;
    private IBookService _bookService;

    [SetUp]
    public void Setup()
    {
        _bookRepository = Mock.Of<IBookRepository>();
        _bookService = new BookService(_bookRepository);
    }

    [Test]
    public void MustReturnFalseWithErrorNotificationIfPassNullOrInvalidRequest()
    {
        var result = _bookService.Add(null);
        Assert.IsFalse(result);
        Assert.IsTrue(_bookService.Notifications.Any());
        _bookService.ClearNotifications();
        var request = new BookAddDTO();
        result = _bookService.Add(request);
        Assert.IsFalse(result);
        Assert.IsTrue(_bookService.Notifications.Any());
    }

    [Test]
    public void MustReturnTrueWithoutErrorNotificationIfIsValid()
    {
        // Mock add
        Mock.Get(_bookRepository).Setup(x => x.Add(It.IsAny<BookEntity>())).Returns(new BookEntity());
        _bookService.ClearNotifications();
        var request = new BookAddDTO
        {
            Title = " Test Test Test", Authors = new List<string> { "Test", "ttt", "sss" },
            Categories = new List<string> { "aaa", "ss", "bb" },
            Status = "Available",
            LongDescription = " Test Test Test",
            PublishedDate = "2021-01-01",
            ShortDescription = " Test Test Test",
            ThumbnailUrl = new Uri("https://www.c.com")
        };
        var result = _bookService.Add(request);
        Assert.IsTrue(result);
        Assert.IsFalse(_bookService.Notifications.Any());
    }


    [TearDown]
    public void TearDown()
    {
        _bookRepository = null;
        _bookService = null;
    }
}
