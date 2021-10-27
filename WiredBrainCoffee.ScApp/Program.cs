using System;

namespace WiredBrainCoffee.ScApp
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new Container<string>();
            _ = new Container<string>();
            _ = new Container<int>();

            Console.WriteLine($"Container<string>: {Container<string>.InstanceCount}");
            Console.WriteLine($"Container<int>: {Container<int>.InstanceCount}");
            Console.WriteLine($"Container<bool>: {Container<bool>.InstanceCount}");
            Console.WriteLine($"ContainerBase>: {ContainerBase.InstanceCountBase}");
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
    }
}
