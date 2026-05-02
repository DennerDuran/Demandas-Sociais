using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demandas_sociais.Models
{
    [Table("Demandas")]
    public class Demandas

    {

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a Demanda!")]
        [Display(Name ="Nº da Demanda")]
        public string Demanda { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o nome!")]
        [Display(Name = "Descrição de Demanda")]
        public string Nome { get; set; }
        

        [Required(ErrorMessage = "É obrigatório informar o tipo!")]
        [Display(Name = "Tipo de Demanda")]
        public string Tipo { get; set; }

        public ICollection<Recursos> Recursos { get; set; } 

    }
}
