using ForLogic.ClienteAPI.Data.ValueObjects;

namespace ForLogic.ClienteAPI.Repository
{
    public interface IAvaliacaoRepository
    {
        Task<IEnumerable<AvaliacaoVO>> ObterTodos();
        Task<AvaliacaoVO> ObterPorId(long id);
        Task<AvaliacaoVO> Criar(AvaliacaoVO vo);
        Task<AvaliacaoVO> Atualizar(AvaliacaoVO vo);
        Task<bool> Deletar(long id);
    }
}
