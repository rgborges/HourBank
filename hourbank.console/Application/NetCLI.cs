using HourBank.View.Display;
using SearchAThing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hourbank.console.Application
{
    //inacabado
    internal class NetCLI
    {
        public NetCLI()
        {

        }
        public void Run(string[] args)
        {
            CmdlineParser.Create("your hour database application", (parser) =>
            {
                var cmdinit = parser.AddCommand("init", "Initializes a repository in your profile");
                var cmdtask = parser.AddCommand("task", "Add a new task");
                var cmdreadtask = parser.AddCommand("status", "Read tasks from your stage area");
                var nameflag = parser.AddShort("n", "Set a name for the object", "NVAL");

                // global flag with auto invoked action when matches that print usage for nested MatchParser
                parser.AddShort("h", "show usage", null, (item) => item.MatchParser.PrintUsage());

                parser.OnCmdlineMatch(() =>
                {
                    

                });

                //call this once at toplevel parser only
                parser.Run(args);
            });

        }
    }
}
