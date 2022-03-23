using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetExperiments.CodeSamples
{
    class ReadonlyRefVsRefReadonlnStruct
    {
        struct Point3D
        {
            private static Point3D _origin;
            private int innerState;

            public ref readonly Point3D RefReadonly => ref _origin;
            public readonly ref Point3D ReadonlyRef => ref _origin;

            public double X { get; }
            public double Y { get; }
            public double Z { get; }

            public readonly ref readonly Point3D ReadonlyRefReadonlyFull
            {
                get
                {
                    //innerState = 5;
                    return ref _origin;
                }
            }

            public ref readonly Point3D RefReadonlyFull
            {
                get
                {
                    innerState = 5;
                    return ref _origin;
                }
            }

            public readonly ref Point3D ReadonlyRefFull
            {
                get
                {
                    innerState = 5;
                    return ref _origin;
                }
            }
        }

        public void Run()
        {
            var point = new Point3D();

            // ref readonly
            ref readonly var refReadonly = ref point.RefReadonly;
            ref var refReadonly2 = ref point.RefReadonly;
            
            // readonly ref
            ref readonly var readonlyRef = ref point.ReadonlyRef;
            ref var readonlyRef2 = ref point.ReadonlyRef;

            var a = point.RefReadonly;
            var b = point.ReadonlyRef;
            var c = point.ReadonlyRefReadonlyFull;

            refReadonly = new Point3D();
            readonlyRef = new Point3D();
            readonlyRef2 = new Point3D();

            point.ReadonlyRef = new Point3D();
            point.RefReadonly = new Point3D();
        }
    }

    public class RefExample
    {
        private readonly int[] _ages = { 1, 2, 3, 4 };
        public ref int GetAgeByRef(int i) => ref _ages[i];
        public int GetAge(int i) => _ages[i];

        public void Execute()
        {
            int age = GetAge(0);
            age = 10;

            Console.WriteLine(_ages[0]);

            ref int ageByRef = ref GetAgeByRef(0);
            ageByRef = 10;

            Console.WriteLine(_ages[0]);
        }
    }

    public struct RefReadonlyExample
    {
        private static readonly int[] _ages = { 1, 2, 3, 4 };
        public int GetAge(int i) => _ages[i];
        public ref int GetAgeByRef(int i) => ref _ages[i];
        public readonly ref int GetAgeByRefReadonly(int i ) => ref _ages[i];

        public void Execute()
        {
            int age = GetAge(0);
            age = 10;

            Console.WriteLine(_ages[0]);

            ref int ageByRef = ref GetAgeByRef(0);
            ageByRef = 10;

            Console.WriteLine(_ages[0]);

            ref readonly int ageByRefReadonly = ref GetAgeByRefReadonly(0);
            ageByRefReadonly = 10; // Compilation error CS0131
        }
    }

    struct ExampleStruct
    {
        private int _x;
        private int _y;

        public readonly string GetRepresentation() => $"X: {_x}, Y: {_y}";
    }
}
