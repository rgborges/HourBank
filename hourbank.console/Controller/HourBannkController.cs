using HourBank.Models.Tasks;

public class HourBankController<T>
{
    private IRepository<T> repository;
    public HourBankController(IRepository<T> repository)
    {
        this.repository = repository;
    }
    public void Save(T t)
    {
        //POST
        repository.PostTask(t);
    }
   
}