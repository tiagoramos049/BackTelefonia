using BackSistemaGestaoPlanosTelefonia.Models;
using BackSistemaGestaoPlanosTelefonia.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoTelefoniaController : ControllerBase
    {
        private readonly IPlanoDeSaudeService _planoDeSaudeService;

        public PlanoTelefoniaController(IPlanoDeSaudeService planoDeSaudeService)
        {
            _planoDeSaudeService = planoDeSaudeService;
        }


        [HttpGet("ObterTodos")]
        public IEnumerable<PlanoTelefone> Get()
        {
            return _planoDeSaudeService.GetAll(); 
        }


        [HttpGet("{id}")]
        public ActionResult<PlanoTelefone> GetById(Guid id)
        {
            var categoria = _planoDeSaudeService.GetById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }


        [HttpPost("incluir")]
        public IActionResult Post([FromBody] PlanoTelefone planoDeSaude)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(errors); // Retorne os erros de validação
            }

            if (planoDeSaude.ClientePlanos == null || planoDeSaude.ClientePlanos.Count == 0)
            {
                planoDeSaude.ClientePlanos = new List<ClientePlano>
                {
                    new ClientePlano
                    {
                        ClienteId = planoDeSaude.ClienteId,  // O clienteId vindo do frontend
                        PlanoId = planoDeSaude.Id // O PlanoId já está presente
                    }
                };
            }

            _planoDeSaudeService.Add(planoDeSaude);  // Salvar o plano no banco de dados
            return CreatedAtAction(nameof(Get), new { id = planoDeSaude.Id }, planoDeSaude);
        }


        [HttpPut("alterar/{id}")]
        public IActionResult Put(Guid id, [FromBody] PlanoTelefone planoDeSaude)
        {
            if (planoDeSaude == null || planoDeSaude.Id != id)
            {
                return BadRequest();
            }

            _planoDeSaudeService.Update(planoDeSaude); 
            return NoContent();
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(Guid id)
        {
            var categoria = _planoDeSaudeService.GetById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            _planoDeSaudeService.Delete(id);
            return NoContent();
        }
    }
}
