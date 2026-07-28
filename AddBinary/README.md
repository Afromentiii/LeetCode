<div style="text-align: justify;">

# Add Binary

## Opis problemu
**Add Binary** (Dodawanie pisemne dwóch ciągów bitowych)

Mając dane dwa ciągi znaków `a` i `b` reprezentujące liczby w systemie binarnym, zwróć ich sumę (również jako ciąg znaków). Ze względu na to, że stringi te mogą posiadać bardzo dużą długość (np. do kilkuset tysięcy znaków), konwersja ich do tradycyjnych typów całkowitych, takich jak 64-bitowe `long`, zakończyłaby się przepełnieniem bitowym (Overflow). Problem ten musi być rozwiązany symulując ręczne, pisemne dodawanie.

**Przykład 1:**
Wejście: `a = "11", b = "1"`
Wyjście: `"100"`

**Przykład 2:**
Wejście: `a = "1010", b = "1011"`
Wyjście: `"10101"`

## Zrealizowane cele
- Opracowano dwa niezależne rozwiązania oparte o ciągi znaków: wersję instrukcyjną (operującą na wskaźnikach logicznych i instrukcjach if-else) oraz mocno zoptymalizowaną wersję numeryczną (`AddBinaryFaster`), bazującą na matematycznym przeliczaniu reszty z dzielenia.
- Zaprogramowano ominięcie ograniczeń 64-bitowych typów prostych, pozwalając na swobodne dodawanie gigantycznych ciągów rzędu 500+ znaków.
- Przygotowano zautomatyzowane ramy testowe i potężną paczkę `payload.txt` z 5000 przypadków, która skutecznie weryfikuje poprawne wyliczanie sumy kontrolnej oraz porównuje czasy operacji poszczególnych algorytmów (wersja _Faster_ wykonuje zadanie niemalże dwukrotnie szybciej).

## Wyniki testów wydajnościowych
Przeprowadzono dedykowane, autorskie testy wydajnościowe mające na celu empiryczne potwierdzenie skuteczności wprowadzonych optymalizacji matematycznych. W środowisku .NET, używając wbudowanego stopera (`System.Diagnostics.Stopwatch`), wczytano ogromną paczkę `payload.txt`, w której przygotowano **5000 losowych przypadków testowych** o abstrakcyjnie ogromnej długości (ciągi bitowe do 500 znaków).

Poniżej przedstawiono wyniki udowadniające zgodność obliczeń (identyczna ostateczna suma kontrolna wszystkich wyników) oraz ułamek czasu zajętego przez sprytniejszą matematykę z `AddBinaryFaster`:
```text
Wczytywanie zewnetrznej paczki testowej (payload.txt)...
Paczka wczytana. Rozpoczynam obliczenia...
Czas przeliczania AddBinaryOnlyStrings: ~61 ms (Suma: 2510362)
Czas przeliczania AddBinaryFaster:      ~32 ms (Suma: 2510362)
```

## Uzasadnienie i metodologia realizacji
Algorytm `AddBinaryFaster` opiera się na prostych regułach arytmetycznych przeniesionych do pętli znakowej:
1. **Wyrównywanie długości:** Obie wejściowe "liczby" są wstępnie dopełniane zerami z lewej strony za pomocą funkcji `PadLeft(maxLength, '0')`, zrównując je długością. Dzięki temu pętla staje się całkowicie prosta i symetryczna – nie musimy obsługiwać wypadania indeksów poza zakres.
2. **Pisemne dodawanie:** Pętla startuje od tyłu i w każdym cyklu odejmuje na chwile wartość rzutowania znaku na standard ASCII (`c - '0'`), aby pracować z czystymi cyframi 0 i 1.
3. **Matematyczne operacje bez ifów:** Zamiast skomplikowanego drzewa warunków użyto eleganckiej arytmetyki: aktualny bit wyniku otrzymywany jest z reszty z dzielenia sumy (w tym carry) przez 2 (`sum % 2`), a przeniesienie (carry) na następny znak wynika po prostu z pełnego dzielenia przez 2 (`sum / 2`). 
4. **Zwieńczenie sumy:** Jeśli po przejściu całej pętli na samej górze wciąż pozostaje przeniesienie (`carry > 0`), przed ostateczny wygenerowany w ten sposób string dopisywana jest po prostu wiodąca jedynka (np. 1 + 1 = 10).

## Wady
- Konieczność wywołania metody `PadLeft` obciąża maszynę powołaniem do pamięci dwóch całkowicie nowych, wydłużonych instancji klas `string`, co nie jest optymalnym rozwiązaniem dla pamięci rzędu `O(N)`. 
- Aby to maksymalnie zoptymalizować pod kątem zarządzania cyklem życia pamięci alokacji, najwydajniejszą opcją (chociaż mniej przejrzystą) byłoby zrezygnowanie z `PadLeft` i iterowanie równoległe bezpośrednio w tył wzdłuż oryginalnych referencji wejściowych dopóki jakikolwiek indeks `i` lub `j` pozostaje powyżej zera (traktując znak poza tablicą po prostu jako 0). 

</div>
