#include <iostream>
#include <vector>
#include <unordered_map>

using namespace std;

class Solution 
{
public:
    bool containsDuplicate(vector<int>& nums) 
    {
        unordered_map<int, bool> seen;
        for (int num : nums) {
            if (seen.count(num)) {
                return true;
            }
            seen[num] = true;
        }
        return false;
    }
};

int main() 
{
    Solution solution;
    vector<int> test1 = {1, 2, 3, 1};
    vector<int> test2 = {1, 2, 3, 4};
    
    cout << solution.containsDuplicate(test1) << "\n";
    cout << solution.containsDuplicate(test2) << "\n";
    
    return 0;
}