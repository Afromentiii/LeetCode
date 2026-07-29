# Palindrome Number

Projekt zawiera implementację rozwiązania problemu "Palindrome Number", w którym należy sprawdzić, czy dana liczba całkowita czytana od lewej do prawej jest taka sama jak czytana od prawej do lewej. Program zwraca wartość logiczną `true` dla palindromów i `false` w przeciwnym razie.

## Implementacja

W pliku `Solution.cs` zaimplementowano podejście bazujące na konwersji na ciąg znaków i weryfikacji dwoma wskaźnikami:
- **Złożoność czasowa:** $O(N)$, gdzie $N$ to liczba cyfr podanej liczby (czyli $O(\log_{10} x)$).
- **Złożoność pamięciowa:** $O(N)$ na przechowanie liczby w postaci ciągu znaków (`string`).
- **Opis:** Algorytm w pierwszej kolejności eliminuje liczby ujemne, ponieważ nigdy nie są one palindromami (z uwagi na obecność znaku minus). Dla pozostałych liczb dokonywana jest konwersja do typu `string`. Za pomocą dwóch wskaźników (`cursorLeft` zaczynającego od początku oraz `cursorRight` od końca) sprawdzane są odpowiednie znaki. Jeżeli algorytm napotka różnicę, natychmiast kończy działanie zwracając `false`.

## Testowanie i Wydajność

W projekcie dodano podstawową metodę `Main`, która posłużyła do weryfikacji poprawności kodu. 
Zestaw testowy wbudowany w klasę `Solution` sprawdza typowe przypadki brzegowe i podstawowe:
- Klasyczny palindrom (np. `121`, `1221`, `11`)
- Liczba ujemna (np. `-121`)
- Liczba będąca wielokrotnością 10 (np. `10`)

Metoda uruchamia każdy z tych przypadków iterując po uprzednio przygotowanej tablicy i wypisuje wyniki sprawdzenia bezpośrednio do konsoli.

### Wyniki w LeetCode
Rozwiązanie przetestowane na platformie LeetCode uzyskało wynik wydajnościowy:
- **Liczba przypadków testowych:** 11 511
- **Czas wykonania:** zaledwie **2 ms**
