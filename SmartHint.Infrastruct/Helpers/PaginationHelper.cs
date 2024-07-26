using Microsoft.EntityFrameworkCore;
using SmartHint.Domain.DTos;

namespace SmartHint.Infrastruct.Helpers
{
    public class PaginationHelper
    {
        public static async Task<PagedList<T>> CreateAsync<T>(IQueryable<T> source, int pageNumber, int pageSize) where T: class
        {
            try
            {
                var count = await source.CountAsync();
                var items = await source.Skip((int)((pageNumber - 1) * pageSize)).Take(pageSize).ToListAsync();
                return new PagedList<T>(items, pageNumber, pageSize, count);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
