using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG2
{
    // 몬스터의 타입
    public enum MonsterType
    {
        None = 0,
        Slime = 1,
        Orc = 2,
        Skeleton = 3
    }

    internal class Monster : Info
    {
        // 기본 type 값 정의
        protected MonsterType type = MonsterType.None;

        // 기본 생성자 정의 - 부모 타입 상속
        protected Monster(MonsterType type) : base(InfoType.Monster)
        {
            this.type = type;
        }

        public MonsterType GetMonsterType() { return type; }
    }

    class Slime : Monster
    {
        public Slime() : base(MonsterType.Slime) 
        {
            SetInfo(25, 4);
        }
    }

    class Orc : Monster
    {
        public Orc() : base(MonsterType.Slime)
        {
            SetInfo(40, 8);
        }
    }

    class Skeleton : Monster
    {
        public Skeleton() : base(MonsterType.Slime)
        {
            SetInfo(30, 5);
        }
    }
}
