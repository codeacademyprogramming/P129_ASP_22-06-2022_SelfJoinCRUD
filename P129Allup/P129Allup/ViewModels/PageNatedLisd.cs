using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P129Allup.ViewModels
{
    public class PageNatedLisd<T> : List<T>
    {
        public PageNatedLisd(IQueryable<T> query, int page, int pagecount, int itemcount)
        {
            Page = page;
            PageCount = pagecount;
            ItemCount = itemcount;
            HasNext = page < pagecount;
            HasPrev = page > 1;
            this.AddRange(query);
        }

        public int Page { get; }
        public int PageCount { get; }
        public int ItemCount { get; }
        public bool HasNext { get; }
        public bool HasPrev { get; }

        public static PageNatedLisd<T> Create(IQueryable<T> query, int page, int itemCount)
        {
            int pageCount = (int)Math.Ceiling((decimal)query.Count() / itemCount);

            page = page < 1 || page > pageCount ? 1 : page;

            query = query.Skip((page - 1) * itemCount).Take(itemCount);

            return new PageNatedLisd<T>(query, page, pageCount, itemCount);
        }
    }
}
