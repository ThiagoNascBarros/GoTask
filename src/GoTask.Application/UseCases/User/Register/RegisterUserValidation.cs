using FluentValidation;
using GoTask.Communication.Requests;
using System.Text.RegularExpressions;

namespace GoTask.Application.UseCases.User.Register
{
    public class RegisterUserValidation : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidation()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Nome não pode estar em branco");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email não é valido");
            RuleFor(x => x.Password).Must(ValidPasswordFormat).WithMessage("Senha deve conter ao mínimo 1 caracter especial e 1 número");
        }

        private bool ValidPasswordFormat(string pass)
        {
            if (string.IsNullOrWhiteSpace(pass)) return false;

            var regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*[\W_]).{8,}$");

            return regex.IsMatch(pass);
        }
    }
}
