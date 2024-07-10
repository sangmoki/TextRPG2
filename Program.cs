
namespace TextRPG2
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            // 계속 반복되기 위함
            while (true)
            {
                // 게임 시작
                game.Process();
            }
        }
    }
}