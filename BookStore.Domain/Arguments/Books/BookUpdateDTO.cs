using BookStore.Domain.Entities;

namespace BookStore.Domain.Arguments.Books;

public class BookUpdateDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string PublishedDate { get; set; }
    public string ThumbnailUrl { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string Status { get; set; }
    public List<string> Authors { get; set; }
    public List<string> Categories { get; set; }


    public static explicit operator BookUpdateDTO(BookEntity entity)
    {
        return new BookUpdateDTO
        {
            Id = entity.Id,
            Title = entity.Title,
            PublishedDate = entity.PublishedDate,
            ThumbnailUrl = entity.ThumbnailUrl,
            ShortDescription = entity.ShortDescription,
            LongDescription = entity.LongDescription,
            Status = entity.Status
        };
    }
}
