using HourBank.Models.Tasks;
using SearchAThing;

//setup
var repository = new FileRepository();
var controller = new HourBankController(repository);

CmdlineParser.Create("your hour database applicatin", (parser) =>
{
    var init = parser.AddShort("init", "Initializes a repository in your profile");
    // global flag with auto invoked action when matches that print usage for nested MatchParser
    parser.AddShort("h", "show usage", null, (item) => item.MatchParser.PrintUsage());

    parser.OnCmdlineMatch(() => 
    {
        if(init) try { 
            controller.InitilizeRepository();}
        catch (Exception e) {
            System.Console.WriteLine(e.Message);
        }
    });

    //call this once at toplevel parser only
    parser.Run(args);
});
