#include <iostream>
#include <vector>
#include <queue>
using namespace std;

const int MAX_ACTIONS = 1001;

vector<int> graph[MAX_ACTIONS];
int parentsCount[MAX_ACTIONS];
priority_queue<int> actions;

int main()
{
    cin.tie(0);
    ios::sync_with_stdio(false);

    size_t n, m;
    cin >> n >> m;

    for(size_t i = 0; i < m; i++)
    {
        int from, to;
        cin >> from >> to;

        parentsCount[to]++;

        graph[from].push_back(to);
    }

    for(size_t i = 0; i < n; i++)
    {
        if(parentsCount[i] == 0)
        {
            actions.push(-i);
        }
    }

    while(!actions.empty())
    {
        int currentAction = -actions.top();
        actions.pop();

        cout << currentAction << endl;
        size_t length = graph[currentAction].size();

        for(size_t i = 0; i < length; i++)
        {
            parentsCount[graph[currentAction][i]]--;

            if(parentsCount[graph[currentAction][i]] == 0)
            {
                actions.push(-graph[currentAction][i]);
            }
        }
    }

    return 0;
}
