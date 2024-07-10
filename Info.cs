using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG2
{ 
    // 정보의 주체 - 플레이어냐 몬스터냐
    public enum InfoType
    {
        None,
        Player = 1,
        Monster = 2
    }

    internal class Info
    {
        InfoType type;              // 타입 변수 정의
        protected int hp;           // 체력
        protected int attack;       // 공격력

        // 기본 생성자
        protected Info(InfoType type)
        {
            this.type = type;
        }

        // 체력 조회 함수
        public int GetHp() { return hp; }
        // 공격력 조회 함수
        public int GetAttack() { return attack; }
        // 죽음 처리 함수
        public bool IsDead() { return hp <= 0; }
        // 공격 받아 hp 계산 함수
        public void OnDamaged(int damage)
        {
            hp -= damage;
            if (hp < 0)
                hp = 0;
        }

        // 플레이어/몬스터 정보 (hp, atk 등) 정의 함수
        public void SetInfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }
    }
}
