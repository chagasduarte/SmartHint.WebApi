using SmartHint.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace SmartHint.Domain.Models
{
    [ClienteValido]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = "";

        [Required]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(150)]
        public string Email { get; set; } = "";

        [Required]
        [StringLength(11)]
        public string Telefone { get; set; } = "";

        [Required]
        public TipoPessoa TipoPessoa { get; set; }
       
        [Required]
        [StringLength(14)]
        public string CpfCnpj { get; set; } = "";

        [Required]
        public string InscricaoEstadual { get; set; } = "";

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        [Required]
        [StringLength(15)]
        public string Senha { get; set; }

        public OrientacaoSexual? Sexo { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? DataNascimento { get; set; }
        
        public Cliente() 
        { 
            DataCadastro = DateTime.Now;
        }

    }
}
