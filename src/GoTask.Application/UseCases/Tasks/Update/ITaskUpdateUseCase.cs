using GoTask.Application.UseCases.Tasks.GetAll;
using GoTask.Communication.Requests;
using GoTask.Communication.Response;

namespace GoTask.Application.UseCases.Tasks.Update;

public interface ITaskUpdateUseCase
{
    Task<ResponseUpdateTaskJson> Execute(long id, RequestUpdateTaskJson request);
}