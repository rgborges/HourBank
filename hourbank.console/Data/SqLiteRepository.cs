using System.Linq;
public class SqLiteRepository : IRepository
{

    public SqLiteRepository()
    {
    }

    void IRepository.Create()
    {
        throw new NotImplementedException();
    }

    SystemResult IRepository.DeleteTask(int taskid)
    {
        throw new NotImplementedException();
    }

    List<JobCycleData> IRepository.GetAllCyclesFromTask(int id)
    {
        throw new NotImplementedException();
    }

    List<JobTaskData> IRepository.GetAllTasks()
    {
        throw new NotImplementedException();
    }

    JobTaskData IRepository.GetTask(int taskid)
    {
        throw new NotImplementedException();
    }

    SystemResult IRepository.PostTask(JobTaskData data)
    {
        try 
        {
            using (HourBankContext db = new HourBankContext()) 
            {
                db.Tasks.Add(data);
                db.SaveChanges();
            }
            return SystemResult.Ok;
        }
        catch (Exception e)
        {
            throw e;
        }     
    }

    SystemResult IRepository.UpdateTask(JobTaskData task)
    {
        throw new NotImplementedException();
    }
    public int GetNewTaskId()
    {
        using(HourBankContext db = new HourBankContext())
        {
            var result = db.Tasks.Max().Id;
            if(result == 0)
            {
                result = 1;
            }
            return result;
        }
    }
}