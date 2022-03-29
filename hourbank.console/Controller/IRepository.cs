
public interface IRepository
{
    void Create();
    SystemResult PostTask(JobTaskData data);
    SystemResult DeleteTask(int taskid);
    SystemResult UpdateTask(JobTaskData task);
    List<JobTaskData> GetAllTasks();
    List<JobCycleData> GetAllCyclesFromTask(int id);
    JobTaskData GetTask(int taskid);
}

public enum SystemResult
{
    Ok,
    Fail,
    Warn
}