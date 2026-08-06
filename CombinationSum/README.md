# Combination Sum

Rozwiązanie problemu "Combination Sum" za pomocą programowania dynamicznego (DP).

## Opis

Algorytm znajduje wszystkie unikalne kombinacje liczb z tablicy `candidates`, które sumują się do wartości `target`. Liczby z tablicy mogą być używane wielokrotnie.

## Algorytm

1. Inicjalizujemy tablicę `combinationsForSum` rozmiaru `target + 1`, gdzie pod indeksem `i` będziemy przechowywać listę kombinacji dających sumę `i`.
2. Dla sumy `0` ustawiamy jedną pustą kombinację.
3. Iterujemy po każdym kandydacie `candidate` z tablicy `candidates`.
4. Dla każdego kandydata przechodzimy przez możliwe sumy `currentSum` od wartości kandydata do docelowego `target`.
5. Jeżeli dla sumy `currentSum - candidate` istnieje jakaś kombinacja, dodajemy do niej aktualnego kandydata i zapisujemy jako nową kombinację dla sumy `currentSum`.
6. Wynikiem jest zbiór kombinacji dla indeksu `target`.

Dzięki iterowaniu najpierw po kandydatach unikamy powtarzania się kombinacji o tych samych elementach (np. `[2, 3]` i `[3, 2]`).

## Uruchomienie testów

Kod zawiera wbudowane testy w metodzie `Main`.
Aby uruchomić kod można użyć kompilatora C#, np.:

```bash
csc Solution.cs
.\Solution.exe
```
