using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartHint.Domain.Models;

namespace SmartHint.Infrastruct.Context
{
    public class AppDbContext: DbContext
    {
        private IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration, DbContextOptions<AppDbContext> options) : base(options) 
        {}
        public DbSet<Cliente> Clientes { get; set; }
    }
}
