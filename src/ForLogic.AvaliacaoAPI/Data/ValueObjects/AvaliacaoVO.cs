using ForLogic.AvaliacaoAPI.Data.ValueObjects;

namespace ForLogic.AvaliacaoAPI.Data.ValueObjects
{
    public class AvaliacaoVO
    {
        public long Id { get; set; }
        public DateTime DataReferencia { get; set; }
        public IEnumerable<AvaliacaoClienteVO> AvaliacoesDosClientes { get; set; }
        public int Pontuacao { get; set; }

    }
}
