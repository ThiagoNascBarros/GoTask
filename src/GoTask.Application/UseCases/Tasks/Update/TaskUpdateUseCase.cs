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
    
    public async Task<ResponseUpdateTaskJson> Execute(RequestUpdateTaskJson request)
    {
        var task = _taskRepository.GetAsync(request.Title);
        
        task.Result.Update(new Domain.Entities.Tasks
        {
            Title = request.Title,
            Description = request.Description,
            Status = request.Status
        });

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseUpdateTaskJson>(task.Result);
    }
}