using System;
using TodoList.Data.Entities;
using TodoList.Service.Mappings;

namespace TodoList.Service.Dtos
{
    public class TodoItemDto : IMapFrom<TodoItem>
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
