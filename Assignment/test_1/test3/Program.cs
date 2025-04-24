using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test3
{
    class Square
    {
        float width;
        float height;

         float Area() { return width * height; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Square box = new Square();
            Console.WriteLine(box.Area());
        }
    }
}
