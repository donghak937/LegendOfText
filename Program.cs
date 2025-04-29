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
            Console.Clear();
            Console.WriteLine("당신의 정보 >> ");
            Console.WriteLine("\n이름 : {0}", name);
            Console.WriteLine("직업 : {0}", job);
            Console.WriteLine("\n{0}", description);
            Console.WriteLine("\n체력 : {0}", hp);
            Console.WriteLine("마나 : {0}", mana);
            Console.WriteLine("공격력 : {0} - {1}", minDmg, maxDmg);
            Console.WriteLine("소지금 : {0}", gold);
            Console.WriteLine("\n아무 키 나 눌러서 진행 >> ");
            Console.ReadLine();
        }
    
        public bool isPlayerDead(){
            if (this.hp <= 0) return true;
            else false;
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
        private string jobMatch(string job) // 직업이랑 설명이랑 맞추는 과정
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
            else{
                return "";
            }
        }
        
    }
    internal class GameManager
    {
        public static Player? player;
        private static int currentStage = 1;

        public static void Init(Player inPlayer)
        {
            player = inPlayer;
        }

        public static Player gameSetting(){
            string name;
            string job;
            string input;
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|      Text RPG - DUNGEON QUEST     |");
            Console.WriteLine("-------------------------------------");
            Thread.Sleep(700);
            Console.WriteLine();
            Console.WriteLine("새로운 여정이 곧 시작됩니다...");
            Thread.Sleep(1000);
            Console.WriteLine("이름과 직업을 정하고, 모험을 준비하세요.");
            Thread.Sleep(1200);
            Console.WriteLine("\n아무 키 나 눌러서 진행 >> ");
            Console.ReadLine();
            while (true){
                Console.Clear();
                Console.Write("당신의 이름은 무엇인가요? > ");
                name  = Console.ReadLine() ?? "용사";
                Console.WriteLine("당신의 이름이 {0} (이)가 맞나요?", name);
                Console.Write("네 | 아니요 | > ");
                input = Console.ReadLine() ?? "2";
                if (input == "네"){
                    break;
                }
                else {
                    continue;
                }
            }

            while (true){
                Console.Clear();
                Console.WriteLine("당신의 직업은 무엇인가요?");
                Console.Write("전사 | 마법사 | > ");
                job = Console.ReadLine() ?? "전사";
                 Console.WriteLine("당신의 직업이 {0} (이)가 맞나요?", job);
                Console.Write("네 | 아니요 > ");
                input = Console.ReadLine() ?? "아니요";
                if (input == "네"){
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
                        Console.Clear();
                        Console.WriteLine("\n유효하지 않은 직업입니다. 다시 골라주세요.");
                        Thread.Sleep(1000);
                    }
                }
                else{
                    continue;
                }
            }
        }
    
        public static void gameInfo(){
            Console.Clear();
            Console.Write(".");
            Thread.Sleep(700);
            Console.Write(".");
            Thread.Sleep(700);
            Console.WriteLine(".");
            Thread.Sleep(700);
            Console.WriteLine("당신은 낯선 곳에서 눈을 떴다.");
            Thread.Sleep(1500);
            Console.WriteLine("기억나는 건 당신의 이름과, 직업 뿐.");
            Thread.Sleep(1500);
            Console.WriteLine("주의를 둘러보자, 마을을 발견 할 수 있었다.");
            Thread.Sleep(1500);
            Console.WriteLine("당신은 홀린듯이 마을로 이동한다.");
            Thread.Sleep(1500);
            Console.Write(".");
            Thread.Sleep(700);
            Console.Write(".");
            Thread.Sleep(700);
            Console.WriteLine(".\n");
            Thread.Sleep(700);
            Console.WriteLine("\n엔터 눌러서 진행 >> ");
            Console.ReadLine();
            Console.Clear();
            gameStart();
        }

        public static void gameStart(){
            string input;
            while(true){
                Console.Clear();
                Console.Write("전투 | 스텟 | 상점 | 소지품 | 스킬 > ");

                input = Console.ReadLine() ?? "스텟";

                switch (input)
                {
                    case "전투":
                        Console.Write("전투를 선택하셨습니다.");
                        Thread.Sleep(500);
                        Console.WriteLine("\n엔터 눌러서 진행 >> ");
                        Console.ReadLine();
                        Console.Clear();
                        Stage stage = StageForm.createStage(currentStage);
                        BattleManager.battleStart(player, stage);
                        currentStage++;
                        break;
                    case "스텟":
                        Console.Write("스텟를 선택하셨습니다.");
                        player.printPlayerInfo();
                        break;
                }

            }
            
        }

        public 
    }

    internal class Stage
    {
        private int stageNum;
        public int StageNum 
        {
            get {return stageNum; }
        }
        public Enemy enemy;
        public Stage(int currentStage, Enemy enemy){
            stageNum = currentStage;
            this.enemy = enemy;  
        }
    }

    internal class StageForm
    {
        public static Stage creatStage(int stageNum) 
        {
            string description;
            Enemy enemy;

            switch (stageNum)
            {
                case 1:
                    description = 
                    """
                    가장 기본적이고 약한 몬스터.
                    보통 초보 모험가들만 노리며 사냥한다.
                    끈적끈적한 점액질은 피부미용이 좋아서
                    마을 여성 주민들에게 인기가 많다.
                    """ 
                    enemy = new Enemy("슬라임", description, 30, 3, 7);
                    break;
                case 2:
                    description = 
                    """
                    산 속 깊은 곳에 주로 사는 몬스터.
                    슬라임과 같이 약자 포지션을 담당하고 있다.
                    주로 무리를 지어 다니지만, 그 중에서도 특히 못생긴 개체는
                    왕따를 당하여 혼자 다니기도 한다.
                    """ 
                    enemy = new Enemy("약한 고블린", description, 40, 2, 10);
                    break;
            }
            return new Stage(stageNum, enemy)
        }
    }

    internal class BattleManager
    {

    }

    internal class Enemy
    {
        private int hp;
        private int minDmg;
        private int maxDmg;
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
            set { hp = value; }
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
    
        public Enemy(string name, string description, int hp, int minDmg, int maxDmg){
            this.name = name;
            this.description = description;
            this.hp = hp;
            this.minDmg = minDmg;
            this.maxDmg = maxDmg;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Player player;
            player = GameManager.gameSetting();
            GameManager.Init(player);
            
            player.printPlayerInfo();
            GameManager.gameInfo();
        }
    }
}