<div style="text-align: justify;">

# Power of Two

## Opis problemu
**231. Power of Two** (Easy)

Dla danej liczby całkowitej `n`, napisz funkcję określającą, czy jest ona potęgą liczby dwa. Liczba całkowita `n` jest potęgą liczby dwa, jeśli istnieje liczba całkowita `x` taka, że `n == 2^x`.

**Przykład 1:**
Wejście: `n = 1`
Wyjście: `true`
Wyjaśnienie: $2^0 = 1$

**Przykład 2:**
Wejście: `n = 16`
Wyjście: `true`
Wyjaśnienie: $2^4 = 16$

**Przykład 3:**
Wejście: `n = 3`
Wyjście: `false`

**Ograniczenia:**
- `-2^31 <= n <= 2^31 - 1`

## Zrealizowane cele
- Zaimplementowano dwie metody rozwiązywania problemu: podejście wykorzystujące klasyczną rekurencję oraz wysoce zoptymalizowane rozwiązanie stosujące operacje na bitach.
- Zapewniono minimalizację złożoności czasowej z O(log n) dla metody rekurencyjnej do stałej wartości O(1) dla podejścia bitowego.
- Skonstruowano środowisko testowe w postaci klasy `Main`, sprawdzające i porównujące czas wykonania obu wariantów w wielokrotnej pętli iteracyjnej (5 milionów powtórzeń).
- Zweryfikowano całkowitą poprawność poprzez równoległe obliczenie sumy kontrolnej obu procedur (wyniki dla wszystkich testów były zgodne).

## Wyniki testów wydajnościowych
Poniżej przedstawiono wyniki udowadniające zgodność obliczeń oraz ilustrujące różnicę wydajności (zmierzoną przy użyciu wbudowanej klasy `Stopwatch`) między iteracją rekurencyjną a operacjami na bitach.

```text
Przykładowe wyniki:
n = 1            -> True
n = 2            -> True
n = 3            -> False
n = 4            -> True
n = 16           -> True
n = 218          -> False
n = 1024         -> True
n = 1048576      -> True
n = 1048577      -> False
n = 0            -> False
n = -1           -> False
n = -16          -> False
n = 2147483647   -> False
n = 1073741824   -> True

Czas BEZ optymalizacji bitowej (rekurencja): 3561 ms
Czas Z optymalizacja bitowa O(1): 568 ms
SUMA KONTROLNA: ZGODNA (Oba algorytmy zwaracaja ten sam wynik)
```
Odnotowano ponad sześciokrotne przyspieszenie działania algorytmu dla przypadku z optymalizacją bitową.

## Uzasadnienie i metodologia realizacji
1. **Rekurencja (`IsPowerOfTwo`)**: Algorytm sprawdza przypadki bazowe (`n <= 0` to fałsz, `n == 1` to prawda). Jeżeli liczba jest podzielna przez dwa bez reszty, następuje wywołanie rekurencyjne z parametrem zmniejszonym o połowę (`n / 2`). Złożoność jest proporcjonalna do O(log n).
2. **Optymalizacja bitowa (`IsPowerOfTwoFaster`)**: Metoda ta opiera się na specyfice systemu binarnego. Każda poprawna potęga liczby dwa zapisywana jest jako pojedyncza cyfra `1` i zera (np. 16 to binarnie `10000`). Wartość o jeden mniejsza (n - 1) przyjmuje w tym miejscu `0`, a wszystkie mniej znaczące pozycje zamienia na `1` (np. 15 to binarnie `01111`). Użycie logicznej koniunkcji bitowej (AND) w postaci operacji `n & (n - 1)` całkowicie "wygasza" te ciągi do samej wartości zero. Dodatkowy warunek `n > 0` chroni przed błędnym zaliczeniem zera lub liczb ujemnych. Podejście to wymaga tylko jednej oceny matematycznej, co skutkuje stałą złożonością czasową rzędu O(1).

## Wady
- Metoda rekurencyjna charakteryzuje się opóźnieniami systemowymi, wynikającymi z przydzielania kolejnych ramek stosu w pamięci środowiska programistycznego podczas odwołań zagnieżdżonych. Ponadto posiada większą w ujęciu matematycznym złożoność asymptotyczną.
- Metoda bitowa jest optymalna i kompletna – rozwiązuje przedstawiony problem zachowując zarówno optymalną wydajność procesora (minimalna liczba cykli zegara do ewaluacji matematycznej), jak i minimalną zajętość pamięci podręcznej.

</div>
