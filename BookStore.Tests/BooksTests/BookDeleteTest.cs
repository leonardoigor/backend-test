using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using BookStore.Domain.Services;
using Moq;

namespace BookStore.Tests.BooksTests;

public class BookDeleteTest
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
        var result = _bookService.Delete(Guid.Empty);
        Assert.IsFalse(result);
        Assert.IsTrue(_bookService.Notifications.Any());
        _bookService.ClearNotifications();
    }

    [Test]
    public void MustReturnTrueWithoutErrorNotificationIfIsValid()
    {
        Mock.Get(_bookRepository).Setup(x => x.GetById(It.IsAny<Guid>())).Returns(new BookEntity());
        Mock.Get(_bookRepository).Setup(x => x.Remove(It.IsAny<BookEntity>())).Returns(true);
        _bookService.ClearNotifications();

        var result = _bookService.Delete(Guid.NewGuid());
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
