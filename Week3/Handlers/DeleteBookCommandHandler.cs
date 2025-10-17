using MediatR;
using Week3.Commands;
using Week3.Database;
using Week3.Exceptions;

namespace Week3.Handlers;
/**
 * Handler for processing command
 */
public class DeleteBookCommandHandler(AppDbContext context) : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FindAsync([request.Id], cancellationToken);
        if (book == null)
            throw new NotFoundException($"Book with id {request.Id} not found.");

        context.Books.Remove(book);
        await context.SaveChangesAsync(cancellationToken);
    }
}