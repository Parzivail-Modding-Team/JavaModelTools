using System;
using System.Collections.Generic;

namespace JavaModelTools.Extensions
{
	public static class EnumerableExt
	{
		public static IEnumerable<T> Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> recursor)
		{
			var flattened = new List<T>();

			foreach (var child in source)
			{
				flattened.Add(child);
				flattened.AddRange(recursor(child).Flatten(recursor));
			}

			return flattened;
		}
	}
}