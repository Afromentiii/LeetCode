<div style="text-align: justify;">

# Validate Binary Search Tree

## Opis problemu

**Validate Binary Search Tree** (Sprawdź poprawność drzewa poszukiwań binarnych)

Mając dany korzeń drzewa binarnego `root`, należy określić, czy jest to poprawne drzewo poszukiwań binarnych (BST).

Poprawne drzewo BST jest zdefiniowane następująco:
- Lewe poddrzewo węzła zawiera tylko węzły z kluczami mniejszymi niż klucz tego węzła.
- Prawe poddrzewo węzła zawiera tylko węzły z kluczami większymi niż klucz tego węzła.
- Zarówno lewe, jak i prawe poddrzewo muszą być również poprawnymi drzewami poszukiwań binarnych.

**Przykłady:**
- Wejście: `root = [2, 1, 3]` → Wyjście: `true`
- Wejście: `root = [5, 1, 4, null, null, 3, 6]` → Wyjście: `false`

## Implementacja

W pliku `Solution.cs` zaimplementowano podejście rekurencyjne wykorzystujące funkcję pomocniczą `IsValidTravel`. Funkcja ta przekazuje dopuszczalny zakres wartości (od `min` do `max`) dla każdego węzła, który jest aktualizowany w miarę schodzenia w dół drzewa.

- **Złożoność czasowa:** $O(N)$ – gdzie $N$ to liczba węzłów w drzewie. W najgorszym przypadku algorytm musi odwiedzić każdy węzeł dokładnie jeden raz.
- **Złożoność pamięciowa:** $O(N)$ – w najgorszym przypadku (drzewo całkowicie niezbalansowane, przypominające listę) stos wywołań rekurencyjnych może osiągnąć głębokość $N$. Dla drzewa zbalansowanego głębokość ta wynosi $O(\log N)$.

### Działanie algorytmu:
Algorytm analizuje węzły zaczynając od korzenia:
1. **Warunek początkowy:** Na początku dopuszczalny zakres wartości to od `long.MinValue` do `long.MaxValue` (użyto typu `long`, aby zapobiec problemom z wartościami granicznymi typu `int`).
2. **Sprawdzenie wartości:** Dla każdego węzła sprawdzane jest, czy jego wartość mieści się w dozwolonym przedziale `(min, max)`. Jeśli tak nie jest, drzewo jest niepoprawne i zwracane jest `false`.
3. **Rekurencja:** Następnie algorytm wywołuje się rekurencyjnie dla lewego i prawego dziecka:
   - Dla lewego dziecka maksymalna dozwolona wartość jest ograniczana do wartości obecnego węzła.
   - Dla prawego dziecka minimalna dozwolona wartość jest podnoszona do wartości obecnego węzła.
4. Puste węzły (`null`) są uznawane za poprawne i od razu zwracają `true`.

## Testowanie

Na dole pliku `Solution.cs` zaimplementowano klasę `Program` w celu łatwego testowania napisanego rozwiązania w oderwaniu od głównych plików wejściowych. Metoda `Main` przygotowuje przypadki testowe ilustrujące zachowanie algorytmu:
- Poprawne drzewo składające się z trzech węzłów.
- Niepoprawne drzewo naruszające zasady w prawym poddrzewie.

Szybka weryfikacja poprawności polega na odpaleniu komendy w terminalu:
```bash
dotnet run .\Solution.cs
```
Zwróci to wynik testów logicznych w postaci wartości boolean (`True` lub `False`) wypisanych do konsoli.

</div>
