using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Service.Dtos;
using TodoList.Service.TodoItems.Commands.CreateTodoItem;
using TodoList.Service.TodoItems.Commands.UpdateTodoItem;
using TodoList.Service.TodoItems.Queries.GetTodoItemById;

namespace TodoList.UnitTests
{
    public class ValidatorTests
    {
        [Test]
        public void ShouldHaveValidGetTodoItemByIdQuery()
        {
            var obj = new GetTodoItemByIdQuery
            {
                Id = Guid.NewGuid()
            };
            var res = new GetTodoItemByIdQueryValidator().Validate(obj);
            res.IsValid.Should().BeTrue();
        }
        [Test]
        public void ShouldNotHaveValidGetTodoItemByIdQuery()
        {
            var obj = new GetTodoItemByIdQuery
            {
                Id = default(Guid)
            };
            var res = new GetTodoItemByIdQueryValidator().Validate(obj);
            res.IsValid.Should().BeFalse();
        }

        [Test]
        public void ShouldHaveValidUpdateTodoItemCommandValidator()
        {
            var obj = new UpdateTodoItemCommand
            {
                TodoItemDto = new TodoItemDto
                {
                    Id = Guid.NewGuid(),
                    Description = "Test",
                    IsCompleted = false
                }
            };
            var res = new UpdateTodoItemCommandValidator().Validate(obj);
            res.IsValid.Should().BeTrue();
        }

        [Test]
        public void ShouldNotHaveValidUpdateTodoItemCommandValidator()
        {
            var obj = new UpdateTodoItemCommand
            {
                TodoItemDto = new TodoItemDto
                {
                    Description = "Test",
                    IsCompleted = false
                }
            };
            var res = new UpdateTodoItemCommandValidator().Validate(obj);
            res.IsValid.Should().BeFalse();

            obj = new UpdateTodoItemCommand
            {
                TodoItemDto = null
            };
            res = new UpdateTodoItemCommandValidator().Validate(obj);
            res.IsValid.Should().BeFalse();

            obj = new UpdateTodoItemCommand
            {
                TodoItemDto = new TodoItemDto
                {
                    Id = Guid.NewGuid(),
                    Description = null,
                    IsCompleted = false
                }
            };
            res = new UpdateTodoItemCommandValidator().Validate(obj);
            res.IsValid.Should().BeFalse();
        }

        [Test]
        public void ShouldHaveValidCreateTodoItemCommandValidator()
        {
            var obj = new CreateTodoItemCommand
            {
                TodoItemDto = new TodoItemDto
                {
                    Description = "Test",
                    IsCompleted = false
                }
            };
            var res = new CreateTodoItemCommandValidator().Validate(obj);
            res.IsValid.Should().BeTrue();
        }

        [Test]
        public void ShouldNotHaveValidCreateTodoItemCommandValidator()
        {
            var obj = new CreateTodoItemCommand
            {
                TodoItemDto = new TodoItemDto
                {
                    Description = "",
                    IsCompleted = false
                }
            };
            var res = new CreateTodoItemCommandValidator().Validate(obj);
            res.IsValid.Should().BeFalse();

            obj = new CreateTodoItemCommand
            {
                TodoItemDto = null
            };
            res = new CreateTodoItemCommandValidator().Validate(obj);
            res.IsValid.Should().BeFalse();
        }
    }
}
