﻿namespace BookStore.Domain.Arguments.Books;

public class BookUpdateDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string PublishedDate { get; set; }
    public Uri ThumbnailUrl { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string Status { get; set; }
    public List<string> Authors { get; set; }
    public List<string> Categories { get; set; }
}
