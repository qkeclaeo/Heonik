using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test5
{
    //계속해서 정수를 입력받아 홀수인지 짝수인지 구분해주는 프로그램을 작성해보세요
    //정수가 아닌 데이터를 입력받으면 종료되게

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("숫자를 입력하세요");
                string answer = Console.ReadLine();

                bool inSuccess = int.TryParse(answer, out int result);
                //TODO 입력받은 정수가 홀수인지 짝수인지 구분하는 코드 작성
                //2로 나눴을때 나머지가 나온다면 홀수 아니라면 짝수
                if (!inSuccess)
                {
                    Console.WriteLine("정수가 아닙니다 프로그램을 종료합니다..");
                    break;
                }

                else {

                    if (result % 2 == 0)
                    {
                        Console.WriteLine("짝수 입니다");
                    }

                    else
                    {
                        Console.WriteLine("홀수 입니다");
                    } 
                }
                    
                
                } 
            }
                

        }
    }
