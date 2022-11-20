
using MyProject.Mock;
using System;

namespace MyProject.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var mock = new MockContext();

            mock.Roles.ForEach(r =>
            {
                Console.WriteLine(r.ToString());
            });

            Console.ReadLine();
        }
    }
}
