using MediatR;

namespace Week3.Queries;

public record GetBookByIdQuery : IRequest<Book>
{
    public int Id { get; set; }
}
