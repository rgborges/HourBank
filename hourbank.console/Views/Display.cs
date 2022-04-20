using HourBank.Controller;
using Spectre.Console;
using static System.Console;

namespace HourBank.View.Display
{
    public static class Display
    {
        private static string applicationName = "HourBank";
        public static void PrintLogo()
        {
            WriteLine("Borges Software Lab - HourBank Application");
        }
        public static void AddNewProjectTask(ref string? name, ref string? project)
        {
            System.Console.WriteLine("Iniciando o processo de criação de tarefa");
            System.Console.Write("Digite o nome da tarefa: ");
            name = Console.ReadLine();
            System.Console.Write("Digite o projeto: ");
            project  = Console.ReadLine();
        }

        internal static void PrintHeader()
        {
            Console.Write(@$"{applicationName}🌌🪐:");
        }
        internal static void PrintHeader(JobTaskData task)
        {
            Console.Write(@$"{applicationName}🌌🪐>{task.Name}:");
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
            System.Console.Clear();
            Display.PrintHeader();
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
            Console.Write("Please type the task title ✍: ");
            var name = Console.ReadLine();
            Console.Write("Please type a priority ✍: ");
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
        internal static void PrintJobTasksAsTables(IEnumerable<JobTaskData> tasks)
        {
            var table = new Table();
            table.AddColumn("Name");
            table.AddColumn("Priority");
            table.AddColumn("Status");
            table.AddColumn("StartTime");

            table.Border(TableBorder.Ascii);
            foreach (JobTaskData t in tasks)
            {
                string name = t.Name;
                string status = t.Status.ToString();
                string priority = t.Prority.ToString();
                string time = t.StartTime.ToString();
                table.AddRow(name.EscapeMarkup(), priority.EscapeMarkup(), status.EscapeMarkup(), time.EscapeMarkup());
            }
            AnsiConsole.Write(table);
        }
          internal static void PrintJobTasksAsTablesWithId(IEnumerable<JobTaskData> tasks)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Name");
            table.AddColumn("Priority");
            table.AddColumn("Status");
            table.AddColumn("StartTime");

            table.Border(TableBorder.Ascii);
            foreach (JobTaskData t in tasks)
            {
                string id = t.Id.ToString();
                string name = t.Name;
                string status = t.Status.ToString();
                string priority = t.Prority.ToString();
                string time = t.StartTime.ToString();
                table.AddRow(id.EscapeMarkup(),name.EscapeMarkup(), priority.EscapeMarkup(), status.EscapeMarkup(), time.EscapeMarkup());
            }
            AnsiConsole.Write(table);
        }

        internal static void PrintJobTaskDataLabel(JobTaskData task)
        {

            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.Write($" {nameof(task.Id)}: {task.Id}, {nameof(task.Name)}: {task.Name}\n {nameof(task.Prority)}: ");
            Display.PrintPriorityColored(task);
            Console.WriteLine($"{nameof(task.Status)}: {task.Status}, {nameof(task.StartTime)}: {task.StartTime}");
            Console.WriteLine("-------------------------------------------------------------------------------------");
        }

        internal static JobTaskData PrintSelectTaskWizard(IHourBankController<JobTaskData> controller)
        {
            JobTaskData result = null;
            do
            {
                PrintJobTasksAsTablesWithId(controller.GetAllTasks());
                System.Console.Write("Please select the task id: ");
                int id = int.Parse(Console.ReadLine());
                result = controller.GetTask(id);

            }while(result is null);
            //Print a wizard to select a task and needs to return a task
            return result;
        }

        internal static int PrintDeleteTaskWizard()
        {
            int id = 0;
            do
            {
               Write("Select the task id you want to delete: ");
               id = int.Parse(Console.ReadLine());
            } while (id <= 0);
            return id;
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
        internal static void TestSpectre()
        {
            // Markup
            // Constant
            var hello = "Hello " + Emoji.Known.GlobeShowingEuropeAfrica;
            AnsiConsole.MarkupLine($"{hello}");
            AnsiConsole.MarkupLine("Hello :globe_showing_europe_africa:!");

            var newtask = new JobTaskData { Name = "task teste", Prority = 1, Status = Models.Tasks.BusinessTaskStatus.Created };

            var table = new Table();
            table.Border(TableBorder.Rounded);
            table.AddColumn("Name");
            table.AddColumn("Priority");

            table.AddRow(newtask.Name.ToString(), newtask.Prority.ToString());

            AnsiConsole.Write(table);

        }
        internal static void Clear()
        {
            Console.Clear();
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