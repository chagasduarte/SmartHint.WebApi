using SmartHint.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace SmartHint.Domain.Models
{
    [ClienteValido]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [StringLength(150)]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(150)]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Telefone Obrigatório")]
        [StringLength(11)]
        public string Telefone { get; set; } = "";

        [Required(ErrorMessage = "Tipo Pessoa Obrigatório")]
        public TipoPessoa TipoPessoa { get; set; }
       
        [Required(ErrorMessage = "CpfCnpj Obrigatório")]
        [StringLength(14)]
        public string CpfCnpj { get; set; } = "";

        [StringLength(12)]
        public string InscricaoEstadual { get; set; } = "";

        [Required(ErrorMessage = "Data Cadastro Obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        [Required(ErrorMessage ="Senha obrigatória")]
        [StringLength(15)]
        public string Senha { get; set; }

        public OrientacaoSexual? Sexo { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        public Boolean InscricaoEstadualPessoaFisica { get; set; }
        
        public Cliente() 
        { 
            DataCadastro = DateTime.Now;
        }

    }
}
