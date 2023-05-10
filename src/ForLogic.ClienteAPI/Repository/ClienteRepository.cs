using AutoMapper;
using ForLogic.ClienteAPI.Data.ValueObjects;
using ForLogic.ClienteAPI.Model;
using ForLogic.ClienteAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace ForLogic.ClienteAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SQLContext _context;
        private IMapper _mapper;

        public ClienteRepository(SQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteVO>> ObterTodos()
        {
            List<Cliente> clientes = await _context.Clientes.ToListAsync();
            return _mapper.Map<List<ClienteVO>>(clientes);
        }

        public async Task<ClienteVO> ObterPorId(long id)
        {
            Cliente cliente = await _context.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ClienteVO>(cliente);
        }

        public async Task<ClienteVO> ObterPorNomeCliente(string nomeCliente)
        {
            Cliente cliente = await _context.Clientes.Where(c => c.NomeCliente == nomeCliente).FirstOrDefaultAsync();
            return _mapper.Map<ClienteVO>(cliente);
        }

        public async Task<ClienteVO> Criar(ClienteVO vo)
        {
            Cliente cliente = _mapper.Map<Cliente>(vo);
            if (_context.Clientes.Any(c => c.Cnpj == vo.Cnpj))
                throw new Exception("Já existe Cliente cadastrado com o mesmo cnpj");
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClienteVO>(cliente);
        }

        public async Task<ClienteVO> Atualizar(ClienteVO vo)
        {
            Cliente cliente = _mapper.Map<Cliente>(vo);
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClienteVO>(cliente);
        }

        public async Task<bool> Deletar(long id)
        {
            try
            {
                Cliente cliente = await _context.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync();
                if (cliente == null) return false;
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ClienteVO> ObterPorCnpj(string cnpj)
        {
            Cliente cliente = await _context.Clientes.Where(c => c.Cnpj == cnpj).FirstOrDefaultAsync();
            return _mapper.Map<ClienteVO>(cliente);
        }
    }
}
