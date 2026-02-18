using GoTask.Communication.Requests;

namespace GoTask.Application.UseCases.User.Register
{
    public interface IUserRegisterUseCase
    {
        System.Threading.Tasks.Task Execute(RequestRegisterUserJson request);
    }
}
