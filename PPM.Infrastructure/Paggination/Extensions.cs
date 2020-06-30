using System.Collections.Generic;
using System.Linq;

namespace PPM.Infrastructure.Paggination
{
	public static class Extensions
	{
		private const int DefaultPagSize = 10;
		private const int DefaultPageNumber = 1;
		public static PagedList<T> ToPagedList<T>(this List<T> source, int pageNumber, int pageSize)
		{
			var count = source.Count();
			pageSize = pageSize <= 0 ? DefaultPagSize : pageSize;
			pageNumber = pageNumber <= 0 ? DefaultPageNumber : pageNumber;
			var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			return new PagedList<T>(items, count, pageNumber, pageSize);
		}

		public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
		{
			var count = source.Count();
			pageSize = pageSize <= 0 ? DefaultPagSize : pageSize;
			pageNumber = pageNumber <= 0 ? DefaultPageNumber : pageNumber;
			var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			return new PagedList<T>(items, count, pageNumber, pageSize);
		}
	}
}
