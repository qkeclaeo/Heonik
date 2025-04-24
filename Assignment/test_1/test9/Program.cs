using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();   //int형 값을 저장하는 스택 생성

        stack.Push(1);  //스택 1
        stack.Push(2);  // 스택 1, 2 
        stack.Push(3); // 스택 1, 2, 3 
        stack.Pop();  // 마지막으로 넣은 값 제거 
        Console.WriteLine(stack.Pop());   //pop을 한번 더 하고 남은것 출력  앞서 3이 사라졌고 이 줄로 2번이 pop 됨  pop 된 2번 출력  남은건 1      
        stack.Push(4);   // 1만남아있었는데 4 넣기
        stack.Push(5);   // [ 5 넣어서 스택 1, 4, 5  가 됨
        
        while (stack.Count > 0)   // 스택이 빌때까지  pop 을 계속해서 출력   순서대로 5 4 1 이 출력됨 
            Console.WriteLine(stack.Pop());
    }
}