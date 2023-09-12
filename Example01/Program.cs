using Example01.Extensions;
using System;

namespace Example01 {
	internal class Program {
		static void Main(string[] args) {
			// EXTENSION METHODS:
			// Extension methods allow you to add convenience to existing types
			// by adding custom methods that are not part of the original class definition.

			// For example, let's look at the integer array below.
			// As we know, Console.WriteLine methods are not capable of printing array elements
			// directly.

			int[] array = { 1, 2, 3, 4, 5 };
			Console.WriteLine(array);

			// If we would like to display the array in a more useful way,
			// we need to, for example, manually join its elements.

			string arrayElements = string.Empty;

			for (int i = 0; i < array.Length; i++)
				arrayElements += $"{array[i]} ";

			Console.WriteLine(arrayElements);

            // The solution above, at a first glance, looks fine. However, if this is something
            // we need to do often, it might become a bit of a hassle to include all three lines
            // of code every single time we need it.

            // The better way: Extension Methods.
            // The static class Extensions.ArrayExtensions provides the definition of a generic
            // extension method that allow us to translate the array to string more easily.

            Console.WriteLine(array.GetString<int>());

			// For conciseness, we can reduce the statement above to the following form. 
			// The compiler is capable of implying the type T from context.

			Console.WriteLine(array.GetString());
		}
	}
}
