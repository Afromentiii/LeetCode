# To Lower Case

Rozwiązanie zamieniające wszystkie wielkie litery w podanym łańcuchu znaków na małe litery.

## Opis

Wykorzystano pętlę iteracyjną przechodzącą przez każdy znak (`char& c`) w zadanym tekście. 
Dla każdej litery następuje sprawdzenie, czy znajduje się ona w przedziale dużych liter według kodowania ASCII (od `'A'` do `'Z'`).
Jeżeli znak spełnia ten warunek, zmieniany jest na odpowiednik małej litery poprzez wykonanie operacji `c = c - ('A' - 'a')`.

Złożoność czasowa tego rozwiązania to O(N), gdzie N to długość łańcucha znaków. Modyfikacje dokonywane są w miejscu (ang. *in-place*) na przekazanej kopii stringa.

## Uruchomienie

Kompilacja i uruchomienie programu testowego z poziomu terminala:

```bash
g++ Solution.cpp -o Solution.exe
.\Solution.exe
```
