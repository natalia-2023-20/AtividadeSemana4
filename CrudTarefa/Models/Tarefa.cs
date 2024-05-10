using System.ComponentModel.DataAnnotations;

namespace CrudTarefa.Models
{
    public class Tarefa
    {

        [Display(Name = "ID da tarefa")]
        public int TarefaId { get; set; }

        [Display(Name = "Nome do tarefa")]
        public string? NomeTarefa { get; set; }

        [Display(Name = "Data de ínicio")]
        public DateTime DtCad { get; set; }

        [Display(Name = "Data de finalização")]
        public DateTime DtCadFim { get; set; }

        public bool Concluida { get; set; }

    }
}
