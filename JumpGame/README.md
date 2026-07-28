<div style="text-align: justify;">

# Jump Game

## Opis problemu
**Jump Game** (Gra w Skoki)

Mając daną tablicę liczb całkowitych `nums`, wyobraź sobie, że zaczynasz od jej pierwszego indeksu. Każda liczba wskazuje, o ile **maksymalnie** kroków w przód możesz przeskoczyć w danej turze. Zadaniem jest sprawdzenie, czy istnieje prawidłowa seria skoków pozwalająca dotrzeć na sam koniec tablicy (lub poza nią).

**Przykład 1:**
Wejście: `nums = [2,3,1,1,4]`
Wyjście: `true`
Wyjaśnienie: Skok o 1 z indeksu 0 do 1, potem skok o 3 bezpośrednio do ostatniego indeksu.

**Przykład 2:**
Wejście: `nums = [3,2,1,0,4]`
Wyjście: `false`
Wyjaśnienie: Niezależnie od podjętej decyzji algorytm ostatecznie zatrzyma się na zerze, z którego nie wykona dalszego ruchu.

## Zrealizowane cele
- Zaimplementowano dwa podejścia rekursywne – standardową wersję przeszukującą w głąb (DFS) oraz wersję korzystającą z techniki zapamiętywania wyników (**Memoization** / Dynamic Programming).
- Użyto skryptów zewnętrznych do wygenerowania pliku `payload.txt`, który zawiera zestawy testowe symulujące błędy typu Time Limit Exceeded (TLE) na platformie LeetCode.
- Napisano ramy testowe w klasie `Main`, które porównują czas działania obu podejść oraz sprawdzają zgodność ich wyników na podstawie wbudowanej sumy kontrolnej.

## Wyniki testów wydajnościowych
Przeprowadzono testy wydajnościowe ilustrujące różnicę pomiędzy algorytmem o złożoności $O(2^N)$ a wersją zoptymalizowaną. Użyto w tym celu 5010 wygenerowanych przypadków testowych, obejmujących tablice o małej długości, tablice zawierające dużą liczbę zer oraz przypadki brzegowe przygotowane specjalnie z myślą o spowolnieniu działania czystego DFS.

Poniżej zamieszczono logi z pomiarem czasu wykonania. Algorytm w wersji bez memoizacji potrzebował blisko 20 sekund, podczas gdy wersja korzystająca z tablicy stanów zakończyła pracę w 1 ms:

```text
Wczytywanie zewnetrznej paczki testowej (payload.txt)...
Paczka wczytana (5010 tablic - w tym ogromne wartosci i skrajne przypadki!). Rozpoczynam obliczenia...
Czas BEZ memo: 18063 ms
Czas Z MEMO (zapamietywanie drog): 1 ms
Wyniki -> True: 4685, False: 325
SUMA KONTROLNA: ZGODNA (Obydwa algorytmy daja identyczne wyniki we wszystkich przypadkach)
```

## Uzasadnienie i metodologia realizacji
1. **DFS (Przeszukiwanie w głąb):** Podejście zastosowane w algorytmie `branchTravesal` polega na badaniu wszystkich możliwych dróg od najdłuższego dopuszczalnego skoku. Jest nieefektywne pod względem czasowym ze względu na konieczność ponownego analizowania tych samych elementów tablicy.
2. **Tablica Memoization:** Zmodyfikowana wersja stosuje lokalną tablicę `bool?[] memo`, która przechowuje status przetworzonych już indeksów. 
3. **Pamięć predykcyjna:** Każde wywołanie funkcji sprawdza, czy dany węzeł był już obliczany. Jeśli tak, program zwraca gotowy wynik z pamięci podręcznej i omija wywoływanie pętli, co skutkuje wyraźną redukcją złożoności czasowej.

## Wady
- Metoda korzystająca z Memoization wymaga alokacji dodatkowej pamięci. Rozmiar tablicy pomocniczej jest uzależniony od wielkości tablicy wejściowej, co skutkuje złożonością pamięciową $O(N)$.
- Oba rozwiązania korzystają z rekurencji. Przy bardzo długich tablicach wejściowych istnieje ryzyko przepełnienia stosu programu (`StackOverflowException`).
- Powyższe braki w zakresie pamięci i stosu wywołań są nieobecne w algorytmie zachłannym (Greedy), który opiera się na iteracji liniowej, rozwiązując zadanie z wykorzystaniem stałej ilości pamięci $O(1)$.

</div>
