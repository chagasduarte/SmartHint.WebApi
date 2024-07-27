using Microsoft.EntityFrameworkCore;
using SmartHint.Infrastruct.Context;
using System.ComponentModel.DataAnnotations;

namespace SmartHint.Infrastruct.Helpers.Validations
{
    public class EmailInUseAttribulte : ValidationAttribute
    {
        private readonly AppDbContext _context;
        public EmailInUseAttribulte(AppDbContext context)
        {
            _context = context;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            
            return _context.Clientes.Where(x => x.Email == (string)value).Count() > 0
                ? new ValidationResult(errorMessage: "O Email Já está em uso")
                : ValidationResult.Success;
        }
    }
}
