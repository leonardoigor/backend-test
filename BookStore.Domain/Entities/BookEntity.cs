using BookStore.Domain.Entities.Base;
using prmToolkit.NotificationPattern;

namespace BookStore.Domain.Entities;

public class BookEntity : EntityBase
{
    public BookEntity(string title, string publishedDate, Uri thumbnailUrl, string shortDescription,
        string longDescription, string status, string authors, string categories)
    {
        Title = title;
        PublishedDate = publishedDate;
        ThumbnailUrl = thumbnailUrl;
        ShortDescription = shortDescription;
        LongDescription = longDescription;
        Status = status;
        Authors = authors;
        Categories = categories;
        Mapping();
    }

    public BookEntity()
    {
        Mapping();
    }

    public string Title { get; set; }
    public string PublishedDate { get; set; }
    public Uri ThumbnailUrl { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string Status { get; set; }
    public string Authors { get; set; }
    public string Categories { get; set; }
    public List<string> AuthorsList => Authors.Split(',').ToList();
    public List<string> CategoriesList => Categories.Split(',').ToList();

    private void Mapping()
    {
        new AddNotifications<BookEntity>(this)
            .IfLengthGreaterThan(x => x.Title, 100, "O título deve conter no máximo 100 caracteres");
    }
}
