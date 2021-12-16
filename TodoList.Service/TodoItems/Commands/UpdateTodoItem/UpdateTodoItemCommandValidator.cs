using FluentValidation;
using FluentValidation.Results;
using System;

namespace TodoList.Service.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
    {
        protected override bool PreValidate(ValidationContext<UpdateTodoItemCommand> context, ValidationResult result)
        {
            if (context.InstanceToValidate?.TodoItemDto == null)
            {
                result.Errors.Add(new ValidationFailure("", "TodoItemDto is null"));
                return false;
            }
            return base.PreValidate(context, result);
        }
        public UpdateTodoItemCommandValidator()
        {
            RuleFor(v => v).NotNull().WithMessage("Request is null");
            RuleFor(v => v.TodoItemDto.Id).NotEqual(default(Guid)).WithMessage("Guid should not be default value");
            RuleFor(v => v.TodoItemDto.Description)
                .NotEmpty().WithMessage("Description is required.");
        }
    }
}
