using System;

namespace Example13 {
    internal class Program {

        // PREDICATE DELEGATES:
        //
        // The Predicate type is a kind of delegate that
        // encapsulates a method that takes in at least one parameter
        // and returns a Boolean value.
        //
        // It gives a more streamlined way for working with
        // delegates.

        static void Main(string[] args) {

            // Declaring Predicate delegates:
            Predicate<int> del = IsFive;

            // Invoking Predicate delegates:
            if (del.Invoke(5))
                Console.WriteLine("Number is five.");
            else
                Console.WriteLine("Number is not five.");

            // Predicates work well with lambda functions, too.

            Predicate<string> del2 = (text) => int.TryParse(text, out _);

            if (del2("Two"))
                Console.WriteLine("Parseable as int.");
            else
                Console.WriteLine("Not parseable as int.");
        }

        private static bool IsFive(int number) {
            return number == 5;
        }
    }
}
