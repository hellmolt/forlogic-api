using ForLogic.AvaliacaoAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForLogic.AvaliacaoAPI.Model
{
    [Table("categoria_nota")]
    public class CategoriaNota : BaseEntity
    {
        [Column("nome_categoria")]
        [Required]
        [StringLength(15)]
        public string NomeCategoria { get; set; }

        [Column("nota_minima")]
        [Required]
        public int NotaMinima { get; set; }

        [Column("nota_maxima")]
        [Required]
        public int NotaMaxima { get; set; }
    }
}
