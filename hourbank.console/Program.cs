using HourBank.Models.Tasks;
using HourBank.View.Display;
using hourbank.console.Application;


var repository = new SqLiteRepository();
var controller = new HourBankController<JobTaskData>(repository);

var cli = new StandardCLI();

cli.SetController(controller);
cli.SetRepository(repository);
cli.Run(args);