using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Service.Mappings
{
    public static class MappingExtensions
    {
        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
            => queryable.ProjectTo<TDestination>(configuration).ToListAsync();

        public static List<TDestination> ToNewListAsync<TSource, TDestination>(this List<TSource> sourceList, IMapper mapper)
        {
            List<TDestination> newList = new List<TDestination>();
            sourceList.ForEach(r => newList.Add(mapper.Map<TDestination>(r)));
            return newList;
        }
    }
}
