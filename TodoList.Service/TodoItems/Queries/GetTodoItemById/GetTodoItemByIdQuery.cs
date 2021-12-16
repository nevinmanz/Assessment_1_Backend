using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Data;
using TodoList.Data.Entities;
using TodoList.Service.Dtos;

namespace TodoList.Service.TodoItems.Queries.GetTodoItemById
{
    public class GetTodoItemByIdQuery : IRequest<TodoItemDto>
    {
        public Guid Id { get; set; }
    }

    public class GetTodoItemByIdQueryHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItemDto>
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public GetTodoItemByIdQueryHandler(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TodoItemDto> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            TodoItem todoItem = await _context.TodoItems.FindAsync(request.Id);
            if (todoItem is null)
            {
                throw new NotFoundException($"TodoItem (id: {request.Id}) not existing");
            }
            var dto = _mapper.Map<TodoItemDto>(todoItem);
            return dto;
        }
    }
}
