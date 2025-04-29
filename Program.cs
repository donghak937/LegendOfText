using System;
using System.Threading; //sleep을 위한 코드
using System.Linq; // list 사용을 위한 유징

namespace CSharpGame
{

    static class RandomUtil
    {
    public static Random random = new Random();
    }

    internal class Player
    {
        public PlayerJob Job1 { get; private set; } // 직업별 다른 초기 능력치를 가진 세팅
        public string Job { get; private set; }
        public int Hp { get; set; }
        public int Mana { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int Gold { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Player(PlayerJob job)
        {
            Job1 = job;
            Hp = job.Hp;
            Mana = job.Mana;
            MinDmg = job.MinDmg;
            MaxDmg = job.MaxDmg;
            Name = job.Name;
            Gold = job.Gold;
            Job = job.Job;
            Description = job.Description;
        }

        public void PrintPlayerInfo()
        {
            Console.Clear();
            Console.WriteLine("당신의 정보 >> ");
            Console.WriteLine("\n이름 : {0}", Name);
            Console.WriteLine("직업 : {0}", Job);
            Console.WriteLine("\n{0}", Description);
            Console.WriteLine("\n체력 : {0}", Hp);
            Console.WriteLine("마나 : {0}", Mana);
            Console.WriteLine("공격력 : {0} - {1}", MinDmg, MaxDmg);
            Console.WriteLine("소지금 : {0}", Gold);
            Console.WriteLine("\n아무 키 나 눌러서 진행 >> ");
            Console.ReadLine();
        }

        public bool IsPlayerDead()
        {
            if (Hp <= 0)
            {
                Console.WriteLine("당신은 치명타를 입었습니다!");
                Thread.Sleep(1000);
                Console.WriteLine("당신의 여정은 여기서 끝났습니다...");
                Thread.Sleep(1000);
                Console.WriteLine("던전은 다시 깊은 어둠 속으로 삼켜졌습니다.");
                Thread.Sleep(1000);
                Console.WriteLine();
                Console.WriteLine("당신은 모든 것이 후회됩니다...");
                Thread.Sleep(1500);
                Console.WriteLine();
                Console.WriteLine("메인 화면으로 돌아갑니다...");
                Thread.Sleep(1000);
                return true;
            }
            else return false;
        }
    
        public void Attack(Enemy enemy)
        {
            int damage;
            damage = RandomUtil.random.Next(MinDmg, MaxDmg+1);
            enemy.Hp -= damage;
            Console.WriteLine("당신은 상대를 {0}의 공격력으로 가격했다.", damage);
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

        public static Player gameSetting()
        {
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
            while (true)
            {
                Console.Clear();
                Console.Write("당신의 이름은 무엇인가요? > ");
                name = Console.ReadLine() ?? "용사";
                Console.WriteLine("당신의 이름이 {0} (이)가 맞나요?", name);
                Console.Write("네 | 아니요 | > ");
                input = Console.ReadLine() ?? "2";
                if (input == "네")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("당신의 직업은 무엇인가요?");
                Console.Write("전사 | 마법사 | > ");
                job = Console.ReadLine() ?? "전사";
                Console.WriteLine("당신의 직업이 {0} (이)가 맞나요?", job);
                Console.Write("네 | 아니요 > ");
                input = Console.ReadLine() ?? "아니요";
                if (input == "네")
                {
                    if (job == "전사")
                    {
                        PlayerJob playerJob = new PlayerJob(job, name);
                        Player player = new Player(playerJob);
                        return player;

                    }
                    else if (job == "마법사")
                    {
                        PlayerJob playerJob = new PlayerJob(job, name);
                        Player player = new Player(playerJob);
                        return player;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n유효하지 않은 직업입니다. 다시 골라주세요.");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        public static void gameInfo()
        {
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

        public static void gameStart()
        {
            string input;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("무엇을 할 것인가?");
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
                        player.PrintPlayerInfo();
                        break;
                }

            }

        }
    }

    internal class Stage
    {
        public string[] NarrationLines { get; }
        public int StageNum { get; }
        public Enemy enemy { get; }
        public Stage(int currentStage, Enemy enemy, string[] narrationLines)
        {
            StageNum = currentStage;
            this.enemy = enemy;
            NarrationLines = narrationLines;
        }
    }

    internal class StageForm
    {
        public static Stage createStage(int stageNum)
        {
            string[] narrations;
            string description;
            Enemy enemy;

            switch (stageNum)
            {
                case 1:

                    narrations = new string[]
                    {
                    "당신은 마을을 지나 숲으로 들어갔다.",
                    "길을 가다 이상한 소리가 나 뒤를 돌아보니.",
                    "슬라임으로 추정되는 몬스터가 당신을 노리고 있었다.",
                    "당신은 무기를 들어서 항전한다."
                    };

                    enemy = new Slime();
                    break;
                case 2:
                    description =
                    """
                    산 속 깊은 곳에 주로 사는 몬스터.
                    슬라임과 같이 약자 포지션을 담당하고 있다.
                    주로 무리를 지어 다니지만, 그 중에서도 특히 못생긴 개체는
                    왕따를 당하여 혼자 다니기도 한다.
                    """;

                    narrations = new string[]
                    {
                    "당신은 더욱 깊은 숲으로 들어간다.",
                    "깊은 숲에서 고약한 악취가 나기 시작한다.",
                    "당신은 직감적으로 싸워야 한다는 것을 깨달았다.",
                    "당신은 지친 몸을 이끌고 전투에 들어간다."
                    };

                    enemy = new Enemy("약한 고블린", description, 40, 2, 10);
                    break;
                default:
                    description =
                    """
                    개벌레
                    """;

                    narrations = new string[]
                    {
                    "당신은 더욱 깊은 숲으로 들어간다.",
                    "깊은 숲에서 고약한 악취가 나기 시작한다.",
                    "당신은 직감적으로 싸워야 한다는 것을 깨달았다..",
                    "당신은 지친 몸을 이끌고 전투에 들어간다.."
                    };

                    enemy = new Enemy("거지", description, 10, 2, 10);
                    break;
            };
            return new Stage(stageNum, enemy, narrations);
        }
    }

    internal class BattleManager
    {
        public static void battleStart(Player player, Stage stage)
        {
            string input;
            foreach (string line in stage.NarrationLines)
            {
                Console.WriteLine(line);
                Thread.Sleep(1500);
            }

            while (true)
            {
                if (player.IsPlayerDead())
                {
                    Console.WriteLine("게임이 종료됩니다...");
                    Thread.Sleep(1000);  // 살짝 기다렸다가
                    Environment.Exit(0);  // 프로그램 강제 종료
                }
                printCurrent(player, stage);
                input = playerChoice();
                
                switch (input)
                {
                    case "공격":
                        player.Attack(stage.enemy);
                        break;
                    //case "스킬":
                        //player.Attack();
                    //case "방어":
                        //player.Attack();
                }
                if (stage.enemy.IsDead())
                {
                    Console.WriteLine("승리!");
                    break;
                }
                else
                {
                    stage.enemy.UseSkill(player);
                }

            }
        }
        public static void printCurrent(Player player, Stage stage)
        {
            Console.WriteLine("당신의 상태");
            Console.WriteLine("체력 : {0}", player.Hp);
            Console.WriteLine("마나 : {0}", player.Mana);
            Console.WriteLine("공격력 : {0} - {1}", player.MinDmg, player.MaxDmg);
            Console.WriteLine("-----------------------");
            Console.WriteLine("적의 상태");
            Console.WriteLine("이름 : {0}", stage.enemy.Name);
            Console.WriteLine("체력 : {0}", stage.enemy.Hp);
            Console.WriteLine("공격력 : {0} - {1}", stage.enemy.MinDmg, stage.enemy.MaxDmg);
            Thread.Sleep(500);
            Console.WriteLine("\n 엔터 눌러서 진행 >> ");
            Console.ReadLine();
            Console.Clear();
        }
        public static string playerChoice()
        {
            string[] acts = { "공격", "스킬", "방어" };
            string input;
            while (true)
            {
                Console.WriteLine("행동을 선택해 주세요");
                Console.Write("공격 | 스킬 | 방어 >> ");
                input = Console.ReadLine();
                if (!acts.Contains(input))
                {
                    Console.WriteLine("올바른 행동을 입력해 주세요");
                }
                else break;
            }
            return input;
        }
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

        public Enemy(string name, string description, int hp, int minDmg, int maxDmg)
        {
            this.name = name;
            this.description = description;
            this.hp = hp;
            this.minDmg = minDmg;
            this.maxDmg = maxDmg;
        }

        public bool IsDead()
        {
            if (this.Hp <= 0)
            {
                return true;
            }
            else
            {
                return false;    
            }
        }
        public virtual void UseSkill(Player player)
        {
            Console.WriteLine($"{Name}이(가) 기본 공격을 했다!");
        }
    }

    internal class Slime : Enemy
    {
        public static string description =
        """
        가장 기본적이고 약한 몬스터.
        보통 초보 모험가들만 노리며 사냥한다.
        끈적끈적한 점액질은 피부미용이 좋아서
        마을 여성 주민들에게 인기가 많다.
        """;

        public Slime() : base("슬라임", description ,30, 5 ,7) { }

        public override void UseSkill(Player player)
        {
            int damage = RandomUtil.random.Next(MinDmg, MaxDmg+1);
            int act = RandomUtil.random.Next(1, 101);
            if (act >= 90){
                Console.WriteLine($"{Name}이 끈적한 점액질을 발사했다!\n");
                player.Hp -= 10;
            }
            else if (act >= 60){
                Console.WriteLine($"{Name}이 끈적한 점프로 덮쳤다!\n");
                player.Hp -= damage;
            }
            else {
                Console.WriteLine($"{Name}이 자가수복 한다!\n");
                Hp += 10;
                if (Hp > 30) Hp = 30;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Player player;
            player = GameManager.gameSetting();
            GameManager.Init(player);

            player.PrintPlayerInfo();
            GameManager.gameInfo();
        }
    }
}