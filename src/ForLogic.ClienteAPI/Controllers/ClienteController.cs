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
        [Authorize]
        public async Task<ActionResult<ClienteVO>> ObterPorId(long id)
        {
            var cliente = await _repository.ObterPorId(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ClienteVO>> Criar([FromBody] ClienteVO vo)
        {
            if (vo == null) return BadRequest();
            var cliente = await _repository.Criar(vo);
            return Ok(cliente);
        }

        [HttpPut]
        [Authorize]
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
