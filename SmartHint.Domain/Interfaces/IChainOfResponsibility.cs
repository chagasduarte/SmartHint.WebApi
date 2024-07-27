using SmartHint.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHint.Domain.Interfaces
{
    public interface IChainOfResponsibility
    {
        public ValidationModel Validation(Cliente cliente);

    }
}
