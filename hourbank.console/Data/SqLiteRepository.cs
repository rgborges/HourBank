using System.Linq;
using HourBank.Models;
using HourBank.Models.Tasks;
public class SqLiteRepository : IRepository<JobTaskData>
{
    private HourBankContext _context;
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
        throw new NotImplementedException();
    }

    public JobTaskData GetTask(int taskid)
    {
        throw new NotImplementedException();
    }

    public SystemResult PostTask(JobTaskData data)
    {
        this._context.Tasks.Add(data);
    }

    public SystemResult UpdateTask(JobTaskData task)
    {
        throw new NotImplementedException();
    }
}