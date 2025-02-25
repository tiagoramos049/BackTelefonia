using BackSistemaGestaoPlanosTelefonia.Models;
using BackSistemaGestaoPlanosTelefonia.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackSistemaGestaoPlanosTelefonia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("Indicadores")]
        public ActionResult<IndicadoresDTO> GetIndicadores()
        {
            var indicadores = _dashboardService.GetIndicadores();
            if (indicadores == null)
            {
                return NotFound("Indicadores não encontrados.");
            }
            return Ok(indicadores);
        }
    }
}
