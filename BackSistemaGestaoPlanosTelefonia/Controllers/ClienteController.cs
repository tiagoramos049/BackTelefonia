using BackSistemaGestaoPlanosTelefonia.Models;
using BackSistemaGestaoPlanosTelefonia.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpGet("ObterTodos")]
        public IEnumerable<Cliente> Get()
        {
            return _clienteService.GetAll(); 
        }


        [HttpGet("{id}")]
        public ActionResult<Cliente> GetById(Guid id)
        {
            var cliente = _clienteService.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }


        [HttpPost("incluir")]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (cliente.ClientePlanos == null || cliente.ClientePlanos.Count == 0)
            {
                cliente.ClientePlanos = new List<ClientePlano>();  // Inicializa a lista vazia, caso não tenha planos.
            }

            _clienteService.Add(cliente);
            return Ok(cliente);
            
        }


        [HttpPut("alterar/{id}")]
        public IActionResult Put(Guid id, [FromBody] Cliente cliente)
        {
            if (cliente == null || cliente.Id != id)
            {
                return BadRequest();
            }

            _clienteService.Update(cliente); 
            return NoContent();
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(Guid id)
        {
            var produto = _clienteService.GetById(id);

            if (produto == null)
            {
                return NotFound();
            }

            _clienteService.Delete(id);
            return NoContent();
        }

    }
}
