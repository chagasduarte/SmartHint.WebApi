using SmartHint.Domain.Models;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace SmartHint.Domain.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
    }
}
