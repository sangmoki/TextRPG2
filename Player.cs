using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG2
{
    // PlayerType 정의
    public enum PlayerType
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3,
        Thief = 4 
    }

    // 공용 직업 객체 생성
    class Player : Info
    {
        protected PlayerType _type = PlayerType.None;  // 직업 구분 <- m_type은 컨벤션을 맞춰준거라 member_type이라고 생각하면 된다.


        // 외부에서 사용자를 생성할 수 없게 protected로 제한을 걸어둔다.
        // 새로 생성자를 생성할 때 직업 구분이 없으면 에러가 발생한다.
        // 무조건 전사, 궁수, 법사, 도적 (public) 으로만 만들 수 있게 해야한다.
        // 그래서 아래 부모 클래스 생성자를 호출하여 직업을 생성자로 사용하게끔 유도했다.
        protected Player(PlayerType type) : base(InfoType.Player)
        {
            this._type = type;
        }
    }

    // 전사 정보 클래스
    class Knight : Player
    {
        // 부모 클래스 생성자 호출
        public Knight() : base(PlayerType.Knight)
        {
            // 부모 함수 상속
            SetInfo(100, 10);
        }
    }

    // 궁수 정보 클래스
    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer) 
        {
            // 부모 함수 상속
            SetInfo(75, 15);
        }
    }

    // 법사 정보 클래스
    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            // 부모 함수 상속
            SetInfo(50, 20);
        }
    }

    // 도적 정보 클래스
    class Thief : Player
    {
        public Thief() : base(PlayerType.Thief) 
        {
            // 부모 함수 상속
            SetInfo(80, 12);
        }
    }
}
