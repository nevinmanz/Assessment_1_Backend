using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Data.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsActive = true;
        }
        [Key]
        public virtual Guid Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
    }
}
