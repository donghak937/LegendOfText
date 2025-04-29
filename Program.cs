using System;
using System.Threading; //sleep을 위한 코드

namespace CSharpGame
{
    internal class Player
    {
        public PlayerJob job1; //직업별 다른 초기 능력치를 가진 세팅
        private string job;
        private int hp;
        private int mana;
        private int minDmg;
        private int maxDmg;
        private int gold;
        private string name;
        private string description;
        public string Description
        {
            get { return description; }
        }
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
        public Player(PlayerJob job){
            job1 = job;
            this.hp = job1.Hp;
            this.mana = job1.Mana;
            this.minDmg = job1.MinDmg;
            this.maxDmg = job1.MaxDmg;
            this.name = job1.Name; 
            this.gold = job1.Gold; 
            this.job = job1.Job; 
            this.description = job1.Description;
        }

        public void printPlayerInfo(){
            Console.WriteLine("당신의 정보 >> ");
            Console.WriteLine("\n이름 : {0}", name);
            Console.WriteLine("직업 : {0}", job);
            Console.WriteLine("\n{0}", description);
            Console.WriteLine("\n체력 : {0}", hp);
            Console.WriteLine("마나 : {0}", mana);
            Console.WriteLine("공격력 : {0} - {1}", minDmg, maxDmg);
            Console.WriteLine("소지금 : {0}", gold);
        }
    }

    internal class PlayerJob
    {
        private string name;
        private int hp;
        private int mana;
        private int minDmg;
        private int maxDmg;
        private int gold;
        private string job;
        private string description;
        public string Name
        {
            get { return name; }
        }
        public string Description
        {
            get { return description; }
        }
        public string Job
        {
            get { return job; }
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
        public PlayerJob(string job, string name)
        {
            this.name = name;
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
    internal class GameManager
    {
        public static Player gameSetting(){
            string name;
            string job;
            string input;
            Console.WriteLine("던전 탐험에 오신 것을 환영합니다.");
            Thread.Sleep(1000); // 1000밀리초 멈추기
            Console.WriteLine("당신은 직업을 고르고 던전을 탐험할 것입니다.");
            Thread.Sleep(1000);
            while (true){
                Console.Write("당신의 이름은 무엇인가요? > ");
                name  = Console.ReadLine() ?? "용사";
                Console.WriteLine("당신의 이름이 {0} (이)가 맞나요?", name);
                Console.Write("네 : 1 | 아니요 : 2 | > ");
                input = Console.ReadLine() ?? "2";
                if (input == "1"){
                    break;
                }
                else {
                    continue;
                }
            }

            while (true){
                Console.WriteLine("\n당신의 직업은 무엇인가요?");
                Console.Write("전사 | 마법사 | > ");
                job = Console.ReadLine() ?? "전사";
                 Console.WriteLine("당신의 직업이 {0} (이)가 맞나요?", job);
                Console.Write("네 : 1 | 아니요 : 2 | > ");
                input = Console.ReadLine() ?? "2";
                if (input == "1"){
                    if (job == "전사"){
                        PlayerJob playerJob = new PlayerJob(job, name);
                        Player player = new Player(playerJob);
                        return player;

                    }
                    else if (job == "마법사"){
                        PlayerJob playerJob = new PlayerJob(job, name);
                        Player player = new Player(playerJob);
                        return player;
                    }
                    else{
                        Console.WriteLine("\n유효하지 않은 직업입니다. 다시 골라주세요.");
                        Thread.Sleep(1000);
                    }
                }
                else{
                    continue;
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Player player;
            player = GameManager.gameSetting();

            
            player.printPlayerInfo();
        }
    }
}