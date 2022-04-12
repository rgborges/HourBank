using HourBank.Models.Tasks;
using HourBank.View.Display;
using hourbank.console.Application;

var repository = new SqLiteRepository();
var controller = new HourBankController<JobTaskData>(repository);

var cli = new StandardCLI();
cli.SetController(controller);
cli.SetRepository(repository);
if (args[0] == "-i")
{
    while (true)
    {
        Display.PrintHeader();
        string[] iargs = Console.ReadLine().Split(' ');
        if (iargs[0] == "exit")
        {
            break;
        }
        cli.Run(iargs);
    }
    return;
}

cli.Run(args);