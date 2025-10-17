using Week3.Commands;
using Week3.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Week3.Controllers
{
    /**
     * Controller for implementing CRUD operations on books
     */
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // Get with filtering & sorting
        [HttpGet]
        public async Task<IActionResult> GetBooks(
            [FromQuery] string? author,
            [FromQuery] string? sortBy,
            [FromQuery] bool desc = false,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = new GetBooksQuery
            {
                Author = author,
                SortBy = sortBy,
                Desc = desc,
                Page = page,
                PageSize = pageSize
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // Get by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var result = await _mediator.Send(new GetBookByIdQuery { Id = id });
            return Ok(result);
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBook), new { id = result.Id }, result);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _mediator.Send(new DeleteBookCommand { Id = id });
            return NoContent();
        }
    }
}
