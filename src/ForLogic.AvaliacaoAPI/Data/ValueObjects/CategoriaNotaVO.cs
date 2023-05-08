namespace ForLogic.AvaliacaoAPI.Data.ValueObjects
{
    public class CategoriaNotaVO
    {
        public long Id { get; set; }
        public string NomeCategoria { get; set; }
        public int NotaMinima { get; set; }
        public int NotaMaxima { get; set; }
    }
}
