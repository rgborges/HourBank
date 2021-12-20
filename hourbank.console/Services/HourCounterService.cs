using HourBank.Models.Tasks;
//TODO
//-> implementar um gerenciamento de horas de tarefas
//
namespace HourBank.Models.Tasks
{
    /// <summary>
    /// Essa classe é destinada a gerenciar os tempos das tarefas. Tarefas em si podem ser pausadas ou 
    /// encerradas, porém o HoourCounterService deve intermediiar e tirar a responsabilidade da tarefa em gerenciar o seu tempo.
    public class HourCounterService
    {
        /// <summary>
        /// The service TaskLis for management in the HourBank.
        /// </summary>
        public List<BusinessTask> TaskList {get; private set;}
        /// <summary>
        /// Represents a Log of TimeCycles from Tasks.
        /// </summary>
        private List<HourCycle> HourCycleList {get;}
        /// <summary>
        /// The standard constructor initiates the Task and HourCycle List.
        /// </summary>
        public HourCounterService()
        {
            TaskList = new List<BusinessTask>();
            HourCycleList = new List<HourCycle>();
        }

        public List<BusinessTask>? GetTaskList()
        {
            return TaskList ?? new List<BusinessTask>();
        }
        public List<HourCycle>? GetHourCycleList()
        {
            return HourCycleList ?? new List<HourCycle>();
        }

        public void AddTask(BusinessTask task)
        {
             if(task == null)
            {
                throw new NullReferenceException("Por favor instancie um novo objeto na classe Business Task");
            }
            TaskList.Add(task);
        }
        public void AppendNewCycle(HourCycle cycle)
        {
            if(cycle == null)
            {
                throw new NullReferenceException("Por favor instancie um novo objeto na classe Business Task");
            }
            //Check if the list is not empty
            if(TaskList.Count == 0)
            {
                throw new Exception("You don't have any task on the list yet. Please inciate the List with 1 task at least.");
            }
            HourCycleList.Add(cycle);            
        }

        public double GetTotalHours(BusinessTask businessTask)
        {
            throw new NotImplementedException();
        }
        
        public void Initialize(BusinessTask businessTask)
        {
        // Aqui a tarefa acaba de seer criada. Ou seja, não temos ainda Ciclos atrelados á essa tarefa.
        // Aqui a tarefa inicia com um status em 'Initiate' e com 0 cycles cadastrado.
        // outro ponto é que o serviço de contador vai estar desatrelado à essa classe.
            
        }

        public void Continue()
        {
            throw new NotImplementedException();
        }

        public void Hold()
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Terminate()
        {
            throw new NotImplementedException();   
        }
    }
}