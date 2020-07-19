using System.Collections.Generic;

namespace Starwars.Abstraction.Dto.Paging
{
    public class PageResponseDto<T>
    {
        /// <summary>
        /// Current returned page number
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Count of pages for given query
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// Current returned page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total row count in table for given query
        /// </summary>
        public int RowCount { get; set; }
        public int FirstRowOnPage { get; set; }
        public int LastRowOnPage { get; set; }
        /// <summary>
        /// Query items
        /// </summary>
        public IList<T> Items { get; set; }
    }
}
