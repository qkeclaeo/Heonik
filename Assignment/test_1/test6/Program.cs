using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test6
{
    class Program
    {
        //밑줄 부분을 채워 코드를 완성하세요.. 결과값이.. 2 3 4 5 6 7 8 ?    오름차순으로 정렬? 
        static void Main(string[] args)
        {
            int[] intArr = { 4 , 7 , 2 , 5 , 6 , 8 , 3 };

            Array.Sort(intArr);

            foreach (int i in intArr)
                Console.Write(i + " ");
        }
    }
}
