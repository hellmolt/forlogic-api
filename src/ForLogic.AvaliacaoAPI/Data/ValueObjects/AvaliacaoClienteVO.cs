namespace ForLogic.AvaliacaoAPI.Data.ValueObjects
{
    public class AvaliacaoClienteVO
    {
        public long Id { get; set; }
        public ClienteVO Cliente { get; set; }
        public AvaliacaoVO Avaliacao { get; set; }
        public int Nota { get; set; }
        public string Motivo { get; set; }
        public DateTime DataAvaliacao { get; set; }
    }
}
