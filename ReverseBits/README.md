<div style="text-align: justify;">

# Reverse Bits

## Opis problemu
**Reverse Bits**

Zadanie polega na odwróceniu kolejności bitów danej 32-bitowej liczby całkowitej bez znaku (unsigned integer).

**Przykład 1:**
Wejście: `n = 43261596` (binarnie: `00000010100101000001111010011100`)
Wyjście: `964176192` (binarnie: `00111001011110000010100101000000`)

**Przykład 2:**
Wejście: `n = 4294967293` (binarnie: `11111111111111111111111111111101`)
Wyjście: `3221225471` (binarnie: `10111111111111111111111111111111`)

## Implementacja
W pliku `Solution.cpp` zaimplementowano iteracyjne rozwiązanie problemu:
- **Złożoność czasowa:** $O(1)$, ponieważ pętla wykonuje się zawsze dokładnie 32 razy, niezależnie od wartości wejściowej.
- **Złożoność pamięciowa:** $O(1)$, ponieważ do przechowywania wyniku wykorzystano tylko jedną dodatkową 32-bitową zmienną.
- **Opis algorytmu:** Pętla iteruje 32 razy. W każdym kroku aktualny wynik (`res`) jest przesuwany logicznie w lewo o 1 pozycję, zwalniając miejsce na kolejny bit. Następnie najmniej znaczący bit liczby wejściowej zostaje pobrany za pomocą operacji bitowej AND (`n & 1`) i dodany do wyniku używając operatora OR. Na koniec liczba wejściowa `n` zostaje przesunięta w prawo o 1 pozycję, by w kolejnym cyklu sprawdzić jej następny bit.

## Testowanie
W pliku `Solution.cpp` przygotowano funkcję `main`, która weryfikuje poprawność działania programu. Zawiera przypadki testowe obrazujące działanie algorytmu, używając przy tym szablonu `std::bitset` do przejrzystego prezentowania liczb i ich wartości w obu systemach – binarnym oraz dziesiętnym.

</div>
