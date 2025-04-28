using System;

namespace CSharpGame
{
    internal class Player
    {
        
        private int hp;
        private int mana;
        private int minDmg;
        private int maxDmg;
        private int gold;

        public int Hp
        {
            get { return hp; }
            set {hp = value; }
        }

        public int Mana
        {
            get { return mana; }
            set { mana = value; }
        }

        public int MinDmg
        {
            get { return minDmg; }
            set { minDmg = value; }
        }

        public int MaxDmg
        {
            get { return maxDmg; }
            set { maxDmg = value; }
        }

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        public Player(int hp, int mana, int minDmg, int maxDmg){
            this.hp = hp;
            this.mana = mana;
            this.minDmg = minDmg;
            this.maxDmg = maxDmg;
            
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(100, 50, 10, 20);
            Console.WriteLine($"Player Stats: HP={player.Hp}, Mana={player.Mana}, Damage={player.MinDmg}-{player.MaxDmg}");
        }
    }
}