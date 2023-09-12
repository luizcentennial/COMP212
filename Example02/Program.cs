using Example02.Factories;
using Example02.Models;
using System;

namespace Example02 {
	internal class Program {

		// GENERICS:
		//
		// C# generics are a powerful feature in C# that allow you to write classes,
		// methods, and interfaces that can work with different data types while maintaining
		// type safety at compile-time.
		//
		// Generics enable you to create reusable and flexible code that can work with a variety
		// of data types without sacrificing type checking.
		//
		// The main benefits it provides are:
		// - Reduced code footprint;
		// - Minimized logic duplication.

		static void Main(string[] args) {
			
			// Generic entities are specialized to specific types.
			// The generic class Factory was defined generically in terms of 'T',
			// and we can now specialize it to 'Person'.
			//
			// In practice, this means all features implemented generically in terms of 'T'
			// are now instantiated in terms of 'Person'.

			Factory<Person> genericFactory = new Factory<Person>();

			Person person = genericFactory.Create();
			person.Name = "John Smith";
			person.DateOfBirth = new DateTime(1985, 07, 15);

			Console.WriteLine(person);

			// We can instantiate specialize factories for anything. But is that ok?
			// Should I be more specific?

			// YES. You do not want to have "god-classes" that are used and abused across the
			// entire code base.
			// - What if you have to make a change?
			// - What if you accidentally introduce a bug?

			// The line below gives an error.
			//PersonFactory<int> badFactory = new PersonFactory<int>();

			// The factory below works well, and is a compartmentalized solution.
			// Changes to this class have zero impact on other factories.

			PersonFactory<Student> studentFactory = new PersonFactory<Student>();

			Student student = studentFactory.Create();
			student.Name = "Mary Smith";
			student.DateOfBirth = new DateTime(1995, 07, 15);
			student.StudentID = "01234321";

			Console.WriteLine(student);
        }
	}
}
