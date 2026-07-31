<div style="text-align: justify;">

# Minimum Common Value

## Opis problemu
**Minimum Common Value** (Minimalna wspólna wartość)

Mając dane dwie tablice liczb całkowitych `nums1` oraz `nums2`, z których obie posortowane są w kolejności niemalejącej, zwróć najmniejszą liczbę całkowitą, która występuje w obydwu tych tablicach. Jeśli nie istnieje żadna wspólna liczba, program musi zwrócić wartość `-1`. 

Z uwagi na bardzo ostre limity czasowe i zasobowe wyznaczane przez platformę LeetCode (gdzie każda z tablic może posiadać do 100 000 elementów o gigantycznych wartościach), brutalne sprawdzanie każdej wartości w podwójnej pętli niechybnie kończy się wstrzymaniem procesu i komunikatem "Time Limit Exceeded".

**Przykład 1:**
Wejście: `nums1 = [1,2,3], nums2 = [2,4]`
Wyjście: `2`
*(Najmniejszą wspólną liczbą w obu tablicach jest 2).*

**Przykład 2:**
Wejście: `nums1 = [1,2,3,6], nums2 = [2,3,4,5]`
Wyjście: `2`

## Zrealizowane cele
- Opracowano dwa niezależne rozwiązania problemu: naiwną wersję `GetCommonNaive` z podwójną pętlą rzędu `O(N*M)` oraz wysokowydajną, opartą o system wskaźnikowy metodę `GetCommon`, która realizuje zadanie liniowo w locie (`O(N+M)`).
- Wygenerowano zautomatyzowane ramy testowe i bardzo specyficzną paczkę `payload.txt`, bazującą na ekstremalnych limitach platformy. Wymusza ona przerabianie dziesiątek tysięcy elementów z przypadkami skrajnymi (np. wspólny element dopiero na miliardowej wartości pod sam koniec tablicy, brak wspólnych cyfr, gigantyczna różnica rozmiarów obu zestawów).
- Uruchomiono i skompilowano w pełni niezależny, autorski benchmark oparty o wbudowaną klasę `Stopwatch`, który potwierdza bezbłędność ostatecznej optymalizacji (na podstawie tzw. zderzenia sumy kontrolnej) i ukazuje różnice wydajności.

## Wyniki testów wydajnościowych
Przeprowadzono testy wydajnościowe uderzające we wczytaną z pliku zewnętrznego paczkę `payload.txt`. Zawierała ona 10 zróżnicowanych, masywnych scenariuszy uderzających m.in. w najbardziej pechowe iteracje (worst-case scenario), gdzie tablice liczyły po `20 000` elementów. W środowisku C# nałożenie zoptymalizowanego algorytmu drastycznie zminimalizowało zatory.

Poniżej przedstawiono zrzut logu ukazanego w konsoli (czasy zależą ściśle od wykorzystywanego w danej sekundzie CPU, lecz wykazują druzgocącą przepaść rzędu 2500x większej szybkości):
```text
Wczytano 10 testów z 'payload.txt'. Uruchamianie...
Suma kontrolna (testy przeszły): 10 / 10
Czas zoptymalizowanego algorytmu: 2 ms
Czas naiwnego algorytmu (brute-force): 5099 ms
Całkowity czas trwania testu: 5102 ms
```

## Uzasadnienie i metodologia realizacji
Algorytm zoptymalizowany `GetCommon` opiera się na technice dwóch wskaźników (kursory):
1. **Inicjalizacja i równoległy marsz:** Powołane zostają dwie liczbowe zmienne `cursor1` i `cursor2` reprezentujące fizyczne pozycje, startujące od skrajnej lewej strony w obydwu tablicach (indeks 0).
2. **Bezpiecznik wychodzenia poza zakres:** Zastosowana pętla `while` jest uzbrojona w połączony, podwójny warunek: kręci się tak długo, póki jakikolwiek kursor nie "wypadnie" całkowicie ze swej tablicy. Skoro iterujemy od najmniejszej do największej liczby – dotarcie do końca chociaż jednej z tablic oznacza bezpowrotny brak szans na odnalezienie pary.
3. **Logika przepychania kursorów:** Serce kodu to ekstremalnie tania operacja warunkowa (bez użycia dodatkowej pamięci typu HashSet). 
   - Jeżeli liczby nam się pokrywają: od razu wychodzimy ze strzałem w dziesiątkę, natychmiast kończąc funkcję – ze względu na sortowanie, pierwsza trafiona para jest z góry najmniejszą możliwą.
   - W przeciwnym razie inkrementowany (`++`) jest zawsze kursor w tej tablicy, w której wykryto **mniejszą** aktualną wartość (skoro goni większą liczbę ze sparowanej tablicy po drugiej stronie, to z powodu sortowania niemalejącego wystarczy po prostu pchnąć go w prawo o jedno pole, by zbadać kolejną, ciut wyższą opcję).

## Wady
- Metodologia dwóch wskaźników posiada jedną gigantyczną wadę architektoniczną - jest **całkowicie i bezwzględnie zależna od wcześniejszego posortowania danych.** Algorytm pęka, gdyby tablice podane na wejściu zawierały liczby niepoukładane rozmiarem. Choć na platformie LeetCode stanowią one już dane wyjściowe z polecenia, w warunkach komercyjnych rozwiązanie wymagałoby zabezpieczenia w postaci `Array.Sort()`, drastycznie zmieniając całkowitą złożoność logiczną do rzędu `O(N log N)`, lub ucieczki do pamięciowo bolesnego tworzenia od podstaw w pamięci tablic Hashowania.

</div>
