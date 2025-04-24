using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test4
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 2;  //x 초기값 2
            int y = 3;  // y 초기값 3

            x += x * ++y;    // y 에 1을 더해서 4가 되고 4x2 8 에 2를 더하면 10  수식은  x = 2+(2*4)  x = 10   

            Console.WriteLine(x++);
        }
    }
}
