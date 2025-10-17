using MediatR;
using Week3.Commands;
using Week3.Database;

namespace Week3.Handlers;
/**
 * Handler for processing command
 */
public class CreateBookCommandHandler(AppDbContext context) : IRequestHandler<CreateBookCommand, Book>
{
    public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Year = request.Year
        };

        context.Books.Add(book);
        await context.SaveChangesAsync(cancellationToken);
        return book;
    }
}