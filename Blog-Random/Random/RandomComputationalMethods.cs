using System;

namespace Blog_Random.Random
{
    public class RandomComputationalMethods
    {

        private long _seed;

        private long _a = 23456781;
        private long _b = long.MaxValue;
        private long _mod = 56472311;

        // for byte generation
        private byte _currentBytePosition = 8;

        public RandomComputationalMethods(long seed)
        {
            _seed = seed;
        }

        private long Next()
        {
            _seed = (_a * _seed + _b) % _mod;
            return _seed;
        }

        public long RandomLong() => Next();


        public byte RandomByte()
        {
            if(_currentBytePosition == 8)
            {
                Next();
                _currentBytePosition = 0;
            }

            byte randomByte = (byte)((_seed >> _currentBytePosition) & 0xFF);
            _currentBytePosition++;
            return randomByte;
        }

        public double RandomDouble()
        {
            return BitConverter.ToDouble(new byte[8] { RandomByte(), RandomByte(), RandomByte(), RandomByte(), RandomByte(), RandomByte(), RandomByte(), RandomByte() });
        }

        public double RandomDoubleBetweenOne()
        {
            return BitConverter.ToDouble(new byte[8] { RandomByte(), RandomByte(), RandomByte(), RandomByte(), RandomByte(), RandomByte(), (byte)(RandomByte() & 0b0001_1111), 0 }) * Math.Pow(2, 1023) / 3.9999999999999996;
        }

        public long RandomLongBetweenInt(int min, int max)
        {
            return min + (long)(((long)max - (long)min) * RandomDoubleBetweenOne());
        }
    }
}
