using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hourbank.console.Application
{
    internal static class Configuration
    {
        public static string DatabasePath { get; set; } = @"C:\Users\rborges\Source\repos\HourBank\hourbank.console\";
        public static string FullDatabasePath { get; set; } = DatabasePath + "hourbank.db";
        public static string ConnectionString { get; set; } = $"Data Source={FullDatabasePath}";
    }
}
