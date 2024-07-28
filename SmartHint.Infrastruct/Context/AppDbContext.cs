using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartHint.Domain.Models;

namespace SmartHint.Infrastruct.Context
{
    public class AppDbContext: DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {}
         
        public AppDbContext()
        {}
        
        public DbSet<Cliente> Clientes { get; set; }
    }
}
