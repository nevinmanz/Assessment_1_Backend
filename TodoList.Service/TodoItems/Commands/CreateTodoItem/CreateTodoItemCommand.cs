using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Data;
using TodoList.Data.Entities;
using TodoList.Service.Dtos;

namespace TodoList.Service.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<Guid>
    {
        public TodoItemDto TodoItemDto { get; set; }
    }
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Guid>
    {
        private readonly TodoContext _context;

        public CreateTodoItemCommandHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem
            {
                Description = request.TodoItemDto.Description,
                IsCompleted = request.TodoItemDto.IsCompleted
            };
            await _context.AddAsync(todoItem);
            await _context.SaveChangesAsync(cancellationToken);
            return todoItem.Id;
        }
    }
}
