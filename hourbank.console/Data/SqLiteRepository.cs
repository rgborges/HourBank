using System.Linq;
using HourBank.Controller;
using HourBank.Models;
using HourBank.Models.Tasks;
public class SqLiteRepository : IRepository<JobTaskData>
{
    private readonly HourBankContext _context;
    public SqLiteRepository()
    {
        _context = new HourBankContext();
    }
    public void Create()
    {
        
    }

    public SystemResult DeleteTask(int taskid)
    {
        throw new NotImplementedException();
    }

    public List<JobTaskData> GetAllCyclesFromTask(int id)
    {
        throw new NotImplementedException();
    }

    public List<JobTaskData> GetAllTasks()
    {
        return _context.Tasks.ToList<JobTaskData>();
    }

    public JobTaskData GetTask(int taskid)
    {
        return _context.Tasks.Where(t => t.Id == taskid).FirstOrDefault();
    }

    public SystemResult PostTask(JobTaskData data)
    {
        _context.Tasks.Add(data);
        _context.SaveChanges();
        return SystemResult.Ok;
    }

    public SystemResult UpdateTask(JobTaskData task)
    {
        if (task == null) return SystemResult.Fail;
        _context.Tasks.Update(task);
        return SystemResult.Ok;
    }
   
}