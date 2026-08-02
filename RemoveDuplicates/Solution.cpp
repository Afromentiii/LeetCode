#include <iostream>
#include <vector>

using namespace std;

class Solution 
{
public:
    int removeDuplicates(vector<int>& nums) 
    {
        if (nums.empty()) return 0;
        
        for (int i = 0; i < nums.size(); i++) 
        {
            int j = i + 1;
            while (j < nums.size() && nums[i] == nums[j]) 
            {
                j++;
            }
            if (j > i + 1) 
            {
                nums.erase(nums.begin() + i + 1, nums.begin() + j);
            }
        }
        
        return nums.size();
    }
};

int main() 
{
    Solution solution;
    vector<int> nums = {1, 1, 2, 2, 3, 4, 4, 5};
    
    int k = solution.removeDuplicates(nums);
    
    cout << "k: " << k << "\nnums: ";
    for (int i = 0; i < k; i++) 
    {
        cout << nums[i] << " ";
    }
    cout << "\n";
    
    return 0;
}
