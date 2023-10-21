using FileExplorer.Application.Common.Models.Filtering;

namespace FileExplorer.Application.Querying.Extensions
{
    public static class LinqExtensions
    {

        public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> source, FilterPagination paginationOptions)
        {
            return source.Skip((paginationOptions.PageToken - 1) * paginationOptions.PageSize).Take(paginationOptions.PageSize);
        }

        public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> source, FilterPagination paginationOptions)
        {
            return source.Skip((paginationOptions.PageToken - 1) * paginationOptions.PageSize).Take(paginationOptions.PageSize);
        }
    }
}
