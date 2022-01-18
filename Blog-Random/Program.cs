using Blog_Random.Random;
using System;
using System.Collections.Generic;

namespace Blog_Random
{
    public class Program
    {
        public static long GenerationCount { get; } = 1000;

        public static long Min { get; } = byte.MinValue;

        public static long Max { get; } = byte.MaxValue;

        static void Main(string[] args)
        {

            Console.WriteLine("Random generator tests.");
            Console.WriteLine("_______________________");
            Console.WriteLine("Test 1: Generator RandomComputationalMethods");
            //Test01();
            Console.WriteLine("_______________________");
            Console.WriteLine("Test 2: Generator RandomXorShift");
            //Test02();
            Console.WriteLine("_______________________");
            Console.WriteLine("Test 3: Generator RandomFromSystem");
            Test03();
            Console.ReadLine();
        }

        private static void Test03()
        {
            RandomFromSystem rnd = new RandomFromSystem();
            for (long i = 0; i < GenerationCount; i++)
            {
                Console.WriteLine(rnd.RandomLongBetweenInt(0, 100));
            }
        }

        private static void Test02()
        {
            RandomXorShift rnd = new RandomXorShift();
            for (long i = 0; i < GenerationCount; i++)
            {
                Console.WriteLine(rnd.RandomLongBetweenInt(0, 100));
            }
        }

        static void Test01()
        {
            RandomComputationalMethods randomGenerator = new RandomComputationalMethods(5123);
            List<byte> rnds = new List<byte>();

            for (long i = 0; i < GenerationCount; i++)
            {

                //Console.WriteLine(randomGenerator.RandomDoubleBetweenOne());
                Console.WriteLine(randomGenerator.RandomLongBetweenInt(0, 100));

                /*
                DateTime start = DateTime.Now;
                while (randomGenerator.RandomLongBetween(0, 100) != 100) ;
                DateTime end = DateTime.Now;
                Console.WriteLine($"Ticks = {end.Ticks - start.Ticks}");
                */
                /*
                byte rnd = randomGenerator.RandomByte();

                if(!rnds.Contains(rnd))
                {
                    rnds.Add(rnd);
                }
                Console.WriteLine($"rnd = {rnd}");
                if (rnd < Min || rnd > Max)
                {
                    Console.WriteLine($"It Have been found a error! rnd = {rnd}");
                }
                if(rnd == Min || rnd == Max)
                {
                    Console.WriteLine($"Edge rnd = {rnd}");
                }*/
            }
            /*
            double fraction;
            while((fraction = randomGenerator.RandomDoubleBetweenOne()) != 1.0) ;
            Console.WriteLine(fraction);*/

            //Console.WriteLine($"rnds.Count={rnds.Count}");
        }
    }
}
