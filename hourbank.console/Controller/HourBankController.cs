using HourBank.Controller;
using HourBank.Models.Tasks;

public class HourBankController<T>
{
    private readonly IRepository<T> repository;
    public HourBankController(IRepository<T> repository)
    {
        this.repository = repository;
    }
    public SystemResult Save(T t)
    {
        //POST
        var  r = repository.PostTask(t);
        return r;
    }

    public IEnumerable<T> GetAllTasks()
    {
        IEnumerable<T> result = repository.GetAllTasks();
        foreach (var task in result)
        {
            yield return task;  
        }
    }
    public T GetTask(int id)
    {
        return this.repository.GetTask(id);
    }
    public SystemResult Delete(int id)
    {
        this.repository.DeleteTask(id);
        return SystemResult.Ok;
    }
}