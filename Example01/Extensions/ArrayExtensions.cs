using System.Collections.Generic;

namespace Example01.Extensions {

	// Extension methods are defined in static classes.

	public static class ArrayExtensions {

		// Extension methods are defined as static methods.
		// The argument decorated with the keyword 'this' represents the type
		// to which the extension method will be attached to.

		public static string GetString<T>(this T[] collection) {
			return string.Join(' ', collection);
		}
		public static string GetString<T>(this IEnumerable<T> collection, char separator) {
			return string.Join(separator, collection);
		}
	}
}
