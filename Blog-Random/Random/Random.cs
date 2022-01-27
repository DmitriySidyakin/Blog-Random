using System;

namespace Blog_Random.Random
{
    public abstract class Random
    {
        protected long _seed;
        private byte _currentBytePosition = 8;

        protected abstract long Next();

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
            return BitConverter.ToDouble(new byte[8] { RandomByte(), RandomByte(), RandomByte(), RandomByte(), RandomByte(), RandomByte(), (byte)(RandomByte() & 0b0001_1111), 0 }) / RandomDoubleBitOne();
        }

        private double RandomDoubleBitOne()
        {
            return BitConverter.ToDouble(new byte[8] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0b0001_1111, 0 });
        }

        public long RandomLongBetweenInt(int min, int max)
        {
            return min + (long) Math.Round(((long)max - (long)min) * RandomDoubleBetweenOne(), 0);
        }
    }
}
