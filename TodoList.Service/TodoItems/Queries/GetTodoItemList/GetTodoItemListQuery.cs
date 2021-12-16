using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Data;
using TodoList.Service.Dtos;

namespace TodoList.Service.TodoItems.Queries.GetTodoItemById
{
    public class GetTodoItemListQuery : IRequest<List<TodoItemDto>>
    {
        public bool? IsCompleted { get; set; }
    }

    public class GetTodoItemListQueryHandler : IRequestHandler<GetTodoItemListQuery, List<TodoItemDto>>
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public GetTodoItemListQueryHandler(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TodoItemDto>> Handle(GetTodoItemListQuery request, CancellationToken cancellationToken)
        {
            return await _context.TodoItems
                .Where(r => request.IsCompleted == null || r.IsCompleted == request.IsCompleted)
                .OrderBy(r=>r.IsCompleted)
                .ThenByDescending(r=>r.CreatedAt)
                .ProjectTo<TodoItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
