using GoTask.Communication.Requests;
using GoTask.Communication.Response;

namespace GoTask.Application.UseCases.User.Login
{
    public interface IUserLoginUseCase
    {
        Task<ResponseLoginUserJson> Execute(RequestLoginUserJson request);
    }
}
