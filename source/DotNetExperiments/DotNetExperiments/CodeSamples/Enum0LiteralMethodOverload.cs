using System;

namespace DotNetExperiments.CodeSamples
{
    public enum Color { Yellow, Green, Red }

    public static class Enum0MethodOverload
    {
        static void Bar(Color f) => Console.WriteLine("Enum");

        // After uncommenting this overload is chosen over the enum one
        static void Bar(int i) => Console.WriteLine("Does Y");

        public static void Invoke()
        {
            int a = 0;
            Bar(Color.Yellow);
            Bar(0);
            Bar(1);
            Bar(a);
        }
    }

    public static class Enum0MethodOverloadConstObject
    {
        static void Bar(object o) => Console.WriteLine("Object");
        static void Bar(Color f) => Console.WriteLine("Enum");

        public static void Invoke()
        {
            var a = 0;
            const int b = 0;

            Bar(a); // does x
            Bar(b); // does y
        }
    }
}
