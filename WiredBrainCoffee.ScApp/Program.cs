using System;

namespace WiredBrainCoffee.ScApp
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new Container<string>();
            _ = new Container<string>();
            //_ = new Container<int>();
            var container = new Container<int>();

            Console.WriteLine($"Container<string>: {Container<string>.InstanceCount}");
            Console.WriteLine($"Container<int>: {Container<int>.InstanceCount}");
            Console.WriteLine($"Container<bool>: {Container<bool>.InstanceCount}");
            Console.WriteLine($"ContainerBase>: {ContainerBase.InstanceCountBase}");

            container.PrintItem<string>("From generic method in generic class");

            var result1 = Add(2, 3);
            Console.WriteLine($"Result1 = {result1}");
            
            var result2 = Add(2.2, 3.3);
            Console.WriteLine($"Result2 = {result2}");
        }

        private static T Add<T>(T x, T y) where T : notnull
        {
            dynamic a = x;
            dynamic b = y;
            return a + b;
        }
    }

    class ContainerBase
    {
        public ContainerBase()
        {
            InstanceCountBase++;
        }

        public static int InstanceCountBase { get; private set; }
    }
    
    class Container<T> : ContainerBase
    {
        public Container()
        {
            InstanceCount++;
        }

        public static int InstanceCount { get; private set; }

        public void PrintItem<TItem>(TItem item)
        {
            Console.WriteLine($"Item: {item}");
        }
    }
}
