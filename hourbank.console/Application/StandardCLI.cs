﻿using System;
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
        private IRepository<JobTaskData>? repository;

        public StandardCLI(IRepository<JobTaskData>? repository)
        {
            this.repository = repository;
        }

        private HourBankController<JobTaskData>? controller;

        public StandardCLI()
        {

        }
        //configurations
        public StandardCLI SetRepository(IRepository<JobTaskData> repository)
        {
            this.repository = repository;
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
                            var result = Display.NewTaskWizard();
                            if (result is null) throw new NullReferenceException($"paramName: {result}");
                            try
                            {
                                var r = controller.Save(result);
                                Display.Print(r.ToString());
                            }
                            catch (Exception ex)
                            {
                                Display.PrintError(ex.Message);
                            }
                            break;
                        case "cycle":
                            break;
                        default:
                            Display.PrintHelp();
                            break;
                    }
                    break;
                case "get":
                    if (args.Length < 2)
                    {
                        Display.Print("Missing argument in get. The correct use is get [taskid]");
                        return;
                    }
                    try
                    {
                       int idsearched = int.Parse(args[1]);
                       Display.PrintJobTaskDataLabel(controller.GetTask(idsearched));
                    }
                    catch(Exception ex)
                    {
                        Display.PrintError(ex.Message);
                    }
                    break;
                case "delete":
                    try
                    {
                        int idsearched = Display.PrintDeleteTaskWizard();
                        var result = controller.Delete(idsearched);
                        Display.Print(result.ToString());
                    }
                    catch (Exception ex)
                    {
                        Display.PrintError(ex.Message);
                    }
                    break;
                case "status":
                    try
                    {
                        Display.PrintJobTaskDataLabel(controller.GetAllTasks());
                    }
                    catch(Exception ex)
                    {
                        Display.PrintError(ex.Message);
                    }
                    break;
                case "help":
                    Display.PrintHelp();
                    break;
                default:
                    Display.PrintHelp();
                    break;
            }
        }
    }
}
