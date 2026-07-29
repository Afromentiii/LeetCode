<div style="text-align: justify;">

# Same Tree

## Opis problemu

**Same Tree** (Identyczne drzewa)

Mając dane korzenie dwóch drzew binarnych `p` i `q`, napisz funkcję sprawdzającą, czy te drzewa są takie same. Dwa drzewa binarne uważa się za identyczne, jeśli są strukturalnie takie same, a węzły na odpowiadających sobie pozycjach mają tę samą wartość.

## Implementacja

W pliku `Solution.cs` zaimplementowano klasyczne, rekurencyjne podejście do przeszukiwania drzew (ang. *Tree Traversal*). Za główną logikę odpowiada pomocnicza metoda `TwoTreeTraversal`.

- **Złożoność czasowa:** $O(N)$ – gdzie $N$ to mniejsza z liczby węzłów obu drzew, ponieważ w najgorszym przypadku musimy odwiedzić wszystkie odpowiednie węzły synchronicznie.
- **Złożoność pamięciowa:** $O(H)$ – gdzie $H$ to wysokość drzewa, co odpowiada maksymalnej głębokości stosu wywołań rekurencyjnych (w najgorszym przypadku $O(N)$ dla drzewa zdegenerowanego, $O(\log N)$ dla drzewa zrównoważonego).

### Działanie algorytmu:
Metoda `TwoTreeTraversal` wywoływana jest w każdym kroku rekurencji równolegle dla węzłów drzewa `p` i `q`, weryfikując w następującej kolejności:
1. **Zakończenie gałęzi:** Jeśli oba obecne węzły są puste (`null`), oznacza to prawidłowe zakończenie tej ścieżki i metoda zwraca `true`.
2. **Asymetria:** Jeżeli w tym samym momencie tylko jeden z węzłów jest pusty, struktura obu drzew jest różna – następuje natychmiastowe zwrócenie `false`.
3. **Różnica wartości:** Jeżeli wartości wewnątrz obu badanych węzłów nie są sobie równe (`p.val != q.val`), drzewa różnią się zawartością – zwaracane jest `false`.
4. **Rekurencja:** Jeśli wszystkie powyższe testy zostały pomyślnie zaliczone, funkcja zagłębia się rekurencyjnie równocześnie do lewego i prawego dziecka obu drzew. Wyniki obu odnóg łączone są operatorem logicznym AND (`&&`).

## Testowanie

Do projektu wbudowano prostą konsolową architekturę testową w klasie `Program`. Metoda `Main` definiuje od podstaw instrukcyjne przypadki użycia z pomocą odkomentowanej klasy `TreeNode`. Ręcznie skonstruowane obiekty drzew odwzorowują standardowe przypadki testowe i wypisują wynik ich przetworzenia na konsolę. Nie wykorzystuje się tu zaawansowanych plików `.json` czy `.txt`, opierając się na krótkich demonstracjach wywoływanych standardowym poleceniem `dotnet run`.

</div>
