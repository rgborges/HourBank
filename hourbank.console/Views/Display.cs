namespace HourBank.View.Display
{
    public static class Display
    {
        private static string CursorHeader = "HourBank> ";
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
    }
}