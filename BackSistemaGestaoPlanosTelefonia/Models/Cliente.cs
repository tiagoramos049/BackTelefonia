namespace BackSistemaGestaoPlanosTelefonia.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public ICollection<ClientePlano>? ClientePlanos { get; set; }
    }
}
