using SmartHint.Domain.Models;

namespace SmartHint.Domain.DTos
{
    public class ClienteResponse
    {
        public List<Cliente> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public ClienteResponse(List<Cliente> itens, int currentPage, int totalPage, int pageSize, int totalCount)
        {
            Items = itens;
            CurrentPage = currentPage;
            TotalPage = totalPage;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
    }
}
