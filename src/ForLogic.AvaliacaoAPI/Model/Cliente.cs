using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ForLogic.AvaliacaoAPI.Model.Base;

namespace ForLogic.AvaliacaoAPI.Model
{
    [Table("cliente")]
    public class Cliente : BaseEntity
    {
        [Column("nome_cliente")]
        [Required]
        [StringLength(150)]
        public string NomeCliente { get; set; }

        [Column("nome_contato")]
        [Required]
        [StringLength(150)]
        public string NomeContato { get; set; }

        [Column("cnpj")]
        [StringLength(20)]
        [Required]
        public string Cnpj { get; set; }

        [Column("data_insercao")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataInsercao { get; set; }

    }
}
