using GoTask.Domain.Data.Interface;

namespace GoTask.Application.UseCases.Tasks.Delete
{
    internal class TaskDeleteUseCase : ITaskDeleteUseCase
    {

        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TaskDeleteUseCase(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long id)
        {
            var task = await _taskRepository.Delete(id);
            await _unitOfWork.Commit();
        }
    }
}
