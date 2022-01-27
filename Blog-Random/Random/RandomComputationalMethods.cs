namespace Blog_Random.Random
{
    public class RandomComputationalMethods : Random
    {
        private long _a = 23456781;
        private long _b = 12323456781;
        private long _mod = 56472311456;

        public RandomComputationalMethods(long seed)
        {
            _seed = seed;
        }

        protected override long Next()
        {
            _seed = (_a * _seed + _b) % _mod;
            return _seed;
        }
    }
}
