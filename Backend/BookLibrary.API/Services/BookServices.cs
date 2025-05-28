using BookLibrary.API.Data;
using BookLibrary.API.Data.Models;
using BookLibrary.API.Interfaces;

namespace BookLibrary.API.Services;

public class BookServices : IBookServices
{
    private readonly BLContext _context;
    public BookServices(BLContext context) => _context = context;

    public Task AddAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync(string? author, string? isbn, string? ownershipStatus)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> SearchAsync(string? author, string? isbn, string? ownershipStatus, int page, int pageSize)
    {
        throw new NotImplementedException();
    }
}
