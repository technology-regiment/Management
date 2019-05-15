using System.Collections.Generic;

namespace Background.Logic.ViewModel
{
    public class Pagination
    {
        public int PageSize { get; set; }
        public int Total { get; set; }
        public int Current { get; set; }

        public Pagination(int pageSize, int total, int current)
        {
            PageSize = pageSize;
            Total = total;
            Current = current;
        }
    }

    public class PagedCollection<T> where T : class
    {
        public PagedCollection(int pageNumber, int totalRecordes, int perPageResults, IEnumerable<T> list)
        {
            Results = list;
            Pagination = new Pagination(perPageResults, totalRecordes, pageNumber);
        }
        public IEnumerable<T> Results { get; set; }
        public Pagination Pagination { get; set; }
    }
}
