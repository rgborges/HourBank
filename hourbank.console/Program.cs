using HourBank.Models.Tasks;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Create a list of tasks
List<ProjectTask> DailyProjectTasksList = new List<ProjectTask>()
{
    new ProjectTask {Title="Migrate a database",Project="Project A"},
    new ProjectTask {Title="UpdateMy Hours", Project= "Project B"}
};


//Print
foreach (ProjectActivity t in DailyProjectTasksList)
{
    Console.WriteLine(t.ToString());
}