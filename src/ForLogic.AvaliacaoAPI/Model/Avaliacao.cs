using ForLogic.ClienteAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForLogic.ClienteAPI.Model
{
    [Table("cliente")]
    public class Avaliacao : BaseEntity
    {
        [Column("data_referencia")]
        [Required]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataReferencia { get; set; }

        [Column("nome_contato")]
        [Required]
        [StringLength(150)]
        public string NomeContato { get; set; }

        [Column("cnpj")]
        [StringLength(20)]
        public string Cnpj { get; set; }

        [Column("data_insercao")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataInsercao { get; set; }

    }
}
