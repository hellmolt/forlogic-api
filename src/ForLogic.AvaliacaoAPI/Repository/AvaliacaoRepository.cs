using AutoMapper;
using ForLogic.AvaliacaoAPI.Data.ValueObjects;
using ForLogic.AvaliacaoAPI.Model;
using ForLogic.AvaliacaoAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace ForLogic.AvaliacaoAPI.Repository
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
            List<Avaliacao> avaliacoes = await _context.Avaliacoes.ToListAsync();
            return _mapper.Map<List<AvaliacaoVO>>(avaliacoes);
        }

        public async Task<IEnumerable<AvaliacaoVO>> ObterAvalicaoPorPeriodo(int mes, int ano)
        {
            List<Avaliacao> avaliacoes = await _context.Avaliacoes.Where(a => 
                a.DataReferencia.Year == ano && 
                a.DataReferencia.Month == mes).ToListAsync();

            return _mapper.Map<List<AvaliacaoVO>>(avaliacoes);
        }

        public async Task<AvaliacaoVO> CriarAvalicao(AvaliacaoVO avaliacao)
        {
            Avaliacao avaliacaoParaCriar = _mapper.Map<Avaliacao>(avaliacao);
            _context.Avaliacoes.Add(avaliacaoParaCriar);
            await _context.SaveChangesAsync();
            return _mapper.Map<AvaliacaoVO>(avaliacaoParaCriar);
        }

        public async Task<AvaliacaoVO> AtualizarAvalicao(AvaliacaoVO avaliacao)
        {
            Avaliacao avaliacaoParaAtualizar = _mapper.Map<Avaliacao>(avaliacao);
            _context.Avaliacoes.Update(avaliacaoParaAtualizar);
            await _context.SaveChangesAsync();
            return _mapper.Map<AvaliacaoVO>(avaliacaoParaAtualizar);
        }

        public async Task<bool> RemoverAvalicao(long avaliacaoId)
        {
            try
            {
                Avaliacao avaliacaoParaDeletar = await _context.Avaliacoes.Where(a => a.Id == avaliacaoId).FirstOrDefaultAsync() ?? new Avaliacao();
                if (avaliacaoParaDeletar == null) return false;
                _context.Avaliacoes.Remove(avaliacaoParaDeletar);
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
