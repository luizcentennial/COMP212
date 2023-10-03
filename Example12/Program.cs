using System;

namespace Example12 {
    internal class Program {

        // FUNCTION DELEGATES:
        //
        // The Func type is a kind of delegate that
        // encapsulates a method that may take in parameters
        // and returns value.
        //
        // It gives a more streamlined way for working with
        // delegates.

        static void Main(string[] args) {

            // Declaring Func delegates:
            Func<string> del = SomeMethod;

            // When passing multiple type parameters,
            // the last one is always the returning type.

            Func<string, string> del2 = AnotherMethod;

            // Invoking Func delegates:
            Console.WriteLine(del.Invoke());
            Console.WriteLine(del2.Invoke("AnotherMethod called"));

            // Func delegates can also be passed in as
            // arguments.

            Console.WriteLine(DynamicMethod(del));

            // Lambda functions work well with Func objects, too.

            Func<char, int> ascii = (character) => (int)character;

            Console.WriteLine(ascii('L'));
        }

        private static string SomeMethod() => "SomeMethod was called.";

        private static string AnotherMethod(string message) => $"The message was '{message}'.";

        private static string DynamicMethod(Func<string> callback) {
            Console.WriteLine("DynamicMethod runs.");

            return callback.Invoke();
        }
    }
}
