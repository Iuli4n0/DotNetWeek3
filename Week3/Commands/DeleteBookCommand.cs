using Week3.Database;
using Week3.Exceptions;

namespace Week3.Commands;

using MediatR;
/**
 * Command for deleting a book
 */
public class DeleteBookCommand : IRequest
{
    public int Id { get; set; }
}


