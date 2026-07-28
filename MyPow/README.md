# Pow(x, n)

Projekt zawiera implementację rozwiązania problemu algorytmicznego polegającego na zaimplementowaniu funkcji podnoszącej liczbę rzeczywistą `x` do potęgi `n`.

## Pełna Treść Problemu
Zaimplementuj funkcję `pow(x, n)`, która oblicza $x$ podniesione do potęgi $n$ (tj. $x^n$).

**Przykłady:**
- `x = 2.00000, n = 10` $\rightarrow$ zwraca `1024.00000`.
- `x = 2.10000, n = 3` $\rightarrow$ zwraca `9.26100`.
- `x = 2.00000, n = -2` $\rightarrow$ zwraca `0.25000` (ponieważ $2^{-2} = 1/2^2 = 1/4 = 0.25$).

## Implementacja

W pliku `Solution.cs` zaimplementowano optymalne podejście oparte na Szybkim Potęgowaniu (Fast Exponentiation) przy użyciu techniki *Dziel i Zwyciężaj (Divide and Conquer)*:

- **Złożoność czasowa:** $O(\log N)$
- **Złożoność pamięciowa:** $O(\log N)$ (ze względu na stos wywołań rekurencyjnych).
- **Opis:** Funkcja rekurencyjnie redukuje problem. Zamiast mnożyć $x$ przez siebie $n$ razy w pętli $O(N)$, algorytm wykorzystuje fakt, że:
  - Dla $n$ parzystych: $x^n = (x^{n/2})^2$
  - Dla $n$ nieparzystych: $x^n = (x^{n/2})^2 \times x$
  
  Takie rozwiązanie pozwala na niezwykle szybkie obliczenia nawet dla olbrzymich wykładników i omija problem przekroczenia limitu czasu (Time Limit Exceeded).

Dodatkowo zadbano o skrajny przypadek: użyto konwersji zmiennej potęgi z 32-bitowego `int` na 64-bitowy `long N`, aby bezpiecznie odwrócić znak ujemnego wykładnika wynoszącego `int.MinValue` ($-2147483648$). W standardowym typie `int`, operacja odwrócenia takiego znaku spowodowałaby przekroczenie maksymalnej granicy (ang. *Integer Overflow*).

## Testy i Wyniki

W pliku znajduje się gotowa metoda `Main` z zestawem zróżnicowanych przypadków testowych m.in. dla potęg ułamkowych, ujemnych oraz granic zakresu `integer`. 
Wydajność algorytmu w $O(\log N)$ została zweryfikowana względem natywnej systemowej implementacji C# (`Math.Pow`).

Przykładowy wynik z konsoli:
```text
Baza (x): 2, Wykładnik (n): 10
-> MyPow: 1024
-> Wbudowane Math.Pow: 1024

Baza (x): 2,1, Wykładnik (n): 3
-> MyPow: 9,261000000000001
-> Wbudowane Math.Pow: 9,261000000000001

Baza (x): -1, Wykładnik (n): -2147483648
-> MyPow: 1
-> Wbudowane Math.Pow: 1
```
