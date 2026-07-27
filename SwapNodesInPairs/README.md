<div style="text-align: justify;">

# Swap Nodes in Pairs

## Opis problemu
**24. Swap Nodes in Pairs** (Medium)

Mając daną listę jednokierunkową, zamień miejscami każde dwa sąsiadujące ze sobą węzły (nodes) i zwróć jej nowy początek. 
Musisz rozwiązać to zadanie przepinając same węzły – **nie wolno** Ci po prostu podmienić wartości (ang. *values*) wewnątrz węzłów.

**Przykład 1:**
Wejście: `head = [1,2,3,4]`
Wyjście: `[2,1,4,3]`

**Przykład 2:**
Wejście: `head = []`
Wyjście: `[]`

**Przykład 3:**
Wejście: `head = [1]`
Wyjście: `[1]`

**Ograniczenia:**
- Liczba węzłów w liście mieści się w przedziale `[0, 100]`.
- `0 <= Node.val <= 100`

## Zrealizowane cele
- Zaimplementowano prawidłowe, w pełni iteracyjne rozwiązanie problemu pracujące wyłącznie na operacjach przepinania wskaźników.
- Złożoność czasowa to idealne O(n), co jest wielkością optymalną i bezwzględnie wymaganą, ponieważ musimy w najgorszym scenariuszu przejść przez każdy węzeł raz.
- Złożoność pamięciowa to O(1). Alokowany jest tylko jeden i wyłącznie jeden dodatkowy węzeł – *Atrapa (Dummy Node)* na stosie pamięciowym na początku listy. Zrezygnowano z podejścia rekurencyjnego.
- Zbudowano niestandardową infrastrukturę testową, która wczytuje z pliku tekstowego `payload.txt` gigantyczną paczkę 100 unikalnych testów wygenerowaną z zewnątrz.
- Wbudowano zegar w postaci obiektu `Stopwatch`, który sumuje precyzyjny **wspólny czas wykonania** (z pominięciem opóźnień I/O) czystego algorytmu wymiany dla pełnego zestawu payloadu. Wynik jest z sukcesem raportowany na ekranie z dokładnością rzędu czterech miejsc po przecinku (w praktyce osiągając ekstremalną szybkość ~0.16 ms dla całej paczki).

## Uzasadnienie i metodologia realizacji
- Rozwiązanie wykorzystuje powszechną koncepcję **atrapy (Dummy Node)**, tworząc jeden sztuczny węzeł podpięty na sam początek oryginalnej listy (`ListNode dummy = new ListNode(0, head)`). Pozwala to na mocne ujednolicenie zachowania logiki i eliminuje irytującą potrzebę stosowania specjalnych instrukcji warunkowych (`if`) do obsługi wymiany samej pierwszej pary węzłów (co przecież zawsze rzutuje na całkowitą zmianę "głowy").
- W pętli `while` kursor stale operuje z pozycji węzła znajdującego się *tuż przed* parą przeznaczoną do zamiany. Wynika z tego warunek istnienia elementów zabezpieczający wyjście poza zakres: `cursor.next != null && cursor.next.next != null`.
- Cała zamiana (swap) odbywa się w trzech bezpiecznych, standardowych krokach opierających się na: wyciągnięciu elementów A oraz B, zerwaniu starych wiązań wskaźnika `.next` i włożeniu nowej relacji tak, aby węzeł przed parami spiął się bezpośrednio z B, a następnie przepchnął starą A jako prawy ogon B.
- W pliku `Solution.cs` oddzielono całkowicie sekcję parsowania tablic ze stringów od sekcji samego działania testowanego rozwiązania, zapewniając sterylność i najwyższą miarodajność wykonywanych pomiarów wydajności czasowej.

## Wady
- Alternatywnym sposobem rozwiązania tego zadania, często uchodzącym za dużo "czystsze" i bardziej zwięzłe w zapisie (tzw. clean code), jest zastosowanie rekurencji. Niestety, w warunkach produkcyjnych głęboka pętla rekurencyjna zaalokowałaby na stosie wywołań środowiska `CLR` dodatkową pamięć czasową rzędu O(n), co przy olbrzymich listach groziłoby awarią `StackOverflowException`. Właśnie z tego powodu wybrana, w 100% iteracyjna implementacja z dummy node – pomimo że dłuższa w lekturze – cechuje się o wiele większą solidnością.

</div>
