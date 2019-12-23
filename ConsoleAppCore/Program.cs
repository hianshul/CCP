using System;
using System.Threading.Tasks;

namespace ConsoleAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new VoidAsyncTest();
            try
            {
                obj.A1().GetAwaiter()
                    .GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catch A1");
            }

            try
            {
                obj.A2();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catch A2");
            }

            try
            {
                obj.A3();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catch A2");
            }

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
