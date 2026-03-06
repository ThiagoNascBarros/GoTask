using AutoMapper;
using GoTask.Communication.Response;
using GoTask.Domain.Data.Interface;

namespace GoTask.Application.UseCases.Tasks.GetAll;

internal class TaskGetAllUseCase : ITaskGetAllUseCase
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    public TaskGetAllUseCase(ITaskRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ResponseRegisterTaskJson>> Execute()
    {
        var tasks = await _repository.GetAllAsync();
        var dto = tasks.Select(t => new ResponseRegisterTaskJson
        (
            t.Title,
            t.Description,
            t.Status
        ));

        return dto;
    }
}