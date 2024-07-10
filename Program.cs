
namespace TextRPG2
{ 
    class Program
    {
        static void Main(string[] args)
        {
            // player 객체 생성 및 초기화
            Player player = new Archer();
            Monster monster = new Orc();

            // 플레이어 공격력 불러오기
            int damage = player.GetAttack();
            // 플레이어의 공격력만큼 몬스터가 공격받음
            monster.OnDamaged(damage);
        }
    }
}