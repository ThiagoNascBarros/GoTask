using AutoMapper;
using GoTask.Communication.Requests;
using GoTask.Communication.Response;
using GoTask.Domain.Data.Interface;

namespace GoTask.Application.UseCases.Tasks.Update;

public class TaskUpdateUseCase : ITaskUpdateUseCase
{
    
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TaskUpdateUseCase(ITaskRepository taskRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<ResponseUpdateTaskJson> Execute(long id, RequestUpdateTaskJson request)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        var updateEntity = _mapper.Map<Domain.Entities.Tasks>(request);   

        task.Update(updateEntity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseUpdateTaskJson>(task);
    }
    
}