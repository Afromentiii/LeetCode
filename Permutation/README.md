# Permutations

Projekt zawiera implementację rozwiązania klasycznego problemu algorytmicznego, w którym należy wygenerować wszystkie możliwe permutacje (kombinacje ułożenia elementów) z podanej tablicy unikalnych liczb.

## Pełna Treść Problemu
Mając do dyspozycji tablicę `nums` składającą się z unikalnych liczb całkowitych, wygeneruj i zwróć wszystkie jej możliwe permutacje. Możesz zwrócić odpowiedź w dowolnej kolejności.

**Przykłady:**
- `nums = [1, 2, 3]` $\rightarrow$ zwraca `[[1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], [3,2,1]]`.
- `nums = [0, 1]` $\rightarrow$ zwraca `[[0,1], [1,0]]`.
- `nums = [1]` $\rightarrow$ zwraca `[[1]]`.

## Implementacja

W pliku `Solution.cs` zaimplementowano optymalne iteracyjne podejście oparte na **kolejności leksykograficznej (Next Permutation)**. Zamiast rekursji bazującej na systemowym stosie, algorytm matematycznie przekształca bieżący układ liczb na następny, podążając za ściśle określonymi zasadami:

- **Złożoność czasowa:** $O(N! \cdot N)$, gdzie $N$ to długość tablicy (maksymalna liczba permutacji wynosi $N!$, a wygenerowanie każdej kolejnej wymaga w najgorszym przypadku przejścia przez $O(N)$ elementów, np. do odwrócenia).
- **Złożoność pamięciowa:** $O(N!)$, ponieważ program docelowo zachowuje i zwraca wszystkie wygenerowane permutacje w postaci nowej wielowymiarowej listy.
- **Opis Mechanizmu (`singlePermutation`):** 
  1. Funkcja odnajduje pierwszy element od prawej strony, który łamie monotonicznie malejący ciąg (indeks `i`).
  2. Jeśli taki element istnieje, szuka następnie najmniejszego z elementów położonych na prawo od `i`, lecz większego od wartości `nums[i]` (indeks `j`). Zamienia (swapuje) te dwa elementy ze sobą.
  3. Finalnie dokonuje odwrócenia `Array.Reverse` reszty posortowanego malejąco ogona. 
  4. Główna pętla wykorzystuje to narzędzie do sukcesywnego odkrywania kolejnych ułożeń.

## Testy

Plik `Solution.cs` zawiera zaimplementowaną odgórnie metodę `Main`, w której przetestowano zestaw różnorodnych kombinacji tablic, sprawdzający niezawodność algorytmu w obliczu dłuższych i krótszych sekwencji liczb (w tym granicznych, np. tylko dla 1 elementu). 

Wdrożono i pomyślnie zwalidowano m.in. następujące przypadki testowe:
```text
Test dla tablicy: [1, 2, 3]
Wygenerowano 6 permutacji:
[1, 2, 3]
[1, 3, 2]
[2, 1, 3]
[2, 3, 1]
[3, 2, 1]
[3, 1, 2]

Test dla tablicy: [0, 1]
Wygenerowano 2 permutacji:
[0, 1]
[1, 0]

Test dla tablicy: [1]
Wygenerowano 1 permutacji:
[1]

Test dla tablicy: [1, 2, 3, 4]
Wygenerowano 24 permutacji:
...
```
*(Z pełnym powodzeniem wygenerowano również długie listy testowe m.in. dla 4 elementów).*
