using Microsoft.CodeAnalysis.CSharp.Syntax;
using SmartHint.Domain.Models;
using System.Text.Json;

namespace SmartHint.WebApi.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, PaginationHeader header)
        {
            var jsonOptions = new JsonSerializerOptions {  PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOptions));
            response.Headers.Add("Acess-Control-Expose-Headers", "Paginations");
        }
    }
}
