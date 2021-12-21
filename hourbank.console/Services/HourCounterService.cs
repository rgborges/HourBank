using HourBank.Models.Tasks;
//TODO
//-> implementar um gerenciamento de horas de tarefas
//
namespace HourBank.Models.Tasks
{
    /// <summary>
    /// Essa classe é destinada a gerenciar os tempos das tarefas. Tarefas em si podem ser pausadas ou 
    /// encerradas, porém o HoourCounterService deve intermediar e tirar a responsabilidade da tarefa em gerenciar o seu tempo.
    public class HourCounterService
    {
        public List<BusinessTask> TaskList {get; private set;}
        /// <summary>
        /// Represents a Log of TimeCycles from Tasks.
        /// </summary>
        private List<HourCycle> HourCycleList {get;}
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
        /// <summary>
        /// Generates a new Hour Cycle by a Task.
        /// </summary>
        /// <param name="businessTask"></param>
        /// <param name="incommingStatus"></param>
        /// <returns></returns>
        public HourCycle GenerateNewCycle(BusinessTask businessTask, BusinessTaskStatus incommingStatus)
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="businessTask"></param>
            /// <returns></returns>
            DateTime currentStatusTime = DateTime.Now;
            DateTime lastStatusTime = businessTask.LastStatusChanged;
            BusinessTaskStatus lastStatus = businessTask.LastStatus;
            BusinessTaskStatus currentStatus = incommingStatus;
            return new HourCycle(
                lastStatus,
                currentStatus,
                lastStatusTime,
                currentStatusTime,
                businessTask.InstanceId,
                businessTask
            );

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
            DateTime timetamp = DateTime.Now;
            BusinessTaskStatus current_status = businessTask.CurrentStatus;
            BusinessTaskStatus last_task_status = businessTask.LastStatus;
            BusinessTaskStatus incoming_status = BusinessTaskStatus.Initiated;

            // As this task is initiated, the total ammount is 0.00

            //Instanciate a new cycle
            HourCycle incommingCycle = GenerateNewCycle(businessTask,incoming_status);
            //Adiciona novo ciclo de horas para essa tarefa
            HourCycleList.Add(incommingCycle);
            //Atualiza status da tarefa
            UpdateTaskStatus(businessTask, incoming_status);
        }

        public void Start(BusinessTask businessTask)
        {
            /// <summary>
            /// Representa o início de uma tarefa. Dois estados transitam para este,
            /// quando tarefe recém inicializada, e retomada de pausa 'OnHold' state.
            /// </summary>
            HourCycle incommingCycle = GenerateNewCycle(businessTask, BusinessTaskStatus.Running);
            //Adiciona novo ciclo de horas em uma tarefa
            HourCycleList.Add(incommingCycle);
            //Atualiza status desta tarefa
            UpdateTaskStatus(businessTask, BusinessTaskStatus.Running);
        }

        public void Hold(BusinessTask businessTask)
        {
             /// <summary>
            /// Representa o início de uma tarefa. Dois estados transitam para este,
            /// quando tarefe recém inicializada, e retomada de pausa 'OnHold' state.
            /// </summary>
            HourCycle incommingCycle = GenerateNewCycle(businessTask, BusinessTaskStatus.OnHold);
            //Adiciona novo ciclo de horas em uma tarefa
            HourCycleList.Add(incommingCycle);
            //Atualiza status desta tarefa
            UpdateTaskStatus(businessTask, BusinessTaskStatus.OnHold);
        }
        public void Cancel(BusinessTask businessTask)
        {
             /// <summary>
            /// Representa o início de uma tarefa. Dois estados transitam para este,
            /// quando tarefe recém inicializada, e retomada de pausa 'OnHold' state.
            /// </summary>
            HourCycle incommingCycle = GenerateNewCycle(businessTask, BusinessTaskStatus.Canceled);
            //Adiciona novo ciclo de horas em uma tarefa
            HourCycleList.Add(incommingCycle);
            //Atualiza status desta tarefa
            UpdateTaskStatus(businessTask, BusinessTaskStatus.Canceled);
        }
        public void Terminate(BusinessTask businessTask)
        {
              /// <summary>
            /// Representa o início de uma tarefa. Dois estados transitam para este,
            /// quando tarefe recém inicializada, e retomada de pausa 'OnHold' state.
            /// </summary>
            HourCycle incommingCycle = GenerateNewCycle(businessTask, BusinessTaskStatus.Completed);
            //Adiciona novo ciclo de horas em uma tarefa
            HourCycleList.Add(incommingCycle);
            //Atualiza status desta tarefa
            UpdateTaskStatus(businessTask, BusinessTaskStatus.Completed); 
        }
        public void UpdateTaskStatus(BusinessTask businessTask, BusinessTaskStatus incommingStatus)
        {
            /// <summary>
            /// O estado anterior da tarefa se torna armazena o estado corrente.
            /// </summary>
            businessTask.LastStatus = businessTask.CurrentStatus;
            /// <summary>
            /// O estado corrente da tarefa é atualizado então para o estado de recebimento
            /// </summary>
            businessTask.CurrentStatus = incommingStatus;
            /// <summary>
            /// O último timestamp da mudança da tarefa assume o valor da propriedade que armazena o time corrente.
            /// </summary>
            businessTask.LastStatusChanged = DateTime.Now;

        
        }
    }
}