using HourBank.Models.Tasks;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Create a list of tasks
List<ProjectTask> DailyProjectTasksList = new List<ProjectTask>()
{
    new ProjectTask {Title="Migrate a database",Project="Project A", InstanceId = Guid.NewGuid()},
    new ProjectTask {Title="UpdateMy Hours", Project= "Project B", InstanceId = Guid.NewGuid()}
};

var Result = DailyProjectTasksList.Where( x => x.Project.Contains("Project A")).ToList();
Console.WriteLine(Result);

//Print
foreach (ProjectActivity t in DailyProjectTasksList)
{
    Console.WriteLine(t.ToString());
}