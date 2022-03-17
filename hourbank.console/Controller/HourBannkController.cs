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
        this.repository.Create();
    }
    public Guid PostTask(string name)
    {
        var incomeTask = new SupportTask()
        {
            Title = name,
            CurrentStatus = BusinessTaskStatus.Created,
            StartDateTime = DateTime.Now,
            Priority = 5,
        };
        Guid result = this.repository.Save(incomeTask);
        return result;
    }

}