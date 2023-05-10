using ForLogic.AvaliacaoAPI.Data.ValueObjects;

namespace ForLogic.AvaliacaoAPI.Repository
{
    public interface IAvaliacaoClienteRepository
    {
        Task<IEnumerable<AvaliacaoClienteVO>> ObterTodos();
        Task<IEnumerable<AvaliacaoClienteVO>> ObterAvaliacoesPorCliente(long clienteId);
        Task<IEnumerable<AvaliacaoClienteVO>> ObterAvaliacoesDosClientesPorAvaliacaoPeriodica(long avaliacaoId);
        Task<IEnumerable<AvaliacaoClienteVO>> ObterAvaliacoesDosClientesPorPeriodo(int mes, int ano);
        Task<AvaliacaoClienteVO> CriarAvalicaoDoCliente(AvaliacaoClienteVO avaliacaoCliente);
        Task<bool> RemoverAvalicaoDoCliente(long avaliacaoClienteId);
    }
}
