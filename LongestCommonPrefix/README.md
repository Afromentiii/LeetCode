<div style="text-align: justify;">

# Longest Common Prefix

## Opis problemu
Napisz funkcję, która znajduje najdłuższy wspólny prefiks w tablicy ciągów znaków. Jeśli nie istnieje żaden wspólny prefiks, funkcja powinna zwrócić pusty ciąg `""`.

**Ograniczenia:**
- `1 <= strs.length <= 200`
- `0 <= strs[i].length <= 200`
- `strs[i]` składa się wyłącznie z małych liter języka angielskiego (jeśli nie jest pusty).

## Zrealizowane cele
- Opracowano rozwiązanie znajdujące najdłuższy wspólny prefiks w tablicy ciągów znaków.
- Zbudowano proste środowisko testowe oparte na wbudowanej klasie `Program` i metodzie `Main`, umożliwiające szybką walidację logiki za pomocą przygotowanych, hardkodowanych danych.

## Uzasadnienie i metodologia realizacji
- Zastosowano architekturę opartą na **pionowym skanowaniu (Vertical Scanning)**. Zamiast porównywać całe łańcuchy znaków ze sobą po kolei, algorytm iteruje przez kolejne indeksy znaków (kolumny), sprawdzając je jednocześnie we wszystkich wyrazach.
- Algorytm najpierw obsługuje przypadek brzegowy pustej tablicy wejściowej, a następnie (za pomocą LINQ) optymalizuje maksymalną głębokość skanowania poprzez wyznaczenie długości najkrótszego słowa (minimalizując ryzyko błędu *Index Out of Range*).
- Zewnętrzna pętla przechodzi przez indeksy najkrótszego słowa, a wewnętrzna sprawdza dany znak we wszystkich pozostałych łańcuchach. Natrafienie na pierwszą literę, która nie zgadza się ze wzorcem, skutkuje natychmiastowym przerwaniem operacji i zwróceniem dotychczas zweryfikowanego podciągu (używając metody `Substring`).

## Złożoność i wydajność
- **Złożoność czasowa**: Wynosi maksymalnie **O(S)**, gdzie S to łączna liczba znaków we wszystkich słowach (lub ściślej: czas działania jest proporcjonalny do *N * M*, gdzie N to liczba ciągów, a M to długość najdłuższego wspólnego prefiksu). Algorytm jest bardzo zoptymalizowany dla scenariuszy, w których rozbieżność występuje wcześnie, co natychmiast ucina dalsze poszukiwania.
- **Złożoność pamięciowa**: Zapewniono złożoność rzędu **O(1)**. Algorytm operuje wyłącznie na wskaźnikach indeksowych i nie rezerwuje dodatkowych, rosnących struktur w pamięci na poczet przetrzymywania tymczasowych wyników, a jedyna nowa alokacja dotyczy zwróconego prefiksu.