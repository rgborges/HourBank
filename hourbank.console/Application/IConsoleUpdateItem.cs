using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hourbank.console.Application
{
    public interface IConsoleUpdateItem<T>
    {
        bool IsSelected();
        T getItemSelected();
    }
}
