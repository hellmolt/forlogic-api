using ForLogic.AvaliacaoAPI.Data.ValueObjects;
using ForLogic.AvaliacaoAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForLogic.AvaliacaoAPI.Model
{
    [Table("avaliacao")]
    public class Avaliacao : BaseEntity
    {
        [Column("data_referencia")]
        [Required]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataReferencia { get; set; }

        [Column("pontuacao")]
        public int Pontuacao { get; set; }

        public IList<AvaliacaoCliente> AvaliacoesDosClientes { get; set; }

    }
}
