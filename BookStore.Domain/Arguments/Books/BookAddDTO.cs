namespace BookStore.Domain.Arguments.Books;

public class BookAddDTO
{
    public string Title { get; set; }
    public string PublishedDate { get; set; }
    public Uri ThumbnailUrl { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string Status { get; set; }
    public string Authors { get; set; }
    public string Categories { get; set; }
}
