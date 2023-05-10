using ForLogic.AvaliacaoAPI.Data.ValueObjects;
using ForLogic.AvaliacaoAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForLogic.AvaliacaoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoClienteController : ControllerBase
    {
        private IAvaliacaoClienteRepository _repository;

        public AvaliacaoClienteController(IAvaliacaoClienteRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvaliacaoClienteVO>>> ObterTodos()
        {
            var avaliacoes = await _repository.ObterTodos();
            return Ok(avaliacoes);
        }

        [HttpGet("{mes}/{ano}")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<AvaliacaoClienteVO>>> ObterAvalicoesDoscLientesPorPeriodo(int mes, int ano)
        {
            var avaliacoes = await _repository.ObterAvaliacoesDosClientesPorPeriodo(mes, ano);
            return Ok(avaliacoes);
        }

        [HttpPost()]
        //[Authorize]
        public async Task<ActionResult<AvaliacaoVO>> CriarAvaliacao(AvaliacaoClienteVO vo)
        {
            if (vo == null) return BadRequest();
            var avaliacao = await _repository.CriarAvalicaoDoCliente(vo);
            return Ok(avaliacao);
        }
    }
}
