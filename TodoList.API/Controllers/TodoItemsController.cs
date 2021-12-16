using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Service.Dtos;
using TodoList.Service.TodoItems.Commands.CreateTodoItem;
using TodoList.Service.TodoItems.Commands.UpdateTodoItem;
using TodoList.Service.TodoItems.Queries.GetTodoItemById;

namespace TodoList.API.Controllers
{
    [ApiController]
    [Route("v1/todoitems")]
    public class TodoItemsController : ControllerBase
    {
        private readonly ISender _mediatR;
        private readonly ILogger<TodoItemsController> _logger;

        public TodoItemsController(ISender mediator, ILogger<TodoItemsController> logger)
        {
            _mediatR = mediator;
            _logger = logger;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<List<TodoItemDto>>> GetTodoItems()
        {
            var results = await _mediatR.Send(new GetTodoItemListQuery { IsCompleted = null });
            return Ok(results);
        }

        // GET: api/TodoItems/...
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(Guid id)
        {
            var result = await _mediatR.Send(new GetTodoItemByIdQuery { Id = id });

            return Ok(result);
        }

        // PUT: api/TodoItems/... 
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTodoItem(Guid id, [FromBody] TodoItemDto todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            await _mediatR.Send(new UpdateTodoItemCommand
            {
                TodoItemDto = todoItem
            });

            return NoContent();
        }

        // POST: api/TodoItems 
        [HttpPost]
        public async Task<ActionResult<Guid>> PostTodoItem([FromBody] TodoItemDto todoItem)
        {
            return await _mediatR.Send(new CreateTodoItemCommand
            {
                TodoItemDto = todoItem
            });
        }
    }
}
