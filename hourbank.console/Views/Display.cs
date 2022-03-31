using HourBank.Controller;

namespace HourBank.View.Display
{
    public static class Display
    {
        public static void PrintLogo()
        {
            Console.WriteLine("Borges Software Lab - HourBank Application");
        }
        public static void AddNewProjectTask(ref string? name, ref string? project)
        {
            System.Console.WriteLine("Iniciando o processo de criação de tarefa");
            System.Console.Write("Digite o nome da tarefa: ");
            name = Console.ReadLine();
            System.Console.Write("Digite o projeto: ");
            project  = Console.ReadLine();
        }
        internal static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now}:{message} [ERROR]");
            Console.ResetColor();
        }

        internal static void PrintTaskCreated(Guid guid)
        {
            System.Console.WriteLine($"[info] - taks created with guid: {guid}");
        }
        internal static void PrintTaskStatus(string taskString)
        {  
            Console.Write("| ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("+ ");
            Console.ResetColor();
            Console.WriteLine(taskString);
        }
        internal static void Print(string message)
        {
            System.Console.WriteLine(message);
        }

        internal static void PrintResult(SystemResult result)
        {
            if(result == SystemResult.Ok)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[ok] Data posted sucessfully");
                Console.ResetColor();
            }
        }
        internal static JobTaskData NewTaskWizard()
        {
            Console.Write("Please type the task title: ");
            var name = Console.ReadLine();
            Console.Write("Please type a priority: ");
            int priority = int.Parse(Console.ReadLine());
            return new JobTaskData { Name = name, Prority = priority, StartTime = DateTime.Now };
        }
        internal static void PrintJobTaskDataLabel(IEnumerable<JobTaskData> tasks)
        {
            
            foreach (var t in tasks)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.Write($" {nameof(t.Id)}: {t.Id}, {nameof(t.Name)}: {t.Name}\n {nameof(t.Prority)}: ");
                Display.PrintPriorityColored(t);
                Console.WriteLine($"{nameof(t.Status)}: {t.Status}, {nameof(t.StartTime)}: {t.StartTime}");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------");
        }
        internal static void PrintPriorityColored(JobTaskData data)
        {
            if (data.Prority == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{ data.Prority} ");
                Console.ResetColor ();
            }
            else if (data.Prority == 2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{ data.Prority} ");
                Console.ResetColor();
            }
            else if ( data.Prority == 3)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{ data.Prority} ");
                Console.ResetColor();
            }
        }

        internal static void PrintHelp()
        {
            Console.WriteLine("Hourbank app for command line users.");
            //print help here
            Console.WriteLine("NAME \n");
            Console.WriteLine("hourbank.console.exe");
            Console.WriteLine("COMMANDS \n");
            Console.WriteLine("-----------------+-----------------------------------");
            Console.WriteLine($"new task        |          adds a new task.");
            Console.WriteLine($"start task      |          start a task.");
            Console.WriteLine($"stop task       |          stop a task.");
            Console.WriteLine($"end task        |          end task.");
            Console.WriteLine($"status          |          show the staus of all tasks.");
            Console.WriteLine($"delete          |          delete a task.");
            Console.WriteLine("-----------------------------------------------------\n");
            Console.WriteLine("Flags \n");
            Console.WriteLine("-----------------+-----------------------------------");
            Console.WriteLine("-n [name]");
            Console.WriteLine("-p [set priority]");
            Console.WriteLine("-----------------+-----------------------------------");
        }
    }
}