namespace GoTask.Domain.Data.Interface
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
