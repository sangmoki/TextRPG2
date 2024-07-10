using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG2
{
    // 각 프로세스에 맞게 GameMode 정의
    public enum GameMode
    {
        None,
        Lobby,
        Town,
        Field
    }

    internal class Game
    {
        // 게임 기본 모드 정의
        private GameMode mode = GameMode.Lobby;
        // 플레이어 정의 -> 사용자가 선택한 직업으로 치환하기 위함
        private Player player = null;
        // 몬스터 변수 정의
        private Monster monster = null;
        // 랜덤 변수 정의
        private Random random = new Random();


        public void Process()
        {
            switch (mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }

        // 로비 작업 정의
        private void ProcessLobby()
        {
            Console.WriteLine("직업을 선택하세요.");
            Console.WriteLine("[1]. 기사");
            Console.WriteLine("[2]. 궁수");
            Console.WriteLine("[3]. 법사");
            Console.WriteLine("[4]. 도적");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    player = new Knight();
                    mode = GameMode.Town;
                    break;
                case "2":
                    player = new Archer();
                    mode = GameMode.Town;
                    break;
                case "3":
                    player = new Mage();
                    mode = GameMode.Town;
                    break;
                case "4":
                    player = new Thief();
                    mode = GameMode.Town;
                    break;
            }
        }

        // 마을 프로세스 정의
        private void ProcessTown()
        {
            Console.WriteLine("마을에 입장했습니다 !");
            Console.WriteLine("무슨 행동을 하시겠어요 ?\n");
            Console.WriteLine("[1]. 필드로 가기 !");
            Console.WriteLine("[2]. 로비로 돌아가기 !");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    mode = GameMode.Field;
                    break;
                case "2":
                    mode = GameMode.Lobby;
                    break;
            }
        }

        // 필드 프로세스 정의
        private void ProcessField()
        {
            Console.WriteLine("필드에 입장했습니다 !");
            CreateRandomMonster();

            Console.WriteLine("[1]. 몬스터와 싸우기 !");
            Console.WriteLine("[2]. 일정 확률로 마을로 도망치기 !");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    // 전투 선택
                    ProcessFight();
                    break;
                case "2":
                    // 도망치기 선택
                    TryEscape();
                    break;
            }
        }

        // 랜덤 몬스터 생성 함수
        private void CreateRandomMonster()
        {
            int randomValue = random.Next(0, 3);

            switch (randomValue)
            {
                case 0:
                    monster = new Slime();
                    Console.WriteLine("야생의 슬라임이 튀어나왔습니다 !");
                    break;
                case 1:
                    monster = new Orc();
                    Console.WriteLine("거대한 오크가 튀어나왔습니다 !");
                    break;
                case 2:
                    monster = new Skeleton();
                    Console.WriteLine("앙상항 뼈마디의 스켈레톤이 나왔습니다 !");
                    break;
            }

            Console.WriteLine("어떤 행동을 취하시겠습니까 ?");
        }

        // 전투 함수
        private void ProcessFight()
        {
            while (true)
            {
                int dmage = player.GetAttack();
                monster.OnDamaged(dmage);

                if (monster.IsDead())
                {
                    Console.WriteLine("전투에서 승리하셨습니다 !");
                    Console.WriteLine($"남은 체력 {player.GetHp()}");
                    break;
                }

                dmage = monster.GetAttack();
                player.OnDamaged(dmage);
                if (player.IsDead()) 
                {
                    Console.WriteLine("전투에서 패배하셨습니다 !");
                    mode = GameMode.Lobby;
                    break;
                }
            }
        }

        // 도망치기 함수
        private void TryEscape()
        {
            int randomValue = random.Next(0, 101);
            if (randomValue <= 50)
            {
                mode = GameMode.Town;
                Console.WriteLine("도망에 성공하셨습니다 !");
            } 
            else
            {
                Console.WriteLine("도망치는데 실패하여 전투에 임합니다.");
                ProcessFight();
            }
        }
    }
}
