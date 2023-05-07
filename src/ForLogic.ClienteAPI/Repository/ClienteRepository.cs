using AutoMapper;
using ForLogic.ClienteAPI.Data.ValueObjects;

namespace ForLogic.ClienteAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private IMapper _mapper;

        public ClienteRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<ClienteVO> Atualizar(ClienteVO vo)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteVO> Criar(ClienteVO vo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deletar(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteVO> ObterPorId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteVO> ObterPorNomeCliente(string nomeCliente)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteVO>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
