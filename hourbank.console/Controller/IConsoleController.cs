using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hourbank.console.Controller
{
    internal interface IConsoleController<T>
    {
        public IEnumerable<T> GetAllTasks();
        public T GetTask(int id);
    }
}
