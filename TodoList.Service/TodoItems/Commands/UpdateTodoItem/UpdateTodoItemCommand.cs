using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Data;
using TodoList.Data.Entities;
using TodoList.Service.Dtos;

namespace TodoList.Service.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommand : IRequest
    {
        public TodoItemDto TodoItemDto { get;set; }
    }

    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
    {
        private readonly TodoContext _context;

        public UpdateTodoItemCommandHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems.FindAsync(request.TodoItemDto.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.TodoItemDto.Id);
            }

            entity.Description = request.TodoItemDto.Description;
            entity.IsCompleted = request.TodoItemDto.IsCompleted;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
