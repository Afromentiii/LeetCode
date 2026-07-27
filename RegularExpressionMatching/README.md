<div style="text-align: justify;">

# Regular Expression Matching

## Opis problemu
Mając dany ciąg wejściowy `s` oraz wzorzec `p`, zaimplementuj dopasowywanie wyrażeń regularnych z obsługą znaków `.` oraz `*`, gdzie:
- `.` dopasowuje dowolny pojedynczy znak.
- `*` dopasowuje zero lub więcej wystąpień elementu, który go poprzedza.

Dopasowanie musi obejmować cały ciąg wejściowy (a nie tylko jego fragment).

**Ograniczenia:**
- `1 <= s.length <= 20`
- `1 <= p.length <= 20`
- `s` składa się wyłącznie z małych liter języka angielskiego.
- `p` składa się z małych liter języka angielskiego, `.` oraz `*`.
- Gwarantuje się, że dla każdego wystąpienia znaku `*`, poprzedzać go będzie prawidłowy znak do dopasowania.

## Zrealizowane cele
- Opracowano rozwiązanie oparte na podejściu rekurencyjnym, pozwalające na ewaluację wyrażeń regularnych z wykorzystaniem znaków specjalnych (`.` oraz `*`).
- Utworzono niestandardowy skrypt wsadowy (`run_tests.bat`), który automatyzuje proces testowania na wysoce zróżnicowanym zestawie 30 przypadków brzegowych zdefiniowanych w pliku tekstowym `payload.txt`.

## Uzasadnienie i metodologia realizacji
- Obecność znaku gwiazdki (`*`) wymusza nieliniowe dopasowywanie wzorca. Z tego powodu **zastosowano architekturę rekurencyjną** (funkcja `MatchFrom`), ponieważ naturalnie odzwierciedla ona drzewiastą strukturę decyzji.
- Algorytm analizuje łańcuchy znaków, przesuwając dwa niezależne kursory. W przypadku detekcji asterysku, ścieżka wykonania jest rozwidlana na dwie opcje: zignorowanie poprzedzającego znaku (zero wystąpień) lub skonsumowanie bieżącego znaku wejściowego przy pozostawieniu kursora wzorca w nienaruszonej pozycji.
- Dzięki zdefiniowanemu mechanizmowi rozgałęzień, aplikacja symuluje głębokie przeszukiwanie z nawrotami (backtracking), weryfikując poprawność poszczególnych wariantów dopasowania.

## Porównanie wydajności
Analiza wydajnościowa ujawniła rozbieżności w zależności od skali i skomplikowania zestawu testowego:
- **Środowisko lokalne** (skrypt testujący na 30 wyselekcjonowanych przypadkach brzegowych): Czas algorytmiczny wynosi około **~5 ms**.
- **Platforma LeetCode** (oficjalne środowisko testowe): Czas wykonania wynosi około **~300 ms**. Oficjalne zestawy testowe na platformie są znacznie bardziej rozbudowane i powszechnie uwzględniają warianty pesymistyczne silnie potęgujące rozgałęzienia decyzyjne.

Powyższe wyniki wskazują, że o ile natywna rekurencja (bez spamiętywania) radzi sobie bardzo wydajnie z ograniczonymi zestawami testów, o tyle przy wysoce rozbudowanych i wymagających scenariuszach docelowych, wykładnicza natura algorytmu zaczyna jednoznacznie rzutować na całkowity czas przetwarzania.

## Wady
- Obecna implementacja opiera się wyłącznie na rekurencji bez spamiętywania, co skutkuje złożonością czasową rzędu wykładniczego O(2^(N+M)) w pesymistycznych scenariuszach (gdzie wzorzec generuje znaczną liczbę rozgałęzień).
- Algorytm redundantnie oblicza wyniki dla tych samych powtarzających się stanów (takich samych par układu kursorów). Aby zniwelować ten problem i uzyskać optymalną skalowalność, konieczne byłoby zastosowanie programowania dynamicznego (np. dwuwymiarowej tablicy `bool[,]` buforującej przeliczone już stany).

</div>
