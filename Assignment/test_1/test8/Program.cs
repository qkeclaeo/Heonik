using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test8
{
    // DFS 는 깊이우선탐색으로 말 그대로 끝까지 내려간 후 다른방향으로 전환합니다 
       // 즉  방문하는 순서는 1 -> 2 -> 3 -> 6 -> 9 -> 7 -> 4 -> 8 -> 5  순입니다.
       // 1 -> 2 (없음)
       // 다시 위로 3 -> 6 -> 9  (없음)
       // 다시 위로 7 (없음)
       // 다시 위로 4 -> 8 (없음)
       // 다시 위로 5 
    // BFS 는 너비 우선 탐색으로 루트에 가까운 노드부터, 같은 층에 있는 노드들을 다 보고 다음으로 전환합니다.
        // 방문 순서는 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9  순 입니다. 
        // 0 : 1
        // 1 : 2 , 3 , 4 , 5
        // 2 : 6 , 7 , 8
        // 3 : 9
}
