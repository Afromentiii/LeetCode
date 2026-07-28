<div style="text-align: justify;">

# Search Insert Position

## Opis problemu
**35. Search Insert Position** (Easy)

Mając posortowaną tablicę unikalnych liczb całkowitych oraz wartość docelową (`target`), zwróć indeks, pod którym podana wartość została znaleziona. Jeśli jej nie ma, zwróć indeks, pod którym powinna zostać wstawiona, aby tablica pozostała posortowana rosnąco.

Musisz napisać algorytm o złożoności czasowej `O(log n)`.

**Przykład 1:**
Wejście: `nums = [1,3,5,6]`, `target = 5`
Wyjście: `2`

**Przykład 2:**
Wejście: `nums = [1,3,5,6]`, `target = 2`
Wyjście: `1`

**Przykład 3:**
Wejście: `nums = [1,3,5,6]`, `target = 7`
Wyjście: `4`

**Ograniczenia:**
- `1 <= nums.length <= 10^4`
- `-10^4 <= nums[i] <= 10^4`
- `nums` zawiera unikalne wartości posortowane rosnąco.
- `-10^4 <= target <= 10^4`

## Zrealizowane cele
- Zaimplementowano klasyczne wyszukiwanie połówkowe (Binary Search) pozwalające zlokalizować pozycję w wielkich tablicach przy zachowaniu optymalnego czasu.
- Osiągnięto wymagany wymóg dotyczący złożoności czasowej, czyli O(log n), co krok odrzucając połowę niesprawdzonej dotąd tablicy.
- Złożoność pamięciowa zachowana na poziomie O(1), ponieważ algorytm używa tylko 3 prymitywnych zmiennych całkowitoliczbowych (`left`, `right`, `mid`), operując w całości w miejscu.
- Klasa `Program` dostarcza proste środowisko testowe weryfikujące obsługę typowych operacji wstawiania na zewnątrz i do wewnątrz.

## Uzasadnienie i metodologia realizacji
- Użyto dwóch wskaźników klamrujących aktywny zakres poszukiwań: `left` (odpowiadający za lewy brzeg) oraz `right` (odpowiadający za prawy). Początkowo obejmują one całą wejściową tablicę.
- Pętla `while (left <= right)` w każdej swojej iteracji wylicza środek obszaru `mid`. Aby zapobiec rzadkiemu, ale destrukcyjnemu wyjątkowi przepełnienia wartości granicznych typu `int` dla bardzo wielkich tablic (tzw. integer overflow), w rozwiązaniu zastosowano bezpieczne równanie `left + (right - left) / 2`.
- Po odnalezieniu wartości pod indeksem `mid`, program po prostu go zwraca. Gdy wartość jest nieodpowiednia, algorytm albo zaostrza lewą klamrę (`left = mid + 1`), albo prawą klamrę (`right = mid - 1`), w jednym kroku weryfikując i odrzucając 50% pozostałych kandydatów.
- Bardzo ważną i unikalną cechą tego wariantu operacji wyszukiwania jest fakt, że jeżeli poszukiwana liczba w ogóle nie znajduje się w tablicy (czyli pętla ostatecznie się wyczerpie przerywając warunek), wskaźnik `left` dokładnie wskaże na najmniejszy z możliwych docelowych indeksów wstawienia w celu zachowania ciągłości sortowania.
</div>
