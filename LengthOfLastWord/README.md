<div style="text-align: justify;">

# Length of Last Word

## Opis problemu
**Length of Last Word** (Długość ostatniego słowa)

Mając dany ciąg znaków `s` składający się z wyrazów oraz spacji, zadanie polega na zwróceniu długości ostatniego słowa w tym łańcuchu. Wyraz jest zdefiniowany jako maksymalny podciąg (substring) składający się wyłącznie z liter (bez spacji). Należy wziąć pod uwagę, że ciąg może zawierać wiele spacji na początku, w środku między słowami, a także stanowić klasyczną pułapkę w postaci spacji na samym końcu (tzw. trailing spaces).

**Przykład 1:**
Wejście: `s = "Hello World"`
Wyjście: `5`

**Przykład 2:**
Wejście: `s = "   fly me   to   the moon  "`
Wyjście: `4`
*(Ostatnim słowem jest "moon" o długości 4, a spacje po nim są ignorowane).*

**Przykład 3:**
Wejście: `s = "luffy is still joyboy"`
Wyjście: `6`

## Zrealizowane cele
- Zaprojektowano i zaimplementowano algorytm o złożoności czasowej `O(N)` oraz złożoności pamięciowej stałej rzędu `O(1)`.
- Zrezygnowano ze stosowania wbudowanych (i bardzo wygodnych) operacji języka C#, takich jak `s.Trim().Split(' ')`. Tego typu wbudowane akcje rzutują fatalnie na zużycie pamięci, wymuszając powoływanie wielu nowych, zbędnych obiektów `string` oraz tablic. Nasze rozwiązanie opiera się o bezpośrednie przeliczanie indeksów "w locie".
- Przygotowano program z metodą testującą `Main`, która weryfikuje różne przypadki brzegowe uderzające w ukryte spacyjne pułapki postawione przez LeetCode. Oprócz tego na etapie developmentu wsparto się punktowym systemem logowania i debugowania.

## Uzasadnienie i metodologia realizacji
Nasz kod operuje poprzez prosty, elegancki mechanizm licznika z wykorzystaniem flagi pomocniczej:
1. **Flaga nowej epoki słownej:** Utworzona jest flaga `isSpaceLast` oraz licznik liter `lenCounter`. System liniowo czyta podany mu tekst znak po znaku (od lewej strony do prawej za pomocą pętli `foreach`).
2. **Ignorowanie i oznaczanie spacji:** Jeżeli pętla trafi na znak pusty (`' '`), flaga `isSpaceLast` aktywuje się (zmienia na `true`), a iteracja pętli jest przeskakiwana komendą `continue`. Zauważ, że w tym miejscu **nie resetujemy licznika**. Trzyma on bezpiecznie długość dawnego słowa, dopóki nie upewnimy się, że zaczyna się po nim kompletnie nowy wyraz. Dzięki temu spacje na końcu łańcucha nie wyzerują nam poprawnego, ostatecznego wyniku.
3. **Mierzenie nowego wyrazu:** Jeśli pętla trafia w końcu na regularną literę, pyta flagę `isSpaceLast` o zdanie. Jeżeli wynosi ona `true` – oznacza to, że właśnie rozpoczęliśmy całkowicie nowe słowo. Dopiero w tym ułamku sekundy dotychczasowy `lenCounter` zostaje wyzerowany, ponieważ stare słowo na pewno nie było tym ostatnim.
4. Następnie licznik jest naturalnie inkrementowany a flaga opuszczana. Po przebrnięciu w ten sposób przez cały tekst `lenCounter` wynosi na sztywno długość faktycznie ostatniego zbadanego zbioru liter.

## Wady
- Metodologia czytania od lewej do prawej strony wymusza przeiterowanie przez cały podany łańcuch `s` (pesymistyczna oraz optymistyczna złożoność czasowa wynosi zawsze równo `O(N)`). Biorąc pod uwagę charakter zadania (szukamy długości wyrazu z samego końca łańcucha) najszybszym środowiskowo rozwiązaniem byłoby zastosowanie tradycyjnej pętli `for (int i = s.Length - 1; ...)` iterującej **od końca do początku**. Pozwoliłoby to na błyskawiczne wyłapanie pierwszej litery od końca, zliczenie słowa i po uderzeniu w pierwszą napotkaną tuż po nim spację - zrobienie twardego "early exita" (`return lenCounter`). Prędkość rozwiązania drastycznie wzrosłaby dla długich poematów z odpowiedziami ukrytymi na samym końcu.

</div>
