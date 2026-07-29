# MySqrt

Rozwiązanie problemu **Sqrt(x)** (LeetCode 69) w języku C#.

## Opis problemu
Biorąc pod uwagę nieujemną liczbę całkowitą `x`, należy obliczyć i zwrócić pierwiastek kwadratowy z `x` zaokrąglony w dół do najbliższej liczby całkowitej. Zwracana liczba całkowita powinna być również nieujemna.

Zabronione jest używanie wbudowanych funkcji bibliotecznych do potęgowania czy pierwiastkowania.

## Podejście do rozwiązania
W zaproponowanym rozwiązaniu użyto **Metody Newtona** (Newton-Raphson), która jest bardzo szybkim algorytmem do znajdowania przybliżonych wartości pierwiastków funkcji. Zgodnie ze wzorem:

`xNext = (xn + x / xn) / 2`

Obliczenia są powtarzane w pętli do momentu, aż kolejne przybliżenia przestaną maleć (`xNext < xn`). Zastosowanie typu `long` zapobiega przekroczeniu dopuszczalnego rozmiaru dla typów całkowitoliczbowych podczas operacji dzielenia i dodawania dla bardzo dużych wartości wejściowych.

### Złożoność algorytmiczna
- **Czasowa:** $O(\log x)$ — w każdym kroku bardzo szybko zawężamy obszar poszukiwań.
- **Pamięciowa:** $O(1)$ — algorytm używa jedynie kilku dodatkowych zmiennych pomocniczych niezależnych od wielkości wejścia.

## Uruchomienie testów
Kod zawiera przygotowane przypadki testowe sprawdzające poprawność rozwiązania. Obejmują one:
- przypadki brzegowe (`0`, `1`)
- kwadraty doskonałe (`4`, `9`, `16`)
- nie-kwadraty (`2`, `8`)
- duże wartości bliskie limitowi `int` (`2147395599`)

Aby uruchomić kod wraz z testami z poziomu konsoli, wpisz:
```bash
dotnet run .\Solution.cs
```
