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
        File.AppendText(btask?.ToString() ?? "error");
        return btask.InstanceId;
    }

    private string GetWorkDir()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    }
    private string GetTaskDir()
    {
        return $"{GetWorkDir()}{Path.DirectorySeparatorChar}.tasks";
    }
    
    private string GetCycleDir()
    {
        return $"{GetWorkDir()}{Path.DirectorySeparatorChar}.cycles";
    }
}