using GoTask.Communication.Requests;
using GoTask.Communication.Response;

namespace GoTask.Application.UseCases.Tasks.Register;

public interface ITaskRegisterUseCase
{
    Task<ResponseRegisterTaskJson> Execute(RequestRegisterTaskJson request);
}