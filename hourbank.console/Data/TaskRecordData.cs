using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HourBank.Models.Tasks;

public class JobTaskData {    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "unamed task";
    public int Prority { get; set; } = 5;
    public bool IsUrgent { get; set; }
    public BusinessTaskStatus Status { get; set; }
    public List<JobCycleData> Cycle { get; set; } = new List<JobCycleData>(); 
}