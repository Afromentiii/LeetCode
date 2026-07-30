# Rotate List

Rozwiązanie problemu **Rotate List** (LeetCode 61) w języku C#.

## Opis problemu
Mając daną głowę (`head`) listy jednokierunkowej, zadaniem jest obrót listy w prawo o `k` miejsc. Oznacza to, że każdy z elementów zostaje przesunięty w prawo, a ostatni element ląduje na początku listy powtarzając tę operację `k` razy.

## Podejście do rozwiązania
Zaimplementowane rozwiązanie postępuje w dwóch krokach:

1. **Obliczenie długości listy:** Algorytm najpierw przechodzi przez całą listę, by ustalić jej długość (zmienna `counter`). Jest to kluczowe zjawisko optymalizacyjne, ponieważ dla $K \ge N$ obrót o pełną długość listy daje w efekcie stan początkowy. Rzeczywista liczba przesunięć to zatem `k % counter`.
2. **Krokowe przesuwanie węzłów:** Jeśli lista wymaga przesunięcia (tj. `k % counter > 0`), program wykonuje odpowiednią liczbę iteracji. W każdej iteracji:
   - Znajdowany jest przedostatni węzeł listy (`lastNode`).
   - Ostatni węzeł (`tempNode`) jest odpinany z końca (`lastNode.next = null`).
   - Następnie węzeł ten jest dopinany na początek listy i staje się jej nową głową (`head`).

To podejście skutecznie realizuje logikę opisaną w zadaniu poprzez operacje bezpośrednio na wskaźnikach, bez potrzeby klonowania elementów czy używania struktur pomocniczych.

### Złożoność algorytmiczna
- **Czasowa:** $O(N \cdot (K \bmod N))$, gdzie $N$ to długość listy. Dzieje się tak, ponieważ w każdej z $K \bmod N$ iteracji przechodzimy przez większość listy, by dotrzeć do przedostatniego elementu. Wyznaczenie początkowej długości zajmuje czas $O(N)$. *(Uwaga: W optymalnej, alternatywnej wersji rozwiązanie to można zredukować do $O(N)$ poprzez utworzenie listy cyklicznej i rozcięcie jej w odpowiednim miejscu).*
- **Pamięciowa:** $O(1)$ — algorytm używa zaledwie kilku dodatkowych zmiennych pomocniczych do zarządzania wskaźnikami (in-place).

## Uruchomienie testów
Kod zawiera przygotowane przypadki testowe weryfikujące działanie logiki, obsługujące między innymi:
- Zwykłe rotacje (np. o 2 i 4 miejsca).
- Sytuacje, gdzie `k` przewyższa długość listy (`k = length` oraz `k > length`).
- Przypadki dla pustej rotacji (`k = 0`).
- Testowanie krótkich list jedno- i dwuelementowych.
- W pętli obracającej włączono wizualizację (debug), by móc na bieżąco monitorować, jak lista zmienia się z każdą iteracją.

Aby uruchomić kod wraz z testami z poziomu konsoli, wpisz:
```bash
dotnet run
```
*(Uwaga: w zależności od Twojego środowiska możliwe jest również uruchomienie testów komendą `dotnet run .\Solution.cs`)*
