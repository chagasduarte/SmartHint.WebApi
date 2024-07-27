using System.ComponentModel.DataAnnotations;

namespace SmartHint.Domain.Models
{
    public class PaginationParams
    {
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }
        [Range(1, 50, ErrorMessage = "Limite máximo por página foi utrapassado")]
        public int PageSize { get; set; }
    }
}
