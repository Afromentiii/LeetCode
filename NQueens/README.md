# N-Queens Solution (C#)

Ten projekt zawiera rozwiązanie klasycznego problemu N-Hetmanów (N-Queens) zaimplementowane w języku C# (algorytm z nawrotami / backtracking).

Celem algorytmu jest rozmieszczenie `N` hetmanów na szachownicy o wymiarach `N x N` w taki sposób, aby żadne dwa hetmany się nie atakowały (czyli nie dzieliły tego samego wiersza, kolumny ani przekątnej).

## Funkcje algorytmu

*   **Podejście z nawrotami (Backtracking):** Algorytm próbuje umieszczać hetmany wiersz po wierszu (od góry do dołu). 
*   **Zoptymalizowane sprawdzanie bezpieczeństwa:** Ponieważ hetmany są umieszczane w każdym nowym wierszu sukcesywnie, algorytm musi sprawdzać jedynie kolizje z już postawionymi hetmanami:
    *   Pionowo w górę.
    *   Po przekątnej w lewo w górę.
    *   Po przekątnej w prawo w górę.
*   **Formatowanie zgodne z LeetCode:** Po znalezieniu prawidłowego ułożenia, szachownica jest konwertowana do formatu obsługiwanego przez LeetCode, tj. listy stringów, gdzie `'Q'` oznacza hetmana, a `'.'` oznacza puste pole.

## Wymagania

*   .NET 8.0 SDK (lub nowszy)

## Jak uruchomić

Aby uruchomić kod testowy zawarty w projekcie (z wykorzystaniem domyślnego przypadku `N = 4`), wykonaj poniższe polecenie w terminalu, wewnątrz katalogu `NQueens`:

```powershell
dotnet run
```

### Przykładowy wynik dla N = 4:

```json
[[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
```
