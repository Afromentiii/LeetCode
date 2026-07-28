<div style="text-align: justify;">

# Lexicographically Smallest Palindrome Permutation

## Opis problemu
**Lexicographically Smallest Palindrome** (Wariacja z rearanżacją / anagramami)

Mając dany ciąg znaków, zbuduj z jego liter najmniejszy możliwy leksykograficznie (alfabetycznie) palindrom. W przeciwieństwie do standardowego wariantu (w którym tylko nadpisuje się znaki z zewnątrz na zewnątrz), w tym podejściu wykorzystujesz całkowitą pulę liter ze słowa wejściowego i układasz je od nowa w optymalny palindrom.

**Przykład 1:**
Wejście: `s = "daccad"`
Wyjście: `"acddca"`

**Przykład 2:**
Wejście: `s = "racecar"`
Wyjście: `"acrerca"`

**Przykład 3:**
Wejście: `s = "madam"`
Wyjście: `"amdma"`

## Zrealizowane cele
- Zaimplementowano algorytm oparty na sortowaniu przez zliczanie (Counting Sort) dedykowany specjalnie do budowania strukturalnie poprawnego i najmniejszego alfabetycznie palindromu.
- Zapewniono rewelacyjną złożoność czasową rzędu `O(N)`, gdzie `N` to długość łańcucha znaków (dzięki jednokrotnemu iterowaniu przez wyraz w celu zliczenia wystąpień znaków alfabetu, zamiast kosztownego sortowania typu `O(N log N)`).
- Zaimplementowano pętlę testową (`Main`) udowadniającą optymalizację takich klasyków jak `racecar` czy `madam`.

## Uzasadnienie i metodologia realizacji
Całe rozwiązanie zostało zgrabnie oparte na czterech krokach zaproponowanych przez dewelopera:
1. **Zliczanie częstotliwości:** Program alokuje tablicę `counts` dla 26 liter alfabetu. Przechodząc tylko jeden raz przez słowo, notuje dokładną liczbę wystąpień każdego znaku (np. dla `"daccad"` zbierze informacje: dwa `a`, dwa `c`, dwa `d`).
2. **Wyznaczanie środka:** Algorytm w pętli szuka znaków o nieparzystej liczbie wystąpień (zaczynając od `a`, by utrzymać najmniejszy porządek leksykograficzny). Jeśli odnajdzie takowy, rezerwuje go do zmiennej `middle` (stanowiącej idealny środek dla palindromów o nieparzystej długości) i dekrementuje jego licznik by móc rozdzielić resztę po równo na boki.
3. **Budowanie pierwszej połowy:** Wykorzystując klasę `StringBuilder`, algorytm raz jeszcze idzie alfabetycznie przez podliczoną tablicę częstotliwości. Pobiera każdą dostępną literę i wrzuca do bufora dokładnie połowę jej puli (`counts[i] / 2`). Dzięki naturalnemu pętleniu od `a` do `z`, wygenerowany prefiks jest gwarantowanym najmniejszym możliwym ułożeniem.
4. **Składanie w całość:** Pierwsza połowa (`leftPart`) łączona jest ze środkiem (`middle`), po czym bezpośrednio do nich doklejane jest `Array.Reverse` (odbicie lustrzane pierwszej połowy). Ten zabieg scala palindrom w perfekcyjną, alfabetyczną formę.

## Wady
- Operacja `ToCharArray()` na pierwszej połówce, odwracanie jej przy pomocy `Array.Reverse` oraz budowanie nowych obieków typu `string` przy składaniu całości narzucają widoczny narzut czasowo-pamięciowy w języku C#. Złożoność pamięciowa to naturalne `O(N)`. Aby jeszcze bardziej zoptymalizować ten aspekt (np. pod systemy niskopoziomowe), wystarczyłoby alokować z góry jedną surową tablicę znaków `char[N]` i w tej samej pętli uzupełniać boki za pomocą dwóch zbiegających się z obu stron wskaźników, omijając jakiekolwiek rzutowanie i odwracanie stringów.
- Obecna implementacja skupia się stricte na prawidłowych danych (ciągach, z których rzeczywiście *da się* uformować palindrom). Gdyby dostarczono wyraz posiadający wiele różnych liter o nieparzystych wystąpieniach, program po prostu uratuje pierwszą alfabetyczną literę wrzucając ją w środek, a resztę samotnych liter pominie przy dzieleniu całkowitym przez dwa.

</div>
