#include <iostream>
#include <cstdint>
#include <bitset>

class Solution 
{
public:
    uint32_t reverseBits(uint32_t n) 
    {
        uint32_t res = 0;
        for (int i = 0; i < 32; ++i) 
        {
            res <<= 1;
            res |= (n & 1);
            n >>= 1;
        }
        return res;
    }
};

int main() 
{
    Solution solution;
    
    uint32_t test1 = 43261596; 
    std::cout << "Input:  " << std::bitset<32>(test1) << " (" << test1 << ")\n";
    uint32_t result1 = solution.reverseBits(test1);
    std::cout << "Output: " << std::bitset<32>(result1) << " (" << result1 << ")\n\n";

    uint32_t test2 = 4294967293; 
    std::cout << "Input:  " << std::bitset<32>(test2) << " (" << test2 << ")\n";
    uint32_t result2 = solution.reverseBits(test2);
    std::cout << "Output: " << std::bitset<32>(result2) << " (" << result2 << ")\n";

    return 0;
}
