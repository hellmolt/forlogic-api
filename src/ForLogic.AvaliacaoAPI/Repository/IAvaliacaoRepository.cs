using ForLogic.AvaliacaoAPI.Data.ValueObjects;

namespace ForLogic.AvaliacaoAPI.Repository
{
    public interface IAvaliacaoRepository
    {
        Task<IEnumerable<AvaliacaoVO>> ObterTodos();
        Task<IEnumerable<AvaliacaoVO>> ObterAvalicaoPorPeriodo(int mes, int ano);
        Task<AvaliacaoVO> CriarAvalicao(AvaliacaoVO avaliacao);
        Task<AvaliacaoVO> AtualizarAvalicao(AvaliacaoVO avaliacao);
        Task<bool> RemoverAvalicao(long avaliacaoId);
    }
}
