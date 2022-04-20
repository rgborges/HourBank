using HourBank.Controller;
using HourBank.Models.Tasks;
using hourbank.console.Controller;

public class HourBankController<T> : IConsoleController<T>
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
    public SystemResult UpdateTask(int id, T task)
    {
        this.repository.UpdateTask(id, task);
        return SystemResult.Ok;
    }
}