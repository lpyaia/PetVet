using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVet.Application.Common.Models
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; }

        public int PageIndex { get; }

        public int TotalPages { get; }

        public int TotalCount { get; }

        private PaginatedList(List<T> items, int pageIndex, int totalCount, int pageSize)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            TotalCount = totalCount;
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HaxNextPage => PageIndex < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageSize - 1) * pageIndex).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, pageIndex, count, pageSize);
        }
    }
}