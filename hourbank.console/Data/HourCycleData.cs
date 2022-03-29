using Microsoft.EntityFrameworkCore.Design;
using HourBank.Models.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class JobCycleData {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public DateTime StarDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public JobTaskData JobTask { get; set; } = new JobTaskData();
    
}