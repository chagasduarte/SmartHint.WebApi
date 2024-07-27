using System.ComponentModel.DataAnnotations;

namespace SmartHint.Domain.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public string Nome { get; set; } = "";
        [Required]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = "";
        [Required]
        public string Telefone { get; set; } = "";
        [Required]
        public TipoPessoa TipoPessoa { get; set; }
        [Required]
        public string CpfCnpj { get; set; } = "";
        [Required]
        public string InscricaoEstadual { get; set; } = "";
        [Required]
        public DateTime DataCadastro { get; set; }
        
        public Cliente() 
        { 
            DataCadastro = DateTime.Now;
        }

    }
}
