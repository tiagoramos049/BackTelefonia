using BackSistemaGestaoPlanosTelefonia.Data;
using BackSistemaGestaoPlanosTelefonia.Models;
using Microsoft.EntityFrameworkCore;

namespace BackSistemaGestaoPlanosTelefonia.Service
{
    public class ClienteService : IClienteService
    {
        private readonly Context _context;

        public ClienteService(Context context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente GetById(Guid id)
        {
            return _context.Clientes.FirstOrDefault(p => p.Id == id)!;
        }

        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

        }

        public void Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var cliente = GetById(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
