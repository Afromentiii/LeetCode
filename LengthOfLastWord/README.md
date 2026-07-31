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
- Zaprojektowano i zaimplementowano dwa algorytmy o złożoności czasowej `O(N)` oraz złożoności pamięciowej `O(1)`. Pierwszy (naiwny) czyta tekst od lewej do prawej, a drugi (zoptymalizowany) robi to od prawej do lewej z wykorzystaniem mechanizmu wczesnego wyjścia (early-exit).
- Zrezygnowano ze stosowania wbudowanych (i bardzo wygodnych) operacji języka C#, takich jak `s.Trim().Split(' ')`. Tego typu akcje rzutują fatalnie na zużycie pamięci, wymuszając powoływanie wielu nowych, zbędnych obiektów `string` oraz tablic. Nasze rozwiązania opierają się o bezpośrednie przeliczanie indeksów "w locie".
- Przygotowano program testujący, który wczytuje z zewnętrznego pliku `payload.txt` potężne, wygenerowane skryptowo ciągi znaków (sięgające nawet 10 i 20 milionów liter) z różnymi przypadkami skrajnymi. Pozwoliło to na rzetelne zderzenie sumy kontrolnej obu funkcji i przeprowadzenie wyczerpujących testów wydajnościowych.

## Wyniki testów wydajnościowych
Przeprowadzono ekstremalne testy wydajnościowe, ładując do pamięci gigantyczne ciągi znaków symulujące całe książki napisane w jednej linijce, by sprawdzić, jak zachowa się iteracja w przypadku bardzo małych słów ukrytych na samym końcu tekstu. 

Wyniki udowodniły bezbłędność (zderzenie sumy kontrolnej) i ukazały potężną przewagę czytania łańcucha od końca:
```text
Wczytywanie ekstremalnych testów z payload.txt...
Wczytano 12 zróżnicowanych testów. Rozpoczynam wyliczanie...
Suma kontrolna (testy przeszły pomyślnie): 12 / 12
Czas nowej metody z pętlą 'for' od tyłu (early-exit): 66 ms
Czas starej metody z pętlą 'foreach' (od przodu): 498 ms
Całkowity czas walidacji sumy kontrolnej z logiką wokół: 564 ms
```
Widać tu niemal **8-krotne** (do 10-krotnego) przyspieszenie (66 ms vs blisko pół sekundy) dla zoptymalizowanej metody w starciu z masywnymi tekstami.

## Uzasadnienie i metodologia realizacji
W projekcie zawarto dwie koncepcje rozwiązania problemu:
1. **Metoda naiwna (LengthOfLastWordNaive):** System liniowo czyta podany mu tekst znak po znaku od lewej strony do prawej za pomocą pętli `foreach`. Używa flagi `isSpaceLast` ignorując spacje, a w przypadku trafienia w pierwszą literę po spacji - resetuje dotychczasowy `lenCounter`. W ten sposób program bezlitośnie i bezwzględnie musi zawsze przeczytać cały łańcuch aż do ostatniego znaku, nie ważne gdzie było ukryte słowo.
2. **Metoda zoptymalizowana (LengthOfLastWordOptimized):** Najszybsze z możliwych rozwiązań. Zamiast czytać od początku, stosujemy pętlę `for (int i = s.Length - 1; i >= 0; i--)` wędrującą **od tyłu**. Gdy algorytm minie już ewentualne końcowe spacje i trafi na pierwsze litery, zaczyna je zliczać. Gdy po zliczeniu liter w końcu uderzy w pierwszą z lewej strony spację – wie już na 100%, że wyraz dobiegł końca. Wykonuje wtedy natychmiastowe przerwanie (`break`) operacji i zwraca wynik. To tzw. _early-exit_, który dla bardzo długich zdań gwarantuje wyciągnięcie ostatniego słowa w ułamku sekundy, całkowicie ignorując przymus wczytywania i procesowania reszty miliona wiodących znaków.

## Wady
- Samo podejście wskaźnikowe (iteracyjne) w C# z pętlą `for` od tyłu nie posiada w zasadzie strukturalnych wad w tym konkretnym algorytmie – jest absolutnie optymalne dla pamięci (stałe `O(1)`) i dla czasu CPU (optymistyczny przypadek `O(1)`, najgorszy przypadek w postaci łańcucha pełnego samych spacji to wciąż tylko jednokrotne, bardzo szybkie przejście liniowe `O(N)`). Techniczną wadą pierwotnej wersji (`foreach`) była właśnie niepotrzebna pesymistyczna złożoność i iterowanie milionów zbędnych znaków "od lewej", co w docelowym nowym wariancie zostało z sukcesem zniwelowane w 100%.

</div>
