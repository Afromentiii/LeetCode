<div style="text-align: justify;">

# Remove Element

## Opis problemu
**27. Remove Element** (Easy)

Mając daną tablicę liczb całkowitych `nums` oraz wartość całkowitą `val`, usuń wszystkie wystąpienia wartości `val` w tablicy `nums` w miejscu (in-place). Kolejność elementów może ulec zmianie. Następnie zwróć liczbę elementów w tablicy `nums`, które nie są równe `val`.

Zakładając, że liczba elementów w `nums` nierównych `val` wynosi `k`, aby rozwiązanie zostało zaakceptowane, musisz wykonać następujące czynności:
1. Zmienić tablicę `nums` tak, aby jej pierwsze `k` elementów zawierało wartości różne od `val`. Pozostałe elementy tablicy `nums` nie mają znaczenia.
2. Zwrócić wartość `k`.

**Przykład 1:**
Wejście: `nums = [3,2,2,3]`, `val = 3`
Wyjście: `2`, `nums = [2,2,_,_]`
Wyjaśnienie: Twoja funkcja powinna zwrócić k = 2, a dwa pierwsze elementy tablicy nums powinny wynosić 2. 

**Przykład 2:**
Wejście: `nums = [0,1,2,2,3,0,4,2]`, `val = 2`
Wyjście: `5`, `nums = [0,1,4,0,3,_,_,_]`
Wyjaśnienie: Twoja funkcja powinna zwrócić k = 5, a pierwsze pięć elementów tablicy nums to 0, 1, 3, 0, 4. Należy zauważyć, że zwrócone pięć elementów może pojawić się w dowolnej kolejności.

**Ograniczenia:**
- `0 <= nums.length <= 100`
- `0 <= nums[i] <= 50`
- `0 <= val <= 100`

## Zrealizowane cele
- Zaimplementowano algorytm usuwający wybrane elementy z tablicy w miejscu (ang. *in-place*), co spełnia rygorystyczne wymagania postawione w treści zadania (brak alokacji nowej tablicy).
- Osiągnięto optymalną złożoność czasową O(n), przemieszczając się po całej tablicy dokładnie jeden raz.
- Dopisano program testowy sprawdzający prawidłowość modyfikacji oryginalnej tablicy, obrazujący proces operacji na referencjach w języku C#.

## Uzasadnienie i metodologia realizacji
- Aby uniknąć przydzielania nowej tablicy (co złamałoby zasady zadania nakazujące złożoność przestrzenną O(1)), operacje zapisu i odczytu odbywają się bezpośrednio na wejściowej tablicy `nums`.
- Utrzymywany jest niezależny wskaźnik zapisu (`cursor`), początkowo ustawiony na 0.
- Algorytm w pętli sprawdza wszystkie elementy głównej tablicy jeden po drugim. Jeśli napotka wartość różną od zadanego `val`, wpisuje tę wartość pod indeks wskazywany przez `cursor`, po czym inkrementuje ten wskaźnik zapisu. 
- Z kolei, jeśli rozpatrywana wartość jest równa `val`, ignoruje ją (wywołując `continue`) i przechodzi do kolejnego indeksu.
- Dzięki takiemu podejściu poprawne wartości "nadpisują" lewą stronę tablicy. Wartość końcowa zmiennej `cursor` stanowi liczbę wstawionych, prawidłowych elementów i jest z powodzeniem zwracana jako wynik (zmienna `k` z treści zadania).

## Wady
- Ten konkretny algorytm kopiuje elementy na ich własne pozycje, jeśli na początku tablicy w ogóle nie znajdują się usuwane wartości `val` (np. przypisuje `nums[0] = nums[0]`). Choć w ogólnym rozrachunku złożoność to wciąż bardzo szybkie O(n), to przy założeniu, że rzadko spotykamy odrzucaną wartość w długiej tablicy, lepszym rozwiązaniem pod kątem optymalizacji I/O mogłoby być ewentualnie podmienianie usuwanych wartości z elementami z samego końca tablicy (zamiana miejscami – swapping). Obecna logika pozostaje jednak znacznie bardziej elegancka, czytelna i bezawaryjna.

</div>
