using HourBank.Controller;
public interface IHourBankController<T>
{
    SystemResult Save(T task);
    SystemResult Delete(int id);
    SystemResult UpdateTask(int id, T task);
    T GetTask(int id);
    IEnumerable<T> GetAllTasks();
}