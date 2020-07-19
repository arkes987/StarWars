using Starwars.Abstraction.Dto.Paging;
using Starwars.Data.Extensions.Paging;
using System;

namespace Starwars.Abstraction.Interfaces.Mappings
{
    public interface IPagingMapping<TOut, TIn> where TOut : class where TIn : class
    {
        PageResponseDto<TOut> ToPageResponseDto(PagedResult<TIn> page, Func<TIn, TOut> itemMappingFunction);
    }
}
