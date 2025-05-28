using BookLibrary.API.Data.Models;

namespace BookLibrary.API.Interfaces
{
    public interface IBookServices
    {
        Task<IEnumerable<Book>> SearchAsync(string? author, string? isbn, string? ownershipStatus, int page, int pageSize);
        Task<int> CountAsync(string? author, string? isbn, string? ownershipStatus);
        Task AddAsync(Book book);
    }
}
