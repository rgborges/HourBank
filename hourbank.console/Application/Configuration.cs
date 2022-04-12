public static class Configuration
{
    public static string DatabasePath { get; set; } = @"C:\Users\TG456GS\source\repos\HourBank\hourbank.console\hourbank.db";
    public static string SqliteConnectionString { get; set; } = $@"Data Source={DatabasePath}";
}