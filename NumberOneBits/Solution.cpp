#include <iostream>

using namespace std;

class Solution 
{
public:
    int hammingWeight(int n) 
    {
        int count = 0;
        for (int i = 0; i < 32; i++) 
        {
            if (n & 1) 
            {
                count++;
            }
            n >>= 1;
        }
        return count;
    }
};

int main() 
{
    Solution solution;
    
    int test1 = 11; // binarnie: 1011 (3 zapalone bity)
    int test2 = 128; // binarnie: 10000000 (1 zapalony bit)
    int test3 = -3; // binarnie: 11111111111111111111111111111101 (31 zapalonych bitów)
    
    cout << "11: " << solution.hammingWeight(test1) << "\n";
    cout << "128: " << solution.hammingWeight(test2) << "\n";
    cout << "-3: " << solution.hammingWeight(test3) << "\n";
    
    return 0;
}