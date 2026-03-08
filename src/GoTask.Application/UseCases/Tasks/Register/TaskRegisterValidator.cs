using FluentValidation;
using GoTask.Communication.Requests;

namespace GoTask.Application.UseCases.Tasks.Register;

public class TaskRegisterValidator : AbstractValidator<RequestRegisterTaskJson>
{
    public TaskRegisterValidator()
    {
        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Status está invalido");
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Título é obrigatório");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Descrição é obrigatória");
    }
}