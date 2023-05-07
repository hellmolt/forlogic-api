namespace ForLogic.ClienteAPI.Data.ValueObjects
{
    public class AvaliacaoVO
    {
        public long Id { get; set; }
        public string NomeCliente { get; set; }
        public string NomeContato { get; set; }
        public string Cnpj { get; set; }
        public DateTime? DataInsercao { get; set; }
    }
}
