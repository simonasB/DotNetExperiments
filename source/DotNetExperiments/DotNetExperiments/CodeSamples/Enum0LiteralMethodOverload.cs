using System;

namespace DotNetExperiments.CodeSamples
{
    public enum Color
    {
        Blue,
        Red,
        Yellow
    }

    public static class Enum0MethodOverload
    {
        static void Bar(Color f) => Console.WriteLine("Does X");

        // After uncommenting this overload is chosen over the enum one
        static void Bar(int i) => Console.WriteLine("Does Y");

        public static void Invoke()
        {
            Bar(Color.Blue);
            Bar(0);
        }
    }

    public static class Enum0MethodOverloadConstObject
    {
        static void Bar(object o) => Console.WriteLine("Does X");
        static void Bar(Color f) => Console.WriteLine("Does Y");

        public static void Invoke()
        {
            var a = 0;
            const int b = 0;

            Bar(a); // does x
            Bar(b); // does y
        }
    }
}
