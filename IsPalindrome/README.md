<div style="text-align: justify;">

# Valid Palindrome

## Opis problemu
**Valid Palindrome**

Mając dany ciąg znaków `s`, należy zwrócić `true`, jeśli jest on palindromem, a w przeciwnym wypadku `false`.
Palindrom to słowo, którego po usunięciu wszystkich znaków niebędących literami i cyframi, a także po zamianie wszystkich wielkich liter na małe, czyta się tak samo od lewej do prawej i od prawej do lewej.

**Przykład 1:**
Wejście: `s = "A man, a plan, a canal: Panama"`
Wyjście: `true`

**Przykład 2:**
Wejście: `s = "race a car"`
Wyjście: `false`

## Implementacja
W pliku `Solution.cs` zaimplementowano podejście z wykorzystaniem dwóch wskaźników (*Two Pointers*):
- **Złożoność czasowa:** $O(N)$, gdzie $N$ to długość ciągu znaków. Każdy znak sprawdzany jest co najwyżej raz.
- **Złożoność pamięciowa:** $O(1)$, ponieważ weryfikacja odbywa się w miejscu na oryginalnym ciągu znaków.
- **Opis algorytmu:** Użyto wskaźników na początek i koniec ciągu. Przesuwają się one ku środkowi, pomijając znaki interpunkcyjne oraz spacje przy pomocy metody `char.IsLetterOrDigit`. Wyselekcjonowane znaki są porównywane jako małe litery. W przypadku jakiejkolwiek rozbieżności program zwraca `false`.

## Testowanie
W pliku `Solution.cs` przygotowano metodę `Main` w celu weryfikacji poprawności algorytmu na podstawowych przypadkach testowych.

</div>
