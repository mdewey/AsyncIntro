using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncIntro
{
    class Program
    {
        public static async Task<int> AddAsync(int x, int y) => x + y;


        public static async Task HelloAsync()
        {

            var sum = await Add(4, 5);

            Console.WriteLine("This is cool");
        }

        public static async Task WriteFileAsync()
        {
            var path = "test.txt";
            var stream = File.Open(path, FileMode.OpenOrCreate);
            using (var writer = new StreamWriter(stream))
            {
                for (int i = 0; i < 10000; i++)
                {
                    //async
                    await writer.WriteLineAsync($"i= {i}");
                    // not async
                    //writer.WriteLine($"i= {i}");
                }
            }
        }

        public static void Main(string[] args)
        {

            HelloAsync().Wait();

        }
    }
}
