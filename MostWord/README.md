# Most Common Word

Rozwiązanie problemu polegającego na znalezieniu najczęściej występującego słowa w tekście, które nie znajduje się na liście zablokowanych.

## Opis

Wykorzystano `std::unordered_map<string, int>` do zliczania wystąpień słów oraz `std::unordered_set<string>` w celu szybkiego (O(1)) sprawdzania, czy dane słowo jest zablokowane (banned). Następnie wszystkie słowa wraz z ich częstotliwością są wrzucane do min-kopca (`std::priority_queue` z użyciem `std::greater`). Słowo z najwyższą liczbą wystąpień zostaje zwrócone po zdjęciu wszystkich elementów z kopca.

Złożoność czasowa tego rozwiązania wynosi w przybliżeniu O(N log N), gdzie N to liczba unikalnych słów wrzucanych do kopca. Złożoność pamięciowa to O(N) ze względu na konieczność przechowywania mapy i kopca.

## Uruchomienie

Kompilacja i uruchomienie programu testowego z poziomu terminala:

```bash
g++ Solution.cpp -o Solution.exe
.\Solution.exe
```
