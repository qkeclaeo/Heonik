using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static int Sum(int[] arr)
        {
            // TODO : 배열의 모든 요소의 합을 계산하는 코드 작성

            //합계를 저장할 변수 만들기
            int sum = 0;
            

            //배열의 첫번째부터 마지막까지 반복
            for (int i = 0; i < arr.Length; i++)
            {
                // 각 숫자를 sum 에 더함
                sum += arr[i];
            }
           
            
            //최종 합계
            return sum;
            //////////////////////////////////////////
        }

        static void Main(string[] args)
        {
            int[] ints = { 3, 6, 7, 9 };
            Console.WriteLine(Sum(ints));
        }
    }
}
