using HourBank.Models.Tasks;

public class FileRepository : IRepository
{
    private string? _workDirectory;

    public void Create()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        this._workDirectory = path + Path.DirectorySeparatorChar + "hourbank";
        if(!Directory.Exists(_workDirectory)) {
            Directory.CreateDirectory(_workDirectory);
        }
        File.Create(_workDirectory + $"{Path.DirectorySeparatorChar}.tasks");
        File.Create(_workDirectory + $"{Path.DirectorySeparatorChar}.cycles");
    }

    public Guid Save(object task)
    {
        if(task is not BusinessTask || task is null)
        {
            throw new NullReferenceException();
        }
        var btask = task as BusinessTask;
        if(!File.Exists(this.GetTaskPath()))
        {
            File.Create(this.GetTaskPath());
        }
        using (StreamWriter sw = File.AppendText(this.GetTaskPath()))
        {
            sw.WriteLine($"{btask.ToLog()}");
        }
        return btask.InstanceId;
    }

    private string GetWorkDir()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    }
    private string GetTaskPath()
    {
        return $"{GetWorkDir()}{Path.DirectorySeparatorChar}hourbank{Path.DirectorySeparatorChar}.tasks";
    }
    
    private string GetCyclePath()
    {
        return $"{GetWorkDir()}{Path.DirectorySeparatorChar}hourbank{Path.DirectorySeparatorChar}.cycles";
    }
}