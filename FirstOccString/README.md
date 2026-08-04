# Find the Index of the First Occurrence in a String

Rozwiązanie problemu polegającego na znalezieniu indeksu pierwszego wystąpienia podciągu (needle) w danym ciągu znaków (haystack).

## Opis

Wykorzystano podejście oparte na dwóch zagnieżdżonych pętlach. Zewnętrzna pętla iteruje po wszystkich możliwych pozycjach startowych w ciągu `haystack`, a wewnętrzna pętla sprawdza dopasowanie kolejnych znaków z ciągiem `needle`. W przypadku znalezienia pełnego dopasowania zwracany jest indeks startowy.

Złożoność czasowa tego rozwiązania wynosi w pesymistycznym przypadku O(N * M), gdzie N to długość ciągu `haystack`, a M to długość podciągu `needle`. Złożoność pamięciowa to O(1), ponieważ algorytm nie wymaga alokacji dodatkowej pamięci proporcjonalnej do wielkości danych wejściowych.

## Uruchomienie

Kompilacja i uruchomienie programu testowego z poziomu terminala:

```bash
csc Solution.cs
.\Solution.exe
```
