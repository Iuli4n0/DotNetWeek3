using Week3.Database;
using Week3.Exceptions;

namespace Week3.Commands;

using MediatR;

/**
 * Command for updating a book
 */
public class UpdateBookCommand : IRequest
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Year { get; set; }
}

