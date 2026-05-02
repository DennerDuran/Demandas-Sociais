using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demandas_sociais.Models
{
    [Table("Recursos")]
    public class Recursos
    {
        [Key]
        public int Id { get; set; }

        
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }  

        public DateTime? Data{ get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o custo")]
        public decimal Custo { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar a quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Tipo de Recurso")]
        public TipoRecurso Tipo { get; set; }

        [Display(Name = "Descrição da Demanda")]
        public int DemandaId { get; set; }

        
        [Display(Name = "Descrição da Necessidade")]
        public Demandas Demandas { get; set; }    

    }

    public enum TipoRecurso
    {
        Saúde,
        Social
    }
}
