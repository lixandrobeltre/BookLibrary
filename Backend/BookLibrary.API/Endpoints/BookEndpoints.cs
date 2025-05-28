using BookLibrary.API.DTOs;
using BookLibrary.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.API.Controllers;

public static class BookEndpoints
{
    public static void MapBookEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/books/search", async (string? author, string? isbn, string? ownershipStatus, int page, int pageSize, [FromServices] IBookServices bookService) =>
        {
            try
            {
                var (results, total) = await bookService.SearchAsync(new SearchDto(author, isbn, 0) { Page = page, PageSize = pageSize });
                return Results.Ok(new { total, results });
            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500, title: "An unexpected error occurred while searching for books.");
            }
        });

        app.MapPost("/api/books", async ([FromBody] BookDto bookDto, [FromServices] IBookServices bookService) =>
        {
            try
            {
                if (string.IsNullOrWhiteSpace(bookDto.Title) || string.IsNullOrWhiteSpace(bookDto.FirstName) || string.IsNullOrWhiteSpace(bookDto.LastName))
                    return Results.BadRequest("Title, FirstName, and LastName are required.");

                var rowId = await bookService.AddAsync(bookDto);
                return Results.Created($"/api/books/{rowId}", bookDto);
            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500, title: "An error occurred while adding the book.");
            }
        });
    }
}
