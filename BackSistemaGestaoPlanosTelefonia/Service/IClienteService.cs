using BackSistemaGestaoPlanosTelefonia.Models;

namespace BackSistemaGestaoPlanosTelefonia.Service
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetById(Guid id);
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Guid id);
    }
}
