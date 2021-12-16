using System;

namespace TodoList.Data.Entities
{
    public class TodoItem : BaseEntity
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
