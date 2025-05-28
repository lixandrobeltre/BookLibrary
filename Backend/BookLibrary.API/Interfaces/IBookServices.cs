using BookLibrary.API.DTOs;

namespace BookLibrary.API.Interfaces;

public interface IBookServices
{
    Task<(IEnumerable<BookDto> Results, int Total)> SearchAsync(SearchDto search);
    Task<Guid> AddAsync(BookDto book);
}
