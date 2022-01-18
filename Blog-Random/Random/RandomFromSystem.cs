using System;

namespace Blog_Random.Random
{
    public class RandomFromSystem
    {
        private long _seed = 0;

        // for byte generation
        private byte _currentBytePosition = 8;

        System.Random random = new System.Random();
        public RandomFromSystem() { }

        private long Next()
        {
            byte[] rnd = new byte[sizeof(long)];
            random.NextBytes(rnd);

            long result = 0;
            for(byte i = 0; i < sizeof(long); i++)
            {
                result <<= sizeof(long) * i;
                result = result | rnd[i];
            }

            _seed = result;
            return _seed;
        }

        public long RandomLong() => Next();

        public byte RandomByte()
        {
            if (_currentBytePosition == 8)
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
