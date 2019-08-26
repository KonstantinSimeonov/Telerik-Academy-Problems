#include <iostream>
using namespace std;

int degrees[8001];

int main()
{
    cin.tie(0);
    ios::sync_with_stdio(false);

    size_t n;
    cin >> n;

    for(size_t i = 0; i < n; i++)
    {
        string name;
        int crossings, streets;

        cin >> name >> crossings >> streets;

        for(size_t j = 1; j < crossings + 1; j++)
        {
            degrees[j] = 0;
        }

        for(size_t j = 0; j < streets; j++)
        {
            int from, to;

            cin >> from >> to;

            degrees[from]++;
            degrees[to]++;
        }

        cout << name;
        int oddCrossingsCount = 0;

        for(size_t j = 1; j < crossings + 1; j++)
        {
            if((degrees[j] & 1) == 1)
            {
                oddCrossingsCount++;

                if(oddCrossingsCount > 2)
                {
                    break;
                }
            }
        }

        if(oddCrossingsCount == 0)
        {
            cout << " Wolf";
        }
        else if(oddCrossingsCount == 2)
        {
            cout << " Titan";
        }
        else
        {
            cout << " Dirty";
        }

        cout << endl;
    }

    return 0;
}
