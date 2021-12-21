using HourBank.Models.Tasks;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Create a list of tasks
HourCounterService service = new HourCounterService();

//Add some task
service.AddTask(new ProjectTask {Title = "Remanejamento do banco de dados", Project = "Projeto A"});
service.Initialize(
    service.TaskList[0]
);
service.AddTask(new ProjectTask {Title = "Deploy de API no cliente", Project = "Projeto B"});


Console.WriteLine("Tasks: ");
foreach (BusinessTask a in service.GetTaskList())
{
    Console.WriteLine(a.ToString());
}

Console.WriteLine("Cycles: ");
foreach (HourCycle c in service.GetHourCycleList())
{
    Console.WriteLine(c.ToString());
}
