public interface IRepository
{
    void Create();
    Guid Save(object task);
}