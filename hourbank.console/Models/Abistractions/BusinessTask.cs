using System.Collections;
using System.Collections.Generic;

namespace HourBank.Models.Tasks
{
    /// <summary>
    /// Uma atividade de negócio é uma classe abstrata para uma tarefa de projeto, suporte, treinamento.
    /// </summary>
    public abstract class BusinessTask
    {
        /// <summary>
        /// Propriedade armazena um GUID (Identificador único universal).
        /// </summary>
        /// <value></value>
        public Guid InstanceId { get; set;}
        /// <summary>
        /// Armzena o um número inteiro que representa aprioridade dessa tarefa no negócio.
        /// Não há limitação aqui do número em si de prioridade.
        /// </summary>
        /// <value>Número inteiro para representar a prioridade</value>
        public int Priority { get; set; }
        /// <summary>
        /// Armazena o título de uma tarefa.;
        /// </summary>
        /// <value>string</value>
        public string? Title { get; set; }
        /// <summary>
        /// Representa o status corrente da tarefa.
        /// </summary>
        /// <value></value>
        public BusinessTaskStatus CurrentStatus { get; set;}
        /// <summary>
        /// Representa a estampa de tempo de início da atividade.
        /// </summary>
        /// <value></value>
        public DateTime StartDateTime { get; set;}
        /// <summary>
        /// Representa a estampa de tempo no fim da atividade.
        /// </summary>
        /// <value></value>
        public DateTime EndDateTime { get; set; }
        /// <summary>
        /// Representa a estampa de tempo em que a tarefa foi atualizada pela última vez.
        /// Atualizações ocorrerão toda vez em que for adicionado um ciclo de horas.
        /// </summary>
        /// <value></value>
        public DateTime LastTimeUpdated { get; set;}
        /// <summary>
        /// Representa o status salvo na última mudança.
        /// Atualizações ocorrerão toda vez em que for adicionado um ciclo de horas.
        /// </summary>
        /// <value></value>
        public BusinessTaskStatus LastStatus { get; set; }

    }

}