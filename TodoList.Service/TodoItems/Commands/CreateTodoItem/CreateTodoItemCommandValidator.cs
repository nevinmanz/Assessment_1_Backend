using FluentValidation;
using FluentValidation.Results;

namespace TodoList.Service.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        protected override bool PreValidate(ValidationContext<CreateTodoItemCommand> context, ValidationResult result)
        {
            if (context.InstanceToValidate?.TodoItemDto == null)
            {
                result.Errors.Add(new ValidationFailure("", "TodoItemDto is null"));
                return false;
            }
            return base.PreValidate(context, result);
        }
        public CreateTodoItemCommandValidator()
        {
            RuleFor(r => r).NotNull().WithMessage("Request is null");
            RuleFor(r => r.TodoItemDto.Description).NotEmpty().WithMessage("Description cannot be null");
        }
    }
}
