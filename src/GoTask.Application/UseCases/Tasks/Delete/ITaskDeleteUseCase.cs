namespace GoTask.Application.UseCases.Tasks.Delete
{
    public interface ITaskDeleteUseCase
    {
        Task Execute(long id);
    }
}
