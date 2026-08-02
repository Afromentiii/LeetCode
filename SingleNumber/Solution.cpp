#include <iostream>
#include <vector>
#include <unordered_map>

using namespace std;

class Solution 
{
public:
    int singleNumber(vector<int>& nums) 
    {
        unordered_map<int, int> counts;
        int unique_val = 0;
        
        for (int num : nums) 
        {
            counts[num]++;
            
            if (counts[num] == 1) 
                unique_val += num;
            else if (counts[num] == 2) 
                unique_val -= num;
        }
        
        return unique_val;
    }
};

int main() 
{
    Solution solution;
    
    vector<int> test1 = {2, 2, 1};
    vector<int> test2 = {4, 1, 2, 1, 2};
    vector<int> test3 = {1};
    
    cout << "Wynik dla [2, 2, 1]: " << solution.singleNumber(test1) << "\n";
    cout << "Wynik dla [4, 1, 2, 1, 2]: " << solution.singleNumber(test2) << "\n";
    cout << "Wynik dla [1]: " << solution.singleNumber(test3) << "\n";
    
    return 0;
}