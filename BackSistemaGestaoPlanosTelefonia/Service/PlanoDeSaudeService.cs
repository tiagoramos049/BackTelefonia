using BackSistemaGestaoPlanosTelefonia.Data;
using BackSistemaGestaoPlanosTelefonia.Models;

namespace BackSistemaGestaoPlanosTelefonia.Service
{
    public class PlanoDeSaudeService : IPlanoDeSaudeService
    {
        private readonly Context _context;

        public PlanoDeSaudeService(Context context)
        {
            _context = context;
        }

        public IEnumerable<PlanoTelefone> GetAll()
        {
            return _context.PlanosDeSaude.ToList();
        }

        public PlanoTelefone GetById(Guid id)
        {
            return _context.PlanosDeSaude.FirstOrDefault(p => p.Id == id)!;
        }

        public void Add(PlanoTelefone planoDeSaude)
        {
            // Adiciona o plano
            _context.PlanosDeSaude.Add(planoDeSaude);

            // Se houver planos associados (ClientePlanos), também deve-se adicionar esses ao contexto
            if (planoDeSaude.ClientePlanos != null)
            {
                _context.ClientePlanos.AddRange(planoDeSaude.ClientePlanos);
            }

            // Salva todas as alterações no banco de dados
            _context.SaveChanges();
        }

        public void Update(PlanoTelefone planoDeSaude)
        {
            _context.PlanosDeSaude.Update(planoDeSaude);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var planoDeSaude = GetById(id);
            if (planoDeSaude != null)
            {
                _context.PlanosDeSaude.Remove(planoDeSaude);
                _context.SaveChanges();
            }
        }
    }
}
