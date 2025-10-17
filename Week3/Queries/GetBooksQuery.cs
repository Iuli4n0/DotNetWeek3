using MediatR;

namespace Week3.Queries;

public record GetBooksQuery : IRequest<IEnumerable<Book>>
{
    public string? Author { get; set; }
    public string? SortBy { get; set; }
    public bool Desc { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}