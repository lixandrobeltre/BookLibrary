using BookLibrary.API.Data;
using BookLibrary.API.Data.Models;
using BookLibrary.API.DTOs;
using BookLibrary.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.API.Services;

public class BookServices : IBookServices
{
    private readonly BLContext _context;
    public BookServices(BLContext context) => _context = context;

    public async Task AddAsync(BookDto book)
    {
        var entity = new Book
        {
            Title = book.Title,
            FirstName = book.FirstName,
            LastName = book.LastName,
            TotalCopies = book.TotalCopies,
            CopiesInUse = book.CopiesInUse,
            GenderType = book.GenderType,
            Isbn = book.Isbn,
            Category = book.Category,
            MarkAs = book.MarkAs,
            CreatedDate = DateTime.UtcNow,
            RowId = Guid.NewGuid()
        };

        _context.Books.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<(IEnumerable<BookDto> Results, int Total)> SearchAsync(SearchDto search)
    {
        var query = _context.Books.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search.Author))
            query = query.Where(b => (b.FirstName + " " + b.LastName).Contains(search.Author));

        if (!string.IsNullOrWhiteSpace(search.Isbn))
            query = query.Where(b => b.Isbn == search.Isbn);

        if (search.MarkAs > 0)
            query = query.Where(b => b.MarkAs == search.MarkAs);

        var total = await query.CountAsync();
        var results = await query.Skip((search.Page - 1) * search.PageSize).Take(search.PageSize)
            .Select(s => new BookDto
            {
                Title = s.Title,
                FirstName = s.FirstName,
                LastName = s.LastName,
                TotalCopies = s.TotalCopies,
                CopiesInUse = s.CopiesInUse,
                GenderType = s.GenderType,
                Isbn = s.Isbn,
                Category = s.Category,
                MarkAs = s.MarkAs,
                RowId = s.RowId
            }).ToListAsync();

        return (results, total);
    }
}
