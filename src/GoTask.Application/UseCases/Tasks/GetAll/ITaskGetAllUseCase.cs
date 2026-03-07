using GoTask.Communication.Response;

namespace GoTask.Application.UseCases.Tasks.GetAll;

public interface ITaskGetAllUseCase
{
    Task<IEnumerable<ResponseRegisterTaskJson>> Execute(Domain.Entities.User user);
}