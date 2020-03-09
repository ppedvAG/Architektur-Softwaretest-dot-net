using System;
using System.Threading.Tasks;

namespace HalloSingelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Singelton!");

            for (int i = 0; i < 10; i++)
            {
                Task.Run(() => Logger.Instance.Log($"TEST {i}"));
            }

            //Logger.Instance.Log("TEST 1");
            //Logger.Instance.Log("TEST 2");
            //Logger.Instance.Log("TEST 3");

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
