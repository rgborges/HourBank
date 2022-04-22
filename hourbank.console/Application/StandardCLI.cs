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
    internal class StandardCLI : IConsoleUpdateItem<JobTaskData>
    {
        private int tempid = 0;
        private JobTaskData tempTaskData = null;
        private SystemResult tempResult = SystemResult.Unknow;
        private IRepository<JobTaskData>? repository;
        private HourBankController<JobTaskData>? controller;

     

        public StandardCLI()
        {

        }
        //configurations
        public StandardCLI(IRepository<JobTaskData>? repository)
        {
            this.repository = repository;
        }
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
                                tempResult = controller.Save(result);
                                Display.Print(tempResult.ToString());
                                tempResult = SystemResult.Unknow;
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
                case "set":
                    if(args.Length >= 2)
                    {
                        switch(args[1])
                        {
                            case "task":
                                //reach the set task command. Set command needs to search in the database for a jobtask record
                                //and keep it in memory on CLI class
                                try
                                {
                                    tempTaskData = Display.PrintSelectATaskWizard(controller);
                                    if (tempTaskData is null)
                                    {
                                        throw new Exception("None task found with id passed.");
                                    }
                                    Display.Print($"Task: {tempTaskData.Name} selected. [Ok] ");
                                }
                                catch (ApplicationException exp)
                                {
                                    Display.PrintError(exp.Message);
                                }
                                break;
                        }
                    }
                    break;
                case "delete":
                    try
                    {
                        tempid = Display.PrintDeleteTaskWizard();
                        tempResult = controller.Delete(tempid);
                        Display.Print(tempResult.ToString());
                        tempResult = SystemResult.Unknow;
                    }
                    catch (Exception ex)
                    {
                        Display.PrintError(ex.Message);
                    }
                    break;
                case "status":
                    try
                    {
                        Display.PrintJobTasksAsTables(controller.GetAllTasks());
                        //Display.PrintJobTaskDataLabel(controller.GetAllTasks());
                    }
                    catch(Exception ex)
                    {
                        Display.PrintError(ex.Message);
                    }
                    break;
                case "clear":
                    Display.Clear();
                    break;
                case "help":
                    Display.PrintHelp();
                    break;
                default:
                    Display.PrintHelp();
                    break;
            }
        }

        public bool IsSelected()
        {
            if (tempTaskData is null) return false;
            else
            {
                return true;
            }
        }

        public JobTaskData getItemSelected()
        {
            return this.tempTaskData;
        }
    }
}
