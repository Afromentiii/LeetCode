#include <iostream>
#include <vector>
#include <string>
#include <unordered_map>
#include <unordered_set>
#include <queue>
#include <cctype>

using namespace std;

class Solution 
{
public:
    string mostCommonWord(string paragraph, vector<string>& banned) 
    {
        unordered_set<string> ban_set(banned.begin(), banned.end());
        unordered_map<string, int> dict;
        
        string current_word = "";
        for (char c : paragraph) 
        {
            if (isalpha(c)) 
                current_word += tolower(c);
            
            else if (!current_word.empty()) 
            {
                if (ban_set.find(current_word) == ban_set.end()) 
                    dict[current_word]++;

                current_word = "";
            }
        }
        
        if (!current_word.empty() && ban_set.find(current_word) == ban_set.end()) 
            dict[current_word]++;
        
        priority_queue<pair<int, string>, vector<pair<int, string>>, greater<pair<int, string>>> min_heap;
        
        for (const auto& entry : dict) 
            min_heap.push({entry.second, entry.first});
        
        string last_element = "";
        while (!min_heap.empty()) 
        {
            last_element = min_heap.top().second;
            min_heap.pop();
        }
        
        return last_element;
    }
};

int main() 
{
    Solution sol;
    string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
    vector<string> banned = {"hit"};
    cout << sol.mostCommonWord(paragraph, banned) << "\n";
    return 0;
}
