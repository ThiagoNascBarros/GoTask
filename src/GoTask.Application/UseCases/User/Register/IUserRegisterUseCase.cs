using GoTask.Communication.Requests;
using GoTask.Communication.Response;

namespace GoTask.Application.UseCases.User.Register
{
    public interface IUserRegisterUseCase
    {
        Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
    }
}
