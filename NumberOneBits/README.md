<div style="text-align: justify;">

# Number of 1 Bits

## Opis problemu
**Number of 1 Bits (Hamming Weight)**

Zadanie polega na napisaniu funkcji, która przyjmuje liczbę całkowitą, a następnie zwraca liczbę jej "zapalonych" bitów (czyli bitów o wartości 1). Innymi słowy, funkcja ma obliczyć tzw. wagę Hamminga dla podanej liczby.

**Przykład 1:**
Wejście: `n = 11` (binarnie: `1011`)
Wyjście: `3`

**Przykład 2:**
Wejście: `n = 128` (binarnie: `10000000`)
Wyjście: `1`

## Implementacja
W pliku `Solution.cpp` zaimplementowano iteracyjne rozwiązanie problemu oparte o operacje bitowe:
- **Złożoność czasowa:** $O(1)$, ponieważ pętla wykonuje się zawsze dokładnie 32 razy (tyle, ile bitów mieści standardowy typ `int`), niezależnie od wartości argumentu wejściowego.
- **Złożoność pamięciowa:** $O(1)$, algorytm do zliczania zapalonych bitów wykorzystuje tylko jedną dodatkową zmienną.
- **Opis algorytmu:** Pętla wykonuje się 32 razy. W każdym kroku badany jest najmniej znaczący (najmłodszy) bit za pomocą operatora bitowego AND (`n & 1`). Jeśli bit jest jedynką, inkrementowany jest licznik. Następnie cała liczba zostaje przesunięta o 1 pozycję w prawo (`n >>= 1`), co umożliwia sprawdzenie kolejnego bitu w następnej iteracji.

## Testowanie
W pliku `Solution.cpp` przygotowano funkcję `main`, która automatycznie weryfikuje poprawność programu. Zawiera ona przypadki testowe sprawdzające działanie algorytmu m.in. dla liczb z pojedynczym zapalonym bitem, wieloma bitami, jak również dla liczb ujemnych (np. `-3`), co potwierdza poprawne zliczanie 31 bitów w reprezentacji uzupełnień do dwóch.

</div>
