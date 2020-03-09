using System;
using System.Collections.Generic;
using System.Text;

namespace HalloSingelton
{
    public class Logger
    {
        private static Logger instance = null;
        private static object lockObject = new object();

        public static Logger Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                        instance = new Logger();
                }
                return instance;
            }
        }

        private Logger()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CTOR");
            Console.ResetColor();
        }

        public void Log(string txt)
        {
            lock (lockObject)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[{DateTime.Now:d} {DateTime.Now:T}] {txt}");
                Console.ResetColor();
            }
        }
    }
}
