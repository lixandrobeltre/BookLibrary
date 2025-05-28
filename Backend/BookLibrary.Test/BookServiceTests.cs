using BookLibrary.API.Data;
using BookLibrary.API.Data.Models;
using BookLibrary.API.DTOs;
using BookLibrary.API.Services;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Test;

public class BookServiceTests
{
    private static BLContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<BLContext>()
            .UseInMemoryDatabase(databaseName: "BookLibraryTestDb")
            .Options;

        return new BLContext(options);
    }

    [Fact]
    public async Task AddAsync_AddsBookSuccessfully()
    {
        var context = GetDbContext();
        var service = new BookServices(context);

        var bookDto = new BookDto
        {
            Title = "Test Book",
            FirstName = "John",
            LastName = "Doe",
            Isbn = "1234567890",
            TotalCopies = 5,
            CopiesInUse = 2,
            GenderType = "Fiction",
            Category = "Novel",
            MarkAs = 1
        };

        var rowId = await service.AddAsync(bookDto);

        var book = await context.Books.FirstOrDefaultAsync(f => f.RowId == rowId);
        Assert.NotNull(book);
        Assert.Equal("Test Book", book.Title);
    }

    [Fact]
    public async Task SearchAsync_ReturnsMatchingBooks()
    {
        var context = GetDbContext();
        context.Books.Add(new Book
        {
            Title = "Love Story",
            FirstName = "Jane",
            LastName = "Austen",
            Isbn = "9876543210",
            MarkAs = 2
        });
        await context.SaveChangesAsync();

        var service = new BookServices(context);
        var search = new SearchDto("Jane", null, 2)
        {
            Page = 1,
            PageSize = 10
        };

        var result = await service.SearchAsync(search);

        Assert.Single(result.Results);
        Assert.Equal("Love Story", result.Results.First().Title);
    }
}
