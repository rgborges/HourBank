﻿using HourBank.Models.Tasks;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Create a list of tasks
HourCounterService service = new HourCounterService();

//Add some task
service.AddTask(new ProjectTask {Title = "Remanejamento do banco de dados", Project = "Projeto A"});
service.AddTask(new ProjectTask {Title = "Deploy de API no cliente", Project = "Projeto B"});



foreach (BusinessTask a in service.GetTaskList())
{
    Console.WriteLine(a.ToString());
}

