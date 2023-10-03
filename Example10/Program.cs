using System;

namespace Example10 {
    internal class Program {

        // DELEGATES:
        //
        // Delegates are a type that represents instances
        // of methods. It is a "wrapper" object that encapsulates a method
        // (or an instance thereof).
        //
        // Delegates:
        //
        // - Are similar to C++ function pointers.
        // - Allow methods to be passed as parameters.
        // - Can be used to define callback methods.

        // Defining a delegate:
        private delegate void MyDelegate();

        static void Main(string[] args) {

            // Instantiating delegate:
            MyDelegate del = SomeMethod;

            // The delegate above wraps SomeMethod.
            // Note how the method and delegate signatures match.
            // All valid method signatures are valid delegate signatures.

            // Invoking delegate:
            del.Invoke();

            // A common use-case for delegates is to use it
            // as callback functions. This technique allows for
            // powerful method customization while respecting
            // the program's logical structure.

            DynamicMethod(del);

            // In this example, DynamicMethod can be easily 
            // customized to behave in different ways, based
            // on the specified delegate.

            MyDelegate del2 = AnotherMethod;

            DynamicMethod(del2);
        }

        private static void SomeMethod() {
            Console.WriteLine("SomeMethod was called.");
        }

        private static void DynamicMethod(MyDelegate callback) {
            Console.WriteLine("DynamicMethod runs.");

            callback.Invoke();
        }

        private static void AnotherMethod() {
            Console.WriteLine("AnotherMethod was called.");
        }
    }
}
