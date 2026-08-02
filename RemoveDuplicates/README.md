<div style="text-align: justify;">

# Remove Duplicates from Sorted Array

## Opis problemu
**Remove Duplicates from Sorted Array**

Zadanie polega na usunięciu duplikatów z posortowanej tablicy (wektora) w taki sposób, aby każdy unikalny element wystąpił tylko raz, zachowując przy tym pierwotną kolejność elementów. Zmiany muszą zostać dokonane w miejscu (in-place).

**Przykład 1:**
Wejście: `nums = [1,1,2]`
Wyjście: `2, nums = [1,2]` (zwracana jest nowa długość, a początkowe elementy tablicy zawierają unikalne wartości)

**Przykład 2:**
Wejście: `nums = [0,0,1,1,1,2,2,3,3,4]`
Wyjście: `5, nums = [0,1,2,3,4]`

## Implementacja
W pliku `Solution.cpp` zaimplementowano iteracyjne rozwiązanie problemu wykorzystujące wbudowane metody wektora:
- **Złożoność czasowa:** $O(N^2)$ w pesymistycznym wariancie, ponieważ operacja `erase` w klasie `std::vector` wymusza przesunięcie wszystkich kolejnych elementów w pamięci (gdzie $N$ to liczba elementów). Wyszukiwanie duplikatów i grupowanie ich w przedziały znacząco optymalizuje proces, redukując liczbę wywołań metody przesuwającej.
- **Złożoność pamięciowa:** $O(1)$, algorytm modyfikuje wektor wejściowy bezpośrednio w miejscu.
- **Opis algorytmu:** Pętla iteruje przez podaną tablicę. Dla każdego elementu wyznaczany jest koniec przedziału sąsiadujących, identycznych wartości. Po jego określeniu, nadmiarowe elementy w danym przedziale są zbiorczo usuwane za pomocą jednego wywołania metody `erase`.

## Testowanie
W pliku `Solution.cpp` przygotowano funkcję `main`, która weryfikuje poprawność algorytmu na przykładowym zestawie danych (`{1, 1, 2, 2, 3, 4, 4, 5}`). Wyświetlana jest nowa długość oraz stan tablicy po usunięciu duplikatów, aby móc potwierdzić prawidłowość operacji.

</div>
