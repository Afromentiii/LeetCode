## Zadanie
**7. Reverse Integer** (Medium)

Given a signed 32-bit integer `x`, return `x` with its digits reversed. If reversing `x` causes the value to go outside the signed 32-bit integer range `[-2^31, 2^31 - 1]`, then return `0`.

**Assume the environment does not allow you to store 64-bit integers (signed or unsigned).**

**Example 1:**
Input: `x = 123`
Output: `321`

**Example 2:**
Input: `x = -123`
Output: `-321`

**Example 3:**
Input: `x = 120`
Output: `21`

**Constraints:**
`-2^31 <= x <= 2^31 - 1`

## Zrealizowane cele
- Opracowano dwa rozwiązania, z których ostatecznie w pełni wyeliminowano zakazany w treści typ 64-bitowy (`long`).
- Oba rozwiązania przechodzą testy na brzegową wartość `int.MinValue` (-2147483648).
- Utworzono niestandardowy skrypt wsadowy (`run_tests.bat`), który automatyzuje proces kompilacji za pomocą natywnego kompilatora `csc.exe` oraz precyzyjnie mierzy łączny czas przetwarzania statycznego zestawu danych testowych (payload). Zestaw ten obejmuje 10 000 predefiniowanych przypadków z pełnego zakresu 32-bit, co zapewnia wysoce deterministyczne i powtarzalne środowisko pomiarowe.

## Uzasadnienie i metodologia realizacji
- Treść zadania zabraniała przechowywania 64-bitowych liczb, w związku z czym wyjściowe zastosowanie typu `long` było niezgodne ze specyfikacją. 
- W celu obsługi wartości absolutnej dla `int.MinValue`, która przekracza zakres tradycyjnego 32-bitowego typu ze znakiem, **zastosowano typ `uint`** (unsigned 32-bit). Typ ten obsługuje wartości do ponad 4 miliardów, co w pełni zaspokaja wymogi algorytmu.
- W pierwszym podejściu (`Solution.cs`) wykorzystano dwie 32-bitowe zmienne (`bcdLow`, `bcdHigh`), aby za pomocą przesunięć bitowych (kodowanie BCD - 4 bity na cyfrę) skomponować odwróconą liczbę, unikając tym samym stosowania typu 64-bitowego.
- W drugim, alternatywnym podejściu (`SolutionWithString.cs`), wyodrębnione za pomocą operacji modulo cyfry (jako `uint`) agregowano w strukturze listowej, a następnie łączono w ciąg znaków (`string`). Ostateczną weryfikację ewentualnego przekroczenia zakresu 32-bitowego powierzono wbudowanej metodzie `.TryParse()` (w przypadku przekroczenia zakresu metoda zwraca wartość fałszywą, co skutkuje zwróceniem `0`).

## Porównanie wydajności
Analiza wydajnościowa ujawniła istotne rozbieżności w zależności od wykorzystywanego środowiska uruchomieniowego:

**1. Środowisko lokalne (skrypt testujący, 10 000 operacji):**
- **Solution.exe** (podejście bitowe): Czas algorytmiczny wynosi około **~12,6 ms**.
- **SolutionWithString.exe** (podejście oparte na listach i ciągach znaków): Czas algorytmiczny wynosi około **~18,7 ms**.
W badaniu lokalnym wykazano, że eliminacja dynamicznej alokacji obiektów (takich jak `string`) znacząco zwiększa wydajność obliczeniową przy dużej skali operacji, co wynika z odciążenia mechanizmu odśmiecania (Garbage Collector).

**2. Środowisko platformy LeetCode (nowoczesny runtime .NET):**
- **Solution** (podejście bitowe): Czas wykonania wyniósł **16 ms**.
- **SolutionWithString** (podejście oparte na listach i ciągach znaków): Najlepszy zarejestrowany czas wykonania wyniósł **11 ms**. Należy jednak odnotować istotną wariancję pomiarową platformy docelowej – kolejne uruchomienia identycznego kodu generowały wyniki na poziomie **24 ms**, co jednoznacznie wskazuje na fluktuacje obciążenia serwerów testujących.

Powyższe wyniki wskazują na silną zależność wydajności od docelowej platformy oraz jej infrastruktury. Chociaż lokalne testy masowe faworyzują podejście niskopoziomowe (bitowe), platforma LeetCode w najbardziej optymalnych warunkach wykazuje wyższą wydajność dla implementacji opartej na typach złożonych (11 ms). Różnica ta może wynikać z zaawansowanych optymalizacji nowszych wersji środowiska .NET Core/.NET, ukierunkowanych na manipulację ciągami znaków, a także z mniejszej puli przypadków testowych. Obserwowane zjawisko, w połączeniu ze znaczną niestabilnością pomiarów samej platformy w chmurze (wahania rzędu 11–24 ms dla tego samego kodu), jednoznacznie podkreśla trudność w precyzyjnym i obiektywnym profilowaniu mikro-optymalizacji algorytmicznych.

## Wady
- Rozwiązanie wykorzystujące konwersję na typ `string` wymusza liczne, krótkotrwałe alokacje pamięci na stercie (heap), co stanowi istotne obciążenie dla mechanizmu odśmiecania (Garbage Collector) w środowisku .NET.
- Oba warianty nie spełniają wymogu złożoności pamięciowej O(1). Najbardziej rygorystyczne i optymalne rozwiązania opierają się na czysto matematycznym odwracaniu liczby (np. operacje postaci `res = res * 10 + pop`) z wczesną detekcją przepełnienia, co eliminuje konieczność alokowania dodatkowych struktur.
- Użycie wbudowanej metody `int.TryParse` deleguje operację sprawdzania zakresu do mechanizmów języka, co ukrywa logikę obsługi błędu przepełnienia i nie pozwala na pełną, bezpośrednią kontrolę nad tym procesem w kodzie algorytmu.