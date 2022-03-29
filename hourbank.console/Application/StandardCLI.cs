using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HourBank.Models.Tasks;
using HourBank.Controller;
using HourBank.View.Display;

namespace hourbank.console.Application
{
    internal class StandardCLI
    {
        private IRepository<JobTaskData> _repository;
        private HourBankController<JobTaskData> controller;
        //configurations
        public StandardCLI SetRepository(IRepository<JobTaskData> repository)
        {
            this.SetRepository(repository);
            return this;
        }
        public StandardCLI SetController(HourBankController<JobTaskData> controller)
        {
            this.controller = controller;
            return this;
        }


        public void Run(string[] args)
        {
            //running
            switch(args[0])
            {
                case "new":
                    switch (args[1])
                    {
                        case "task":
                            //params here 
                            // -n for name
                            // -p for priority
                            // -d for date (future)
                            switch(args[2])
                            {

                            }
                            break;
                        case "cycle":
                            break;
                    }
                    break;
                case "status":
                    break;
                case "help":
                    break;
                default:
                    Display.PrintHelp();
                    break;
            }
        }
    }
}
