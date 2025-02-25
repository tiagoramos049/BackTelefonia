using BackSistemaGestaoPlanosTelefonia.Data;
using BackSistemaGestaoPlanosTelefonia.Models;

namespace BackSistemaGestaoPlanosTelefonia.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly Context _context;
        public DashboardService(Context context)
        {
            _context = context;
        }

        public IndicadoresDTO GetIndicadores()
        {
            var totalClientes = _context.Clientes.Count();
            var totalPlanos = _context.PlanosDeSaude.Count();
            var totalPlanosAssociados = _context.ClientePlanos.Count();

            var mediaPlanosPorCliente = totalClientes > 0 ? (double)totalPlanosAssociados / totalClientes : 0;

            return new IndicadoresDTO
            {
                TotalClientes = totalClientes,
                TotalPlanos = totalPlanos,
                MediaPlanosPorCliente = mediaPlanosPorCliente
            };
        }
    }
}
