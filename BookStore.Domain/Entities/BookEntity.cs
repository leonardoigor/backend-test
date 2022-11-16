using BookStore.Domain.Entities.Base;

namespace BookStore.Domain.Entities;

public class BookEntity : EntityBase
{
    public string Title { get; set; }
    public string Isbn { get; set; }
    public long PageCount { get; set; }
    public string PublishedDate { get; set; }
    public Uri ThumbnailUrl { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string Status { get; set; }
    public string Authors { get; set; }
    public string Categories { get; set; }
}
