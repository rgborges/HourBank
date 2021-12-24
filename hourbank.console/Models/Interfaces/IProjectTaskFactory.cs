namespace HourBank.Models.Tasks
{
    public interface ITaskFactory
    {
        /// <summary>
        /// Define no contrato um método que retorna a classe concreta ProjectTask.
        /// </summary>
        /// <returns>Retorna a classe ProjectTask que representa tarefa de projeto</returns>
        public ProjectTask CreateProjectTask();
        /// <summary>
        /// Define no contrato da interface um método que retorna a classe contreta CreateSupportTask
        /// </summary>
        /// <returns>Retorna uma tarefa de suporte</returns>
        public SupportTask CreateSupportTask();
    }
}