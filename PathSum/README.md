<div style="text-align: justify;">

# Path Sum

## Opis problemu

**Path Sum** (Suma ścieżki)

Mając dany korzeń drzewa binarnego `root` oraz liczbę całkowitą `targetSum`, należy określić, czy w drzewie istnieje ścieżka od korzenia do liścia (root-to-leaf path), dla której suma wartości wszystkich węzłów na tej ścieżce jest równa `targetSum`.

Liść to węzeł, który nie posiada żadnych dzieci (brak lewego i prawego poddrzewa).

**Przykłady:**
- Wejście: `root = [5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1]`, `targetSum = 22` → Wyjście: `true` (istnieje ścieżka `5 -> 4 -> 11 -> 2`, której suma to 22).
- Wejście: `root = [1, 2, 3]`, `targetSum = 5` → Wyjście: `false` (istnieją dwie ścieżki od korzenia do liści: sumująca do 3 i sumująca do 4, żadna nie osiąga wartości 5).
- Wejście: `root = []`, `targetSum = 0` → Wyjście: `false` (ponieważ drzewo jest puste, nie ma ścieżki od korzenia do liścia).

## Implementacja

W pliku `Solution.cs` zaimplementowano podejście rekurencyjne oparte na przeszukiwaniu w głąb (DFS) wykorzystujące funkcję pomocniczą `Travel`. Przechodzi ona po węzłach, utrzymując bieżącą sumę wartości ścieżki i sprawdzając warunek przy każdym osiągnięciu liścia.

- **Złożoność czasowa:** $O(N)$ – gdzie $N$ to liczba węzłów w drzewie. W najgorszym przypadku, by zweryfikować wszystkie możliwe ścieżki (lub gdy szukana ścieżka znajduje się na końcu), algorytm musi odwiedzić każdy węzeł dokładnie jeden raz. Wykorzystanie referencji na zmienną `found` pozwala przerwać rekurencję od razu po znalezieniu odpowiedniej ścieżki.
- **Złożoność pamięciowa:** $O(N)$ – w najgorszym przypadku (drzewo całkowicie niezbalansowane) stos wywołań rekurencyjnych może osiągnąć głębokość $N$. Dla drzewa zbalansowanego głębokość ta wynosi średnio $O(\log N)$.

### Działanie algorytmu:
Algorytm analizuje węzły zaczynając od korzenia:
1. **Warunek bazowy (Null i znaleziono):** Jeśli bieżący węzeł jest pusty lub wcześniej udało się już znaleźć ścieżkę (`found == true`), rekurencja od razu wraca przerywając dalsze operacje.
2. **Dodawanie wartości:** Wartość bieżącego węzła jest dodawana do lokalnej (na poziomie rekurencji) sumy dotychczasowej ścieżki.
3. **Sprawdzenie liścia:** Jeśli przetwarzany węzeł to liść (nie ma lewego ani prawego dziecka), a dotychczas zgromadzona suma zgadza się z `targetSum`, to flaga `found` ustawiana jest na `true` i funkcja powraca.
4. **Rozgałęzienie (Rekurencja):** W przeciwnym razie algorytm rekurencyjnie kontynuuje poszukiwania dla lewego oraz prawego dziecka ze zaktualizowaną wartością `sum`.

## Testowanie

Na dole pliku `Solution.cs` zaimplementowano klasę `Program` w celu łatwego testowania napisanego rozwiązania w oderwaniu od głównych plików wejściowych. Metoda `Main` przygotowuje przypadki testowe ilustrujące główne ścieżki wykonania:
- Poprawne drzewo zawierające ścieżkę o wskazanej sumie.
- Drzewo bez ścieżki dającej pożądaną sumę docelową.

Szybka weryfikacja poprawności polega na jednorazowym odpaleniu terminalowej komendy:
```bash
dotnet run .\Solution.cs
```
Zwróci to wynik testów (`True` lub `False`) wypisany bezpośrednio do konsoli.

</div>
