using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Domain.Pagination
{

    public class PaginatedList<T>
    {
        public int Count { get; set; }
        public List<T> Items { get; set; }
    }
    public class PaginatedResponse<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginatedResponse(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return PageIndex > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageIndex < TotalPages;
            }
        }

        public static PaginatedList<T> Create(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            if (pageSize == 0)
                return new PaginatedList<T>{
                    Count = count,
                    Items = source.ToList(),
                };

            if (pageIndex == 0) pageIndex = 1;
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>
            {
                Count = count,
                Items = items,
            };
        }

    }
}
