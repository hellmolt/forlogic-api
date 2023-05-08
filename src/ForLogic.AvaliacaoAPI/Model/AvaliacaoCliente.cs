using ForLogic.AvaliacaoAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;

namespace ForLogic.AvaliacaoAPI.Model
{
    [Table("avalicao_cliente")]
    public class AvaliacaoCliente : BaseEntity
    {
        public long ClienteId { get; set; }

        [ForeignKey("cliente_id")]
        public virtual Cliente Cliente { get; set; }

        public long AvaliacaoId { get; set; }

        [ForeignKey("avaliacao_id")]
        public virtual Avaliacao Avaliacao { get; set; }

        public long CategoriaNotaId { get; set; }

        [ForeignKey("categoria_nota_id")]
        public virtual CategoriaNota CategoriaNota { get; set; }

        [Column("nota")]
        [Required]
        public int Nota { get; set; }

        [Column("motivo")]
        [Required]
        public string Motivo { get; set; }

        [Column("data_avaliacao")]
        [Required]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataAvaliacao { get; set; }

    }
}
