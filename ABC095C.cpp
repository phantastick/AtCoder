#include<iostream>
#include<string>
#include<algorithm>
#include<vector>
#include<map>
#include<queue>
#include<list>
using namespace std;

long long p[1] = {};

int main()
{
	int A, B, C, X, Y;
	cin >> A >> B >> C >> X >> Y;

	int sum = A*X + B*Y;

	if (A + B > 2 * C)
	{
		int minimum = min(X,Y);
		sum = sum - A*minimum - B*minimum + 2 * C*minimum;
		X -= minimum;
		Y -= minimum;
	
		int maximum = max(X, Y);
		if (maximum != 0)
		{
			int left_pizza_value = (X != 0) ? A : B;
			if (left_pizza_value > 2 * C)
			{
				sum = sum - left_pizza_value*(X + Y) + 2 * C*(X + Y);
			}

		}
	}
	cout << sum << endl;
	return 0;
}
