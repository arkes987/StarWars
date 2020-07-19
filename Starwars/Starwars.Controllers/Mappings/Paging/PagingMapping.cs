using Starwars.Abstraction.Dto.Paging;
using Starwars.Abstraction.Interfaces.Mappings;
using Starwars.Data.Extensions.Paging;
using System;
using System.Linq;

namespace Starwars.Controllers.Mappings.Paging
{
    public class PagingMapping<TOut, TIn> : IPagingMapping<TOut,TIn> where TOut : class where TIn : class
    {
        public PageResponseDto<TOut> ToPageResponseDto(PagedResult<TIn> page, Func<TIn, TOut> itemMappingFunction)
        {
            return new PageResponseDto<TOut>
            {
                CurrentPage = page.CurrentPage,
                PageCount = page.PageCount,
                PageSize = page.PageSize,
                RowCount = page.RowCount,
                FirstRowOnPage = page.FirstRowOnPage,
                LastRowOnPage = page.LastRowOnPage,
                Items = page.Results.Select(itemMappingFunction).ToArray()
            };
        }
    }
}
