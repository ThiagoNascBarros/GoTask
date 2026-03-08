using AutoMapper;
using GoTask.Communication.Requests;
using GoTask.Communication.Response;
using GoTask.Domain.Data.Interface;

namespace GoTask.Application.UseCases.Tasks.Register;

internal class TaskRegisterUseCase : ITaskRegisterUseCase
{
    
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TaskRegisterUseCase(ITaskRepository taskRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRegisterTaskJson> Execute(RequestRegisterTaskJson request, Domain.Entities.User user)
    {
        var entity = _mapper.Map<Domain.Entities.Tasks>(request);
        entity.UserId = user.Id;
        
        await _taskRepository.CreateTaskAsync(entity);
        await _unitOfWork.Commit();
        return _mapper.Map<ResponseRegisterTaskJson>(entity);
    }
}