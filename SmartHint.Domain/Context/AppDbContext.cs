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
            optionsBuilder.UseMySQL("Server=monorail.proxy.rlwy.net;Port=22939;Database=SmartHint;User=root;Password=dvHhYNAZMuiEystkOboDLSDRoyaUaVMk");
        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
