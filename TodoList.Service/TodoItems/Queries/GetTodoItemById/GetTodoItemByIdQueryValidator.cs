using FluentValidation;
using System;

namespace TodoList.Service.TodoItems.Queries.GetTodoItemById
{
    public class GetTodoItemByIdQueryValidator : AbstractValidator<GetTodoItemByIdQuery>
    {
        public GetTodoItemByIdQueryValidator()
        {
            RuleFor(r => r).NotNull().WithMessage("Request is null");
            RuleFor(r => r.Id).NotEqual(default(Guid)).WithMessage("Id should not be default value.");
        }
    }
}
