using System;

namespace Blog_Random.Random
{
    public class RandomXorShift
    {
        private ulong _x = 123; // начальные значения могут быть любыми
        private ulong _y = 456;
        private ulong _z = 789;
        private ulong _w = 768;

        // for byte generation
        private long _seed; 
        private byte _currentBytePosition = 8;

        public RandomXorShift(ulong x, ulong y, ulong z, ulong w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
            _seed = (long)_w;
        }
        public RandomXorShift() { _seed = (long)_w; }

        private long Next()
        {
            ulong t = _x ^ (_x << 11);
            _x = _y;
            _y = _z;
            _z = _w;
            _w = (_w ^ (_w >> 19)) ^ (t ^ (t >> 8));
            _seed = (long)_w;
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
