using BackSistemaGestaoPlanosTelefonia.Models;

namespace BackSistemaGestaoPlanosTelefonia.Service
{
    public interface IPlanoDeSaudeService
    {
        IEnumerable<PlanoTelefone> GetAll();
        PlanoTelefone GetById(Guid id);
        void Add(PlanoTelefone categoria);
        void Update(PlanoTelefone planoDeSaude);
        void Delete(Guid id);
    }
}
