using AutoMapper;
using ForLogic.AvaliacaoAPI.Data.ValueObjects;
using ForLogic.AvaliacaoAPI.Model;
using ForLogic.AvaliacaoAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace ForLogic.AvaliacaoAPI.Repository
{
    public class AvaliacaoClienteRepository : IAvaliacaoClienteRepository
    {
        private readonly SQLContext _context;
        private IMapper _mapper;

        public AvaliacaoClienteRepository(SQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AvaliacaoClienteVO> CriarAvalicaoDoCliente(AvaliacaoClienteVO avaliacaoCliente)
        {
            AvaliacaoCliente avaliacaoClienteParaCriar = _mapper.Map<AvaliacaoCliente>(avaliacaoCliente);
            avaliacaoClienteParaCriar.DataAvaliacao = DateTime.Now;

            Avaliacao avaliacaoPeriodica = await _context.Avaliacoes.FirstOrDefaultAsync(a =>
                a.DataReferencia.Month == avaliacaoClienteParaCriar.DataAvaliacao.Month
                && a.DataReferencia.Year == avaliacaoClienteParaCriar.DataAvaliacao.Year);
            if(avaliacaoPeriodica == null)
            {
                avaliacaoPeriodica = new Avaliacao() { DataReferencia = avaliacaoClienteParaCriar.DataAvaliacao };
                _context.Avaliacoes.Add(avaliacaoPeriodica);
                _context.SaveChanges();
            }
            avaliacaoClienteParaCriar.Avaliacao = avaliacaoPeriodica;
            avaliacaoClienteParaCriar.AvaliacaoId = avaliacaoPeriodica.Id;

            Cliente clienteDaAvaliacao = await _context.Clientes.FirstOrDefaultAsync(c =>
    c.Id == avaliacaoClienteParaCriar.ClienteId || c.Cnpj == avaliacaoClienteParaCriar.Cliente.Cnpj);
            if (clienteDaAvaliacao == null)
            {
                throw new Exception("Cliente associado nao existe na base");
            }

            CategoriaNota categoriaNota = await _context.CategoriasDeNota.FirstOrDefaultAsync(c => c.NotaMinima <= avaliacaoCliente.Nota && c.NotaMaxima >= avaliacaoCliente.Nota);
            avaliacaoClienteParaCriar.CategoriaNota = categoriaNota;
            avaliacaoClienteParaCriar.CategoriaNotaId = categoriaNota.Id;

            _context.AvaliacoesDosClientes.Add(avaliacaoClienteParaCriar);

            await _context.SaveChangesAsync();
            return _mapper.Map<AvaliacaoClienteVO>(avaliacaoClienteParaCriar);
        }

        public async Task<IEnumerable<AvaliacaoClienteVO>> ObterAvaliacoesDosClientesPorAvaliacaoPeriodica(long avaliacaoId)
        {
            List<AvaliacaoCliente> avaliacoesDosClientes = await _context.AvaliacoesDosClientes.Where(a => a.AvaliacaoId == avaliacaoId).ToListAsync();
            return _mapper.Map<List<AvaliacaoClienteVO>>(avaliacoesDosClientes);
        }

        public async Task<IEnumerable<AvaliacaoClienteVO>> ObterAvaliacoesDosClientesPorPeriodo(int mes, int ano)
        {
            List<AvaliacaoCliente> avaliacoesDosClientes = await _context.AvaliacoesDosClientes.Where(a => 
                a.DataAvaliacao.Month == mes
                && a.DataAvaliacao.Year == ano).ToListAsync();
            return _mapper.Map<List<AvaliacaoClienteVO>>(avaliacoesDosClientes);
        }

        public async Task<IEnumerable<AvaliacaoClienteVO>> ObterAvaliacoesPorCliente(long clienteId)
        {
            List<AvaliacaoCliente> avaliacoesCliente = await _context.AvaliacoesDosClientes.Where(a =>
                a.ClienteId == clienteId).ToListAsync();
            return _mapper.Map<List<AvaliacaoClienteVO>>(avaliacoesCliente);
        }

        public async Task<IEnumerable<AvaliacaoClienteVO>> ObterTodos()
        {
            List<AvaliacaoCliente> avaliacoesCliente = await _context.AvaliacoesDosClientes.ToListAsync();
            return _mapper.Map<List<AvaliacaoClienteVO>>(avaliacoesCliente);
        }

        public Task<bool> RemoverAvalicaoDoCliente(long avaliacaoClienteId)
        {
            throw new NotImplementedException();
        }

        //public Task<bool> RemoverAvalicaoDoCliente(long avaliacaoClienteId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
