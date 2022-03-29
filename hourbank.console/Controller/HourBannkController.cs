using HourBank.Models.Tasks;

public class HourBankController
{
    private IRepository repository;
    public HourBankController(IRepository repository)
    {
        this.repository = repository;
    }
    public void InitilizeRepository()
    {
        ///Initializes a data storage local or remote to store the data.
        ///In the case of file we're gonna use txt files or csv format.
        if(repository is FileRepository)
        {
            this.repository.Create();
        }
    }
    public SystemResult PostTask(JobTaskData data)
    {
        if(repository is null) throw new NullReferenceException($"paramName:{data}");
        return this.repository.PostTask(data);
    }

    public IEnumerable<String> ShowStatus()
    {
       throw new NotImplementedException();
    }
}