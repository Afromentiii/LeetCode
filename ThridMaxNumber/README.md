<div style="text-align: justify;">

# Third Maximum Number

## Opis problemu
**Third Maximum Number**

Mając daną tablicę liczb całkowitych `nums`, należy zwrócić trzecią co do wielkości unikalną liczbę w tej tablicy. Jeśli trzecia największa liczba nie istnieje, należy zwrócić największą liczbę.

**Przykład 1:**
Wejście: `nums = [3, 2, 1]`
Wyjście: `1`

**Przykład 2:**
Wejście: `nums = [1, 2]`
Wyjście: `2`

**Przykład 3:**
Wejście: `nums = [2, 2, 3, 1]`
Wyjście: `1`

## Implementacja
W pliku `Solution.cs` zaimplementowano podejście z wykorzystaniem sortowania (*QuickSort*):
- **Złożoność czasowa:** $O(N \log N)$ średnio, gdzie $N$ to liczba elementów w tablicy, ze względu na wykorzystanie algorytmu QuickSort.
- **Złożoność pamięciowa:** $O(\log N)$ średnio dla stosu wywołań rekurencyjnych, w pesymistycznym przypadku $O(N)$.
- **Opis algorytmu:** Tablica jest najpierw sortowana malejąco za pomocą dedykowanej metody `QuickSortDescending`. Następnie algorytm przechodzi przez posortowaną tablicę, zliczając napotkane unikalne wartości. Gdy licznik unikalnych liczb osiągnie 3, zwracana jest aktualna wartość. Jeśli tablica nie zawiera trzech unikalnych elementów, po zakończeniu pętli zwracana jest największa wartość.

## Testowanie
W pliku `Solution.cs` przygotowano metodę `Main` w celu weryfikacji poprawności algorytmu na podstawowych przypadkach testowych.

</div>
