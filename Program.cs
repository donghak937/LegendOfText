using System;

namespace CSharpGame
{
    internal class Player
    {
        public PlayerJob job1 = new PlayerJob("전사");
        private string job;
        private int hp;
        private int mana;
        private int minDmg;
        private int maxDmg;
        private int gold;
        private string name;
        public string Name
        {
            get { return name; }
        }
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
        public Player(string name, PlayerJob job){
            this.hp = job.Hp;
            this.mana = job.Mana;
            this.minDmg = job.MinDmg;
            this.maxDmg = job.MaxDmg;
            this.name = name; 
            this.gold = job.Gold; 
            this.job = job.Job; 
        }

        public void printPlayerInfo(){
            Console.WriteLine("이름 : {0}", name);
            Console.WriteLine("직업 : {0}", job);
            Console.WriteLine("\n{0}", job1.Description);
            Console.WriteLine("\n체력 : {0}", hp);
            Console.WriteLine("마나 : {0}", mana);
            Console.WriteLine("공격력 : {0} - {1}", minDmg, maxDmg);
            Console.WriteLine("소지금 : {0}", gold);
        }
    }

    internal class PlayerJob
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
        private string job = "전사";
        public string Job
        {
            get { return job; }
        }

        private string description;
        public string Description
        {
            get { return description; }
        }
        public PlayerJob(string job)
        {
            this.job = job;
            this.description = jobMatch(job);
        }
        string jobMatch(string job) // 직업이랑 설명이랑 맞추는 과정
        {
            if (job == "전사"){

                hp = 100;
                mana = 50;
                minDmg = 10;
                maxDmg = 20;
                gold = 100;

                return """
                강력한 체력과 기초 공격력으로 맞으면서 싸우는 직업. 
                최대 피해는 낮지만, 꾸준히 싸우며 누구보다 오래 살아남는다.
                초보자에게 추천하는 직업.
                """;
            }
            else if (job == "마법사"){

                hp = 80;
                mana = 100;
                minDmg = 15;
                maxDmg = 25;
                gold = 100;

                return """
                체력은 낮지만, 강한 공격력으로 적을 처치하는 직업. 
                강력한 마법으로 적에게 여러가지 속성 공격을 입힌다.
                답답한 것을 싫어하는 사람에게 추천하는 직업.
                """;
            }
            else return "";
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("직업을 골라주세요");
            string input  = Console.ReadLine() ?? "전사"; //?? 뜻, null이면, 전사라고 해라라

            Player player;

            if (input == "전사"){
                PlayerJob warrior = new PlayerJob("전사");
                player = new Player("dongha", warrior);
            }
            else{
                PlayerJob mage = new PlayerJob("마법사");
                player = new Player("dongha", mage);
            }
            
            player.printPlayerInfo();
        }
    }
}