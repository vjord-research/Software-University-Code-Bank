namespace RawData
{
    class Engine
    {
        private int speed;
        private int power;

        public Engine() { }
        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}