using MediatR;
using Microsoft.EntityFrameworkCore;
using Week3.Database;
using Week3.Queries;

namespace Week3.Handlers;
/**
 * Handler for processing command
 */
public class GetBooksQueryHandler(AppDbContext context) : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
{
    public async Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var query = context.Books.AsQueryable();

        // Filtering
        if (!string.IsNullOrWhiteSpace(request.Author))
        {
            query = query.Where(b => b.Author.Contains(request.Author));
        }

        // Sorting with injection protection
        query = request.SortBy?.ToLower() switch
        {
            "title" => request.Desc ? query.OrderByDescending(b => b.Title) : query.OrderBy(b => b.Title),
            "year" => request.Desc ? query.OrderByDescending(b => b.Year) : query.OrderBy(b => b.Year),
            "author" => request.Desc ? query.OrderBy(b => b.Author) : query.OrderBy(b => b.Author),
            _ => query.OrderBy(b => b.Id) // fallback
        };

        // Pagination
        query = query.Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize);

        return await query.ToListAsync(cancellationToken);
    }
}
