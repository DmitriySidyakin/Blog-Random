using Blog_Random.Random;
using System;
using System.Collections.Generic;

namespace Blog_Random
{
    public class Program
    {
        public static long GenerationCount { get; } = 100;

        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Random generator tests.");
            Console.WriteLine("_______________________");
            Console.WriteLine("Test 1: Generator RandomComputationalMethods");
            Test01();
            Console.WriteLine("_______________________");
            Console.WriteLine("Test 2: Generator RandomXorShift");
            Test02();
            Console.WriteLine("_______________________");
            Console.WriteLine("Test 3: Generator RandomFromSystem");
            Test03();
            Console.ReadLine();*//*
            long _a = 23456781;
            long _b = 12323456781;
            long _mod = 56472311456;
            long _seed = 5123;
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("____________________________");
                Console.WriteLine($"Итерация {i}:");
                Console.WriteLine($"_seed = {_seed}");
                Console.WriteLine($"_a * _seed = {_a * _seed}");
                Console.WriteLine($"(_a * _seed + _b) = {_a * _seed + _b}");
                Console.WriteLine($"(_a * _seed + _b) % _mod = {(_a * _seed + _b) % _mod}");
                _seed = (_a * _seed + _b) % _mod;
                Console.WriteLine("____________________________");
            }
            */
            ulong _x = 123; // начальные значения могут быть другими
            ulong _y = 456;
            ulong _z = 789;
            ulong _w = 768;
            long _seed = (long)_w;
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("____________________________");
                Console.WriteLine($"Итерация {i}:");
                Console.WriteLine("Начальные значения:");
                Console.WriteLine($"_x = {_x}");
                Console.WriteLine($"_y = {_y}");
                Console.WriteLine($"_w = {_w}");
                Console.WriteLine($"_seed = {_seed}");
                ulong t = _x ^ (_x << 11);
                _x = _y;
                _y = _z;
                _z = _w;
                _w = (_w ^ (_w >> 19)) ^ (t ^ (t >> 8));
                _seed = (long)_w;
                Console.WriteLine("Конечные значения:");
                Console.WriteLine($"t = {t}");
                Console.WriteLine($"_x = {_x}");
                Console.WriteLine($"_y = {_y}");
                Console.WriteLine($"_w = {_w}");
                Console.WriteLine($"_seed = {_seed}");
                Console.WriteLine("____________________________");
            }
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

        private static void Test01()
        {
            RandomComputationalMethods randomGenerator = new RandomComputationalMethods(5123);
            List<byte> rnds = new List<byte>();

            for (long i = 0; i < GenerationCount; i++)
            {
                Console.WriteLine(randomGenerator.RandomLongBetweenInt(0, 100));
            }
        }
    }
}
