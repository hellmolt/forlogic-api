using AutoMapper;
using ForLogic.ClienteAPI.Data.ValueObjects;
using ForLogic.ClienteAPI.Model;
using ForLogic.ClienteAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace ForLogic.ClienteAPI.Repository
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly SQLContext _context;
        private IMapper _mapper;

        public AvaliacaoRepository(SQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AvaliacaoVO>> ObterTodos()
        {
            List<Avaliacao> clientes = await _context.Clientes.ToListAsync();
            return _mapper.Map<List<AvaliacaoVO>>(clientes);
        }

        public async Task<AvaliacaoVO> ObterPorId(long id)
        {
            Avaliacao cliente = await _context.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync() ?? new Avaliacao();
            return _mapper.Map<AvaliacaoVO>(cliente);
        }

        public async Task<AvaliacaoVO> ObterPorNomeCliente(string nomeCliente)
        {
            Avaliacao cliente = await _context.Clientes.Where(c => c.NomeCliente == nomeCliente).FirstOrDefaultAsync() ?? new Avaliacao();
            return _mapper.Map<AvaliacaoVO>(cliente);
        }

        public async Task<AvaliacaoVO> Criar(AvaliacaoVO vo)
        {
            Avaliacao cliente = _mapper.Map<Avaliacao>(vo);
            if (_context.Clientes.Any(c => c.Cnpj == vo.Cnpj))
                throw new Exception("Já existe Cliente cadastrado com o mesmo cnpj");
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<AvaliacaoVO>(cliente);
        }

        public async Task<AvaliacaoVO> Atualizar(AvaliacaoVO vo)
        {
            Avaliacao cliente = _mapper.Map<Avaliacao>(vo);
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<AvaliacaoVO>(cliente);
        }

        public async Task<bool> Deletar(long id)
        {
            try
            {
                Avaliacao cliente = await _context.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync() ?? new Avaliacao();
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




    }
}
