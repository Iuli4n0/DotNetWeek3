using MediatR;
using Week3.Commands;
using Week3.Database;
using Week3.Exceptions;

namespace Week3.Handlers;
/**
 * Handler for processing command
 */
public class UpdateBookCommandHandler(AppDbContext context) : IRequestHandler<UpdateBookCommand>
{
    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FindAsync([request.Id], cancellationToken);
        if (book == null)
            throw new NotFoundException($"Book with id {request.Id} not found.");

        book.Title = request.Title;
        book.Author = request.Author;
        book.Year = request.Year;

        await context.SaveChangesAsync(cancellationToken);
    }
}