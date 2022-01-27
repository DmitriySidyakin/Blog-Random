namespace Blog_Random.Random
{
    public class RandomFromSystem : Random
    {
        System.Random random;

        public RandomFromSystem() { random = new System.Random(); _seed = Next(); }

        public RandomFromSystem(int seed) { random = new System.Random(seed); _seed = Next(); }

        protected override long Next()
        {
            byte[] rnd = new byte[sizeof(long)];
            random.NextBytes(rnd);

            long result = 0;
            for(int i = sizeof(long) - 1; i >= 0; i--)
            {
                byte rndByte = rnd[i];
                result = result ^ rndByte;
                result <<= i * 8;
            }

            _seed = result;
            return _seed;
        }
    }
}
