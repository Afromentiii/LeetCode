<div style="text-align: justify;">

# Single Number

## Opis problemu
**Single Number**

Zadanie polega na znalezieniu elementu, który występuje w podanej tablicy tylko raz. Zakładamy, że każdy inny element występuje w niej dokładnie dwa razy.

**Przykład 1:**
Wejście: `nums = [2,2,1]`
Wyjście: `1`

**Przykład 2:**
Wejście: `nums = [4,1,2,1,2]`
Wyjście: `4`

**Przykład 3:**
Wejście: `nums = [1]`
Wyjście: `1`

## Implementacja
W pliku `Solution.cpp` zaimplementowano rozwiązanie oparte na zliczaniu wystąpień w słowniku połączone z dynamiczną aktualizacją wyniku:
- **Złożoność czasowa:** $O(N)$, ponieważ iterujemy po wszystkich elementach tablicy tylko raz (gdzie $N$ to liczba elementów). Operacje odczytu i zapisu na strukturze `std::unordered_map` są w średnim przypadku wykonywane w stałym czasie $O(1)$.
- **Złożoność pamięciowa:** $O(N)$, ponieważ do przechowywania ilości wystąpień poszczególnych wartości niezbędny jest dodatkowy słownik.
- **Opis algorytmu:** Pętla przechodzi iteracyjnie przez otrzymaną tablicę elementów. Dla każdej napotkanej wartości zliczana jest częstotliwość występowania. Wynik końcowy utrzymywany jest w osobnej, dynamicznie uaktualnianej zmiennej: jeśli liczba zostaje spotkana po raz pierwszy (licznik wynosi 1), dodajemy ją do ogólnego wyniku, z kolei jeśli pojawi się po raz drugi (licznik to 2), jej wartość jest odejmowana z rezultatu. Dzięki temu bilansuje się on na koniec algorytmu, ujawniając wartość pojedynczego (unikalnego) wystąpienia.

## Testowanie
W pliku `Solution.cpp` dołączono funkcję `main`, w której weryfikowane jest działanie programu na trzech przygotowanych przypadkach testowych, odpowiadających przykładom z opisu problemu.

</div>
