
namespace HourBank.Controller
{
    public interface IRepository<T>
    {
        void Create();
        SystemResult PostTask(T data);
        SystemResult DeleteTask(int taskid);
        SystemResult UpdateTask(T task);
        List<T> GetAllTasks();
        List<T> GetAllCyclesFromTask(int id);
        T GetTask(int taskid);
    }

    public enum SystemResult
    {
        Ok,
        Fail,
        Warn,
        Unknow
    }
}
