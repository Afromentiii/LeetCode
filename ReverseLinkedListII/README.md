# Reverse Linked List II

Projekt zawiera implementację rozwiązania klasycznego problemu "Reverse Linked List II", w którym zadaniem jest odwrócenie fragmentu listy jednokierunkowej, znajdującego się pomiędzy dwiema pozycjami: `left` oraz `right`. 

## Pełna Treść Problemu
Mając daną głowę (`head`) listy jednokierunkowej oraz dwie liczby całkowite `left` i `right`, gdzie `left <= right`, odwróć węzły listy począwszy od pozycji `left` do pozycji `right`, a następnie zwróć odwróconą listę.

**Przykłady:**
- `head = [1, 2, 3, 4, 5], left = 2, right = 4` $\rightarrow$ zwraca `[1, 4, 3, 2, 5]`.
- `head = [5], left = 1, right = 1` $\rightarrow$ zwraca `[5]`.

## Implementacja

W pliku `Solution.cs` zaimplementowano niezwykle wydajne i powszechnie uznane optymalne podejście iteracyjne operujące na przepinaniu wskaźników "w locie":

- **Złożoność czasowa:** $O(N)$ (wykonujemy zaledwie jedno przejście przez listę)
- **Złożoność pamięciowa:** $O(1)$ (odwracanie odbywa się w miejscu, nie używamy dodatkowych struktur danych, np. stosów)
- **Opis mechanizmu:** 
  1. Stworzenie tzw. węzła `dummy` przed głową listy. Ułatwia to drastycznie operacje (szczególnie przypadek graniczny, w którym odwracanie ma zacząć się od samego początku, czyli `left = 1`).
  2. Ustawienie wskaźnika `pre` tuż przed początkiem odwracanego fragmentu (czyli na indeksie `left - 1`).
  3. Złapanie obszaru roboczego za pomocą węzłów `start` i `then`.
  4. Wewnątrz pętli iterującej po odwracanym obszarze, kolejny węzeł (`then`) jest za każdym razem "wyciągany" i przepinany bezpośrednio tuż za węzłem `pre`. Dzięki temu skrajny lewy węzeł naturalnie przesuwa się na tył.

## Testy

Plik został opatrzony metodą `Main` z funkcjami pomocniczymi potrafiącymi dynamicznie zbudować w pełni poprawną listę jednokierunkową na bazie prostej tablicy, a po zakończeniu testu przetłumaczyć ją i wydrukować w czytelnej formie. 

Zestaw testowy sprawdza m.in.:
- Klasyczne wycięcie środka z listy elementów.
- Skrajny problem odwracania dla jednoelementowej struktury.
- Zmianę samej "głowy", np. całej 3-elementowej listy (by przetestować niezawodność węzła `dummy`).

Wynik uruchomienia symulacji na w/w testach przebiega bezbłędnie:
```text
Testy dla Reverse Linked List II:

Lista początkowa: [1, 2, 3, 4, 5], Left: 2, Right: 4
Lista po odwróceniu: [1, 4, 3, 2, 5]

Lista początkowa: [5], Left: 1, Right: 1
Lista po odwróceniu: [5]

Lista początkowa: [1, 2, 3], Left: 1, Right: 3
Lista po odwróceniu: [3, 2, 1]

Lista początkowa: [1, 2, 3, 4, 5, 6, 7], Left: 3, Right: 6
Lista po odwróceniu: [1, 2, 6, 5, 4, 3, 7]
```
