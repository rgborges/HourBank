using HourBank.View.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hourbank.console.Application
{
    internal class Application
    {
        //this class will manage the display class, controller and repository standard
        private ICLI cli;
        private JobTaskData tempTaskData;
        private JobCycleData tempCycleData;

        private string applicationName;

        public Application(ICLI commandline, string applicationName)
        {
            this.applicationName = applicationName;
            this.cli = commandline;
        }
        public void SetJobTask(JobTaskData task)
        {
            this.tempTaskData = task;
        }
        public void SetCycleData(JobCycleData cycle)
        {
            this.tempCycleData = cycle;
        }

        public void Run(string[] args)
        {
            //this is for a run in command line
            this.cli.Run(args);
        }
        public void RunInteractive()
        {
            //this is for run hourbank interactively
            while (true)
            {
                Display.PrintHeader();
                string[] iargs = Console.ReadLine().Split(' ');
                if (iargs[0] == "exit")
                {
                    break;
                }
                this.cli.Run(iargs);
            }
            return;
        }

        private string GetAppPath()
        {
            if (tempTaskData is null && tempCycleData is null)
            {
                return $"{applicationName}>>";
            }
            else if (tempTaskData is not null && tempCycleData is null)
            {
                return $"{applicationName}\\{tempTaskData.Name}>>";
            }
            else if (tempTaskData is not null && tempCycleData is not null)
            {
                return $"{applicationName}\\{tempTaskData.Name}\\{tempCycleData.Id}>>";
            }
            else
            {
                return "Hourbank";
            }
        }
    }
}
