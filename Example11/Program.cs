using System;

namespace Example11 {
    internal class Program {

        // ACTION DELEGATES:
        //
        // The Action type is a kind of delegate that
        // encapsulates a method that may take in parameters,
        // but does not return any value.
        //
        // It gives a more streamlined way for working with
        // delegates.

        static void Main(string[] args) {

            // Declaring Action delegates:
            Action del = SomeMethod;
            Action<string> del2 = AnotherMethod;

            // Invoking Action delegates:
            del.Invoke();
            del2.Invoke("AnotherMethod was called.");

            // Action delegates can also be passed in as
            // arguments.

            DynamicMethod(del);

            // Another interesting way to define delegates
            // is by using lambda functions. They provide
            // a practical way of defining free functions.

            Action del3 = () => {
                Console.WriteLine("Lambda function was called.");
            };

            del3();

            Action<string> del4 = (parameter) => {
                Console.WriteLine(parameter);
            };

            del4("Another lambda function was called.");

            // Action delegates also support multiple
            // parameter definitions.

            Action<string, int, bool> del5 = (message, number, boolean) => {
                Console.WriteLine(message);
                Console.WriteLine($"The number was {number}.");
                Console.WriteLine($"The Boolean was {boolean}.");
            };

            del5("Yet another lambda function runs.", 5, true);
        }

        private static void SomeMethod() {
            Console.WriteLine("SomeMethod was called.");
        }

        private static void AnotherMethod(string message) {
            Console.WriteLine(message);
        }

        private static void DynamicMethod(Action callback) {
            Console.WriteLine("DynamicMethod runs.");

            callback.Invoke();
        }
    }
}
