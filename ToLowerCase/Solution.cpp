#include <iostream>
#include <string>

class Solution 
{
public:
    std::string toLowerCase(std::string s) 
    {
        for (char& c : s) 
        {
            if (c >= 'A' && c <= 'Z') 
                c = c - ('A' - 'a');
        }
        return s;
    }
};

int main() {
    Solution solution;
    
    std::string test1 = "Hello";
    std::cout << "Input: " << test1 << " -> Output: " << solution.toLowerCase(test1) << std::endl;

    std::string test2 = "here";
    std::cout << "Input: " << test2 << " -> Output: " << solution.toLowerCase(test2) << std::endl;

    std::string test3 = "LOVELY";
    std::cout << "Input: " << test3 << " -> Output: " << solution.toLowerCase(test3) << std::endl;

    return 0;
}
