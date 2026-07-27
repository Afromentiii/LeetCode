<div style="text-align: justify;">

# Valid Parentheses

## Opis problemu
**20. Valid Parentheses** (Easy)

Mając dany ciąg znaków `s` zawierający wyłącznie znaki `'('`, `')'`, `'{'`, `'}'`, `'['` i `']'`, określ, czy ciąg wejściowy jest prawidłowy.

Ciąg wejściowy jest prawidłowy, jeśli:
1. Nawiasy otwierające muszą być zamykane przez nawiasy tego samego typu.
2. Nawiasy otwierające muszą być zamykane w prawidłowej kolejności.
3. Każdy nawias zamykający ma odpowiadający mu nawias otwierający tego samego typu.

**Przykład 1:**
Wejście: `s = "()"`
Wyjście: `true`

**Przykład 2:**
Wejście: `s = "()[]{}"`
Wyjście: `true`

**Przykład 3:**
Wejście: `s = "(]"`
Wyjście: `false`

**Ograniczenia:**
- `1 <= s.length <= 10^4`
- `s` składa się tylko z nawiasów `()[]{}`.

## Zrealizowane cele
- Zaimplementowano klasyczne, optymalne rozwiązanie wykorzystujące strukturę stosu (`Stack`).
- Osiągnięto złożoność czasową O(n), gdzie n to długość ciągu wejściowego `s`, z uwagi na fakt, że każdy znak jest przetwarzany dokładnie raz.
- Skonstruowano logikę opartą o pojedynczą iterację, z natychmiastowym przerywaniem działania (Fail-Fast) w przypadku napotkania niezgodności.

## Uzasadnienie i metodologia realizacji
- Użycie struktury **Stosu (Stack)** jest modelowym sposobem podejścia do tego problemu. Architektura LIFO (Last-In-First-Out) idealnie odpowiada wymaganiu zamykania nawiasów w odwrotnej kolejności do ich otwierania (najpóźniej otwarty nawias musi zostać zamknięty jako pierwszy).
- Algorytm przechodzi pętlą po wszystkich znakach w napisie. Każdy znak otwierający jest bezpośrednio "wrzucany" na stos (`Push`).
- Kiedy algorytm natrafia na znak zamykający, natychmiast próbuje zdjąć (`Pop`) ostatni element ze szczytu stosu. Jeśli stos jest już pusty (brak pasującego otwarcia) lub zdjęty nawias nie odpowiada typowi nawiasu zamykającego, ciąg jest nieprawidłowy, a program natychmiast przerywa działanie (`return false`).
- Końcowym warunkiem pełnej zgodności, po przeanalizowaniu całego napisu, jest opróżniony stos (`stack.Count == 0`). Oznacza to, że dla każdego elementu otwierającego ostatecznie odnaleziono jego zamknięcie i żaden nawias nie pozostał samotny.

## Wady
- Zastosowanie generycznej klasy `Stack<char>` ze standardowej biblioteki narzuca konieczność dynamicznej alokacji kolekcji na stercie. Oznacza to złożoność pamięciową O(n) w najgorszym pesymistycznym przypadku (np. ciąg składający się z tysięcy wyłącznie otwierających nawiasów).
- Na potrzeby ultra-wydajnych operacji, użycie wbudowanej klasy stosu mogłoby stanowić mikrosekundowe opóźnienie w stosunku do rozwiązania niskopoziomowego, wykorzystującego chociażby zwykłą prealokowaną tablicę (`char[]`) i zmienną (indeks/pointer) pełniącą rolę mechanizmu przesuwania się w górę i w dół takiego pseudo-stosu.

</div>
