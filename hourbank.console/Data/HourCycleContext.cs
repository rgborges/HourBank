using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using HourBank.Models.Tasks;
public class HourBankContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(Configuration.SqliteConnectionString);
    }
    public DbSet<JobTaskData> Tasks { get; set; }
    public DbSet<JobCycleData> Cycles { get; set; }

}