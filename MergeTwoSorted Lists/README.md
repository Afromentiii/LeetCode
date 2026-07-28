<div style="text-align: justify;">

# Merge Two Sorted Lists

## Opis problemu
Mając dane początkowe węzły (heads) dwóch posortowanych list jednokierunkowych `list1` i `list2`, połącz je w jedną posortowaną listę. Nowa lista powinna zostać utworzona poprzez splecenie ze sobą węzłów obu początkowych list.

Zwróć węzeł początkowy połączonej listy.

**Przykład 1:**
Wejście: `list1 = [1,2,4]`, `list2 = [1,3,4]`
Wyjście: `[1,1,2,3,4,4]`

**Przykład 2:**
Wejście: `list1 = []`, `list2 = []`
Wyjście: `[]`

**Przykład 3:**
Wejście: `list1 = []`, `list2 = [0]`
Wyjście: `[0]`

**Ograniczenia:**
- Liczba węzłów w obu listach mieści się w przedziale `[0, 50]`.
- `-100 <= Node.val <= 100`
- Zarówno `list1`, jak i `list2` są posortowane w porządku niemalejącym.

## Zrealizowane cele
- Zaimplementowano poprawne, optymalne rozwiązanie problemu scalania dwóch posortowanych list jednokierunkowych, opierające się na przepinaniu istniejących węzłów (in-place).
- Osiągnięto optymalną złożoność czasową O(n + m), gdzie `n` i `m` to długości przetwarzanych list.
- Stworzono przejrzyste środowisko testowe w języku C# (w klasie `Program` z metodą `Main`), pozwalające na łatwą weryfikację prawidłowości wszystkich przypadków brzegowych (w tym list pustych i o różnej długości).

## Uzasadnienie i metodologia realizacji
- Aby uniknąć trudności ze wskaźnikiem początkowym tworzonej listy, użyto pomocniczego węzła "atrapy" (`ListNode head = new ListNode(0);`). Następnie wszystkie wybrane, mniejsze elementy są przypinane do końca tego łańcucha reprezentowanego przez węzeł pomocniczy `current`. Wynik to po prostu `head.next`.
- Trzon logiki stanowi pętla `while (list1 != null && list2 != null)`. Za każdym jej obrotem algorytm sprawdza, która z wartości na frontach obu list jest mniejsza. Następuje dołączenie właściwego węzła, a odpowiedni wskaźnik bazowy (`list1` lub `list2`) przesuwa się dalej.
- Ponieważ wejściowe listy są już wewnętrznie posortowane, w momencie gdy pętla zostanie przerwana z powodu wyczerpania jednej z list (dojście do wartości `null`), cała pozostała reszta drugiej listy nie musi być w ogóle przetwarzana iteracyjnie. Wystarczy dołączyć ją do ogona używając jednej instrukcji przypisania: `current.next = (list1 != null) ? list1 : list2;`.

## Wady
- Samo w sobie algorytmiczne scalanie w tej implementacji praktycznie nie posiada słabych stron w kontekście typowych wyzwań LeetCode – działa w czasie liniowym i pochłania stałą pamięć pomocniczą O(1).
- Rozwiązanie rekurencyjne (które również jest powszechne) zapewniłoby jeszcze czystszy kod bez atrapy (`dummy node`), ale obciążyłoby stos wywołań (Call Stack) złożonością pamięciową rzędu O(n + m), co mogłoby być problematyczne przy bardzo długich listach w środowiskach produkcyjnych. Zaproponowane rozwiązanie iteracyjne jest wolne od tej wady.

</div>
