namespace SmartHint.Domain.Models
{
    public class PaginationHeader
    {
        public int CurrentPage { get; set; }
        public int ItensperPage { get; set; }
        public int TotalItens { get; set; }
        public int TotalPages { get; set; }

        public PaginationHeader(int currentPage, int itensperPage, int totalItens, int totalPages)
        {
            CurrentPage = currentPage;
            ItensperPage = itensperPage;
            TotalItens = totalItens;
            TotalPages = totalPages;
        }
    }
}
