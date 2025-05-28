namespace BookLibrary.API.Data.Models;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int TotalCopies { get; set; }
    public int CopiesInUse { get; set; }
    public string? GenderType { get; set; }
    public string? Isbn { get; set; }
    public string? Category { get; set; }
    public short MarkAs { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public Guid RowId { get; set; }
}
