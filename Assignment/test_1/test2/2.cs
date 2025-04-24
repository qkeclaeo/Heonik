using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        private static void Add(int i, ref int result)   //ref 로 result 변수를 참조로 전달받게 하기
        {
            result += i;                          //result 값에 i 를 더함 
        }

        static void Main(string[] args)
        {
            int total = 10;
            Console.WriteLine(total);             //토탈값 출력 아마도 10
        
        
            
            Add(200, ref total);                  //add 200 , 위에 설정한 10 
            Console.WriteLine(total);             //토탈값과 200을 더한값..?
            
           
        }
    }
}
