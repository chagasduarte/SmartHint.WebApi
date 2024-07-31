using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartHint.Domain.Interfaces;
using SmartHint.Domain.Models;

namespace SmartHint.Domain.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=monorail.proxy.rlwy.net;Port=19735;Database=SmartHint;User=root;Password=hfTOivBbiGUJueruCKMQdhZhwlwJCriH");
        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
