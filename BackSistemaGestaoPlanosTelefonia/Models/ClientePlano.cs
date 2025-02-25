using System.Numerics;

namespace BackSistemaGestaoPlanosTelefonia.Models
{
    public class ClientePlano
    {
        public ClientePlano()
        {
            Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }
        public Guid? ClienteId { get; set; }
        public Cliente? Cliente { get; set; } 
        public Guid? PlanoId { get; set; }
        public PlanoTelefone? Plano { get; set; }
        
    }
}

