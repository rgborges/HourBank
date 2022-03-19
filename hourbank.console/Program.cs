using HourBank.Models.Tasks;
using HourBank.View.Display;
using SearchAThing;

//setup
var repository = new FileRepository();
var controller = new HourBankController(repository);

CmdlineParser.Create("your hour database application", (parser) =>
{
    var cmdinit = parser.AddCommand("init", "Initializes a repository in your profile");
    var cmdtask = parser.AddCommand("task", "Add a new task");
    var nameflag = parser.AddShort("n", "Set a name for the object", "NVAL");
    
    // global flag with auto invoked action when matches that print usage for nested MatchParser
    parser.AddShort("h", "show usage", null, (item) => item.MatchParser.PrintUsage());
    
    parser.OnCmdlineMatch(() => 
    {
        if(cmdinit) try { 
            controller.InitilizeRepository();}
        catch (Exception e) {
            System.Console.WriteLine(e.Message);
        }
        if(cmdtask)
        {
            if(nameflag) {
                try{
                   Display.PrintTaskCreated(controller.PostTask((string)nameflag));
                }
                catch (Exception e) {
                   Display.PrintError(e.Message);
                }
                
            }
        }
        
    });

    //call this once at toplevel parser only
    parser.Run(args);
});
