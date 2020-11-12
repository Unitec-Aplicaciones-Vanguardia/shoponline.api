using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Action action1 = DoSomething;
            Action<string> action2 = DoSomething2;
            Action<string, string> action3 = (message, recipient) =>
            {
                Console.WriteLine($"{message} - {recipient}");
            };

            Func<int, int, int> sum = (num1, num2) => num1 + num2;

            action1();
            action2("hola");
            action3("mensaje", "carlos");

            action2(sum(1, 2).ToString());
            Console.ReadKey();
        }
        private static void DoSomething2(string message)
        {
            Console.WriteLine(message);
        }
        private static void DoSomething()
        {
            Console.WriteLine("doing something");
        }
    }
}
