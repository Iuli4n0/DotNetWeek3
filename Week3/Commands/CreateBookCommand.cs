using Week3.Database;

namespace Week3.Commands;

using MediatR;
/**
 * Command for creating a new book
 */
public class CreateBookCommand : IRequest<Book>
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Year { get; set; }
}

