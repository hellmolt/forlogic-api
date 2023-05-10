using ForLogic.ClienteAPI.Data.ValueObjects;
using ForLogic.ClienteAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ForLogic.ClienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteVO>>> ObterTodos()
        {
            var clientes = await _repository.ObterTodos();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<ClienteVO>> ObterPorId(long id)
        {
            var cliente = await _repository.ObterPorId(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpGet("obter-por-cnpj/{cnpj}")]
        //[Authorize]
        public async Task<ActionResult<ClienteVO>> ObterPorCnpj(string cnpj)
        {
            var cliente = await _repository.ObterPorCnpj(cnpj);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpGet("pesquisar-por-nome/{nome}")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<ClienteVO>>> PesquisarPorNome(string nome)
        {
            if(string.IsNullOrEmpty(nome)) return BadRequest();
            var clientes =  await _repository.PesquisarPorNome(nome);
            if (clientes == null) return NotFound();
            return Ok(clientes);
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<ClienteVO>> Criar([FromBody] ClienteVO vo)
        {
            if (vo == null) return BadRequest();
            var cliente = await _repository.Criar(vo);
            return Ok(cliente);
        }

        [HttpPut]
        //[Authorize]
        public async Task<ActionResult<ClienteVO>> Atualizar([FromBody] ClienteVO vo)
        {
            if (vo == null) return BadRequest();
            var cliente = await _repository.Atualizar(vo);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Deletar(long id)
        {
            var status = await _repository.Deletar(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
