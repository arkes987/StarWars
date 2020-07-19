using System;
using System.Collections.Generic;

namespace Starwars.Abstraction.Models.Paging
{
    public class Page<T>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public IList<T> Items { get; set; }
    }
}
