# Contains Duplicate

Rozwiązanie sprawdzające czy w tablicy liczb całkowitych występują duplikaty.

## Opis

Wykorzystano `std::unordered_map<int, bool>` do śledzenia wystąpień poszczególnych liczb. Pętla przechodzi przez elementy tablicy:
- Jeżeli element znajduje się już w słowniku, funkcja od razu zwraca `true`.
- Jeżeli nie, liczba dodawana jest do słownika z wartością `true`.

Złożoność czasowa tego rozwiązania to O(N), gdzie N to liczba elementów w tablicy. Złożoność pamięciowa to O(N).

## Uruchomienie

Kompilacja i uruchomienie programu testowego z poziomu terminala:

```bash
g++ Solution.cpp -o Solution.exe
.\Solution.exe
```
