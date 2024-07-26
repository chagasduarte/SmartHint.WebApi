using System.ComponentModel.DataAnnotations;

namespace SmartHint.Domain.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefone { get; set; } = "";
        public int TipoPessoa { get; set; }
        public string CpfCnpj { get; set; } = "";
        public string InscricaoEstadual { get; set; } = "";
    }
}
