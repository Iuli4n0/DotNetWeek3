using MediatR;
using Week3.Database;
using Week3.Exceptions;
using Week3.Queries;

namespace Week3.Handlers;

public class GetBookByIdQueryHandler(AppDbContext context) : IRequestHandler<GetBookByIdQuery, Book>
{
    public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FindAsync(new object[] { request.Id }, cancellationToken);

        if (book == null)
            throw new NotFoundException($"Book with id {request.Id} not found.");

        return book;
    }
}
