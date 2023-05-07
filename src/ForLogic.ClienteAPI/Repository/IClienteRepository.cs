using ForLogic.ClienteAPI.Data.ValueObjects;

namespace ForLogic.ClienteAPI.Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<ClienteVO>> ObterTodos();
        Task<ClienteVO> ObterPorId(long id);
        Task<ClienteVO> Criar(ClienteVO vo);
        Task<ClienteVO> Atualizar(ClienteVO vo);
        Task<bool> Deletar(long id);
    }
}
