namespace BackSistemaGestaoPlanosTelefonia.Models
{
    public class PlanoTelefone
    {
        public PlanoTelefone()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public int FranquiaDados { get; set; }
        public int MinutosLigacao { get; set; }
        public ICollection<ClientePlano>? ClientePlanos { get; set; }
    }
}
