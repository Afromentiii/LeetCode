<div style="text-align: justify;">

# Plus One

## Opis problemu

**Plus One** (Plus jeden)

Mając daną dużą liczbę całkowitą zapisaną w postaci tablicy cyfr `digits`, gdzie każdy element `digits[i]` odpowiada kolejnej cyfrze tej liczby (od najbardziej do najmniej znaczącej), należy zwiększyć tę liczbę o jeden i zwrócić wynik w takiej samej formie. Z założenia tablica nie zawiera wiodących zer.

**Przykłady:**
- Wejście: `[1, 2, 3]` → Wyjście: `[1, 2, 4]` (odpowiada liczbie 123 + 1 = 124)
- Wejście: `[4, 3, 2, 1]` → Wyjście: `[4, 3, 2, 2]`
- Wejście: `[9]` → Wyjście: `[1, 0]` (wymaga rozszerzenia rzędu wielkości)
- Wejście: `[9, 9, 9]` → Wyjście: `[1, 0, 0, 0]`

## Implementacja

W pliku `Solution.cs` zaimplementowano iteracyjne przechodzenie przez tablicę od końca (czyli od rzędu jedności) do początku. Struktura pętli `while` została wyczyszczona z niepotrzebnych zmiennych (np. trzymających flagę *carry*) i w jak najprostszy sposób rozwiązuje problem przepełnienia.

- **Złożoność czasowa:** $O(N)$ – gdzie $N$ to długość tablicy cyfr. W najgorszym przypadku pętla przejdzie przez całą długość tablicy (np. dla tablicy `[9, 9, 9]`). Średnia/najlepsza złożoność (optymistyczna) to $O(1)$, ponieważ zazwyczaj od razu udaje się powiększyć ostatnią cyfrę.
- **Złożoność pamięciowa:** $O(1)$ lub $O(N)$ – modyfikacje są dokonywane na oryginalnej tablicy (in-place) poza najgorszym scenariuszem ($O(N)$), gdy wszystkie cyfry były dziewiątkami, co wymusza alokację nowej powiększonej tablicy wyników.

### Działanie algorytmu:
Algorytm analizuje cyfry zaczynając od prawej strony:
1. **Brak przepełnienia:** Jeśli sprawdzana cyfra jest mniejsza niż 9, zostaje bezpośrednio zwiększona o 1, a zmodyfikowana w ten sposób oryginalna tablica jest natychmiast zwracana. Przerywa to dalszą iterację, znacznie przyspieszając wykonanie.
2. **Przepełnienie:** Jeśli analizowaną cyfrą jest 9, algorytm zamienia ją na 0 i kontynuuje pętlę przechodząc do kolejnego (wyższego) rzędu wielkości.
3. **Rozszerzenie rzędu:** Jeżeli pętla zakończy się i nie dojdzie do wcześniejszego zwrotu (np. liczba początkowa składała się z samych dziewiątek jak `[9, 9, 9]`), po pętli inicjowana jest nowa, powiększona o jeden wymiar tablica. Przypisujemy ręcznie wartość `1` tylko do pierwszego indeksu. Reszta domyślnie posiada poprawną wartość `0` nadaną w czasie alokacji.

## Testowanie

Na dole pliku `Solution.cs` zaimplementowano zagnieżdżoną klasę `Program` w celu łatwego testowania napisanego rozwiązania w oderwaniu od głównych plików wejściowych. Metoda `Main` przygotowuje cztery podstawowe przypadki brzegowe ilustrujące wszystkie strumienie logiczne:
- Zwykłe dodawanie z prawej krawędzi bez przepełnień (`[1, 2, 3]`),
- Przedłużone rozszerzenie dla jednej (`[9]`) i wielu cyfr (`[9, 9, 9]`).

Szybka weryfikacja poprawności polega na jednorazowym odpaleniu terminalowej komendy:
```bash
dotnet run .\Solution.cs
```
Zwróci to wynik operacji jako skonwertowany przez przecinki standardowy ciąg znakowy bez konieczności ingerowania w dodatkowe parsowania i duże payloady.

</div>
