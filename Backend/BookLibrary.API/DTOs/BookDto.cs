namespace BookLibrary.API.DTOs;

public class BookDto
{
    public string Title { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int TotalCopies { get; set; }
    public int CopiesInUse { get; set; }
    public string? GenderType { get; set; }
    public string? Isbn { get; set; }
    public string? Category { get; set; }
    public short MarkAs { get; set; }
    public Guid RowId { get; set; }

    public string OwnershipStatus => MarkAs switch
    {
        1 => "Own",
        2 => "Love",
        3 => "Want to Read",
        _ => "None"
    };

    public string AvailableCopies => $"{CopiesInUse}/{TotalCopies}";
}