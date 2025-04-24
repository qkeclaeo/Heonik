using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test7
{
    class Program
    {
        public class Unit
        {
            public virtual void Move()    //가상메서드 move  = 자식클래스에서 재정의 가능 
            {
                Console.WriteLine("두발로 걷기");        //move 의 기본값?
            }

            public void Attack()                         //일반 메서드 = 자식클래스에서 재정의 불가능
            {
                Console.WriteLine("Unit 공격");
            }
        }

        public class Marine : Unit          //마린 클래스 유닛 클래스 상속받음
        {
            //아무것도 불러오지 않았음 Move 나 Attack을 집어넣지 않았음 
        }

        public class Zergling : Unit         //저글링 클래스 유닛 클래스 상속받음
        {
            public override void Move()
            {
                Console.WriteLine("네발로 걷기");        //Move 를 네발로 걷기로 재정의  = 저글링의  Move 는 네발로 걷기
            }
        }

        static void Main(string[] args)
        {
            Zergling zerg = new Zergling();   //저글링 클래스에 저그라는 객체 생성 
            zerg.Move();       //저그 객체 Move  는 네발로걷기로 재정의 되었고, Move() 는 Console.WriteLine("네발로걷기"); 이므로 네발로 걷기 출력. 
        }
    }
}
