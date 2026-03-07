using FluentValidation;
using GoTask.Communication.Requests;

namespace GoTask.Application.UseCases.Tasks.Register;

public class TaskRegisterValidator : AbstractValidator<RequestRegisterTaskJson>
{
    public TaskRegisterValidator()
    {
        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Status is invalid");
    }
}