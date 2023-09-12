﻿using System.Collections.Generic;

namespace Example24 {
	class Program {

		// DICTIONARIES:
		//
		// A dictionary is collection of key-value pairs,
		// where each key is unique and linked to a corresponding value.
		// This design allows you to look up a value quickly and efficiently if
		// the associated key is known, avoiding the expensive traversal through the
		// entire list of values.
		//
		// - Dictionaries are dynamically sized.
		// - Dictionaries are strongly typed.

		static void Main(string[] args) {
			Dictionary<int, string> dictionary = new Dictionary<int, string>();

			// Adding to dictionary:
			dictionary.Add(123, "John");
			dictionary.Add(321, "Mary");

			// Accessing dictionary items:
			string person = dictionary[123]; // "John"
		}
	}
}
