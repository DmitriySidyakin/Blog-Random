namespace Blog_Random.Random
{
    public class RandomXorShift : Random
    {
        private ulong _x = 123; // начальные значения могут быть другими
        private ulong _y = 456;
        private ulong _z = 789;
        private ulong _w = 768;

        public RandomXorShift(ulong x, ulong y, ulong z, ulong w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
            _seed = (long)_w;
        }

        public RandomXorShift() { _seed = (long)_w; }

        protected override long Next()
        {
            ulong t = _x ^ (_x << 11);
            _x = _y;
            _y = _z;
            _z = _w;
            _w = (_w ^ (_w >> 19)) ^ (t ^ (t >> 8));
            _seed = (long)_w;
            return _seed;
        }
    }
}
