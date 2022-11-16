using BookStore.Domain.Arguments.Books;
using BookStore.Domain.Entities.Base;
using prmToolkit.NotificationPattern;
using System.ComponentModel.DataAnnotations.Schema;

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
    [NotMapped]
    public List<string> AuthorsList => Authors.Split(',').ToList();
    [NotMapped]
    public List<string> CategoriesList => Categories.Split(',').ToList();

    private void Mapping()
    {
        new AddNotifications<BookEntity>(this)
            .IfNullOrInvalidLength(x => x.Title, 5, 100, "O título deve conter entre 5 e 100 caracteres")
            .IfNullOrInvalidLength(x => x.PublishedDate, 5, 100,
                "A data de publicação deve conter entre 5 e 100 caracteres")
            .IfNullOrInvalidLength(x => x.ShortDescription, 5, 100,
                "A descrição curta deve conter entre 5 e 100 caracteres")
            .IfNullOrInvalidLength(x => x.LongDescription, 5, 100,
                "A descrição longa deve conter entre 5 e 100 caracteres")
            .IfNullOrInvalidLength(x => x.Status, 5, 100, "O status deve conter entre 5 e 100 caracteres")
            .IfNullOrInvalidLength(x => x.Authors, 5, 100, "O autor deve conter entre 5 e 100 caracteres")
            .IfNullOrInvalidLength(x => x.Categories, 5, 100, "A categoria deve conter entre 5 e 100 caracteres");
    }

    public static explicit operator BookEntity(BookAddDTO v)
    {
        if (v.Authors == null)
            v.Authors = new List<string>();
        if (v.Categories == null)
            v.Categories = new List<string>();
        var authors = string.Join(",", v.Authors);
        var categories = string.Join(",", v.Categories);
        return new BookEntity(v.Title, v.PublishedDate, v.ThumbnailUrl, v.ShortDescription, v.LongDescription, v.Status
            , authors, categories);
    }
}
