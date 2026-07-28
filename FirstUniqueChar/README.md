# First Unique Character in a String

Projekt zawiera rozwiązanie popularnego problemu algorytmicznego polegającego na znalezieniu pierwszego unikalnego (niepowtarzającego się) znaku w danym ciągu znaków (stringu). Zwracany jest indeks tego znaku lub `-1`, jeśli każdy znak w ciągu powtarza się przynajmniej raz.

## Pełna Treść Problemu
Mając dany ciąg znaków (string) `s`, znajdź w nim pierwszy niepowtarzający się znak i zwróć jego indeks. Jeśli taki znak nie istnieje, zwróć `-1`.

**Przykłady:**
- `s = "leetcode"` $\rightarrow$ zwraca `0` (ponieważ znak `'l'` występuje tylko raz, pod indeksem 0).
- `s = "loveleetcode"` $\rightarrow$ zwraca `2` (ponieważ pierwsza unikalna litera to `'v'`, pod indeksem 2).
- `s = "aabb"` $\rightarrow$ zwraca `-1`.

## Implementacje

W pliku `Solution.cs` zaimplementowano dwa różne podejścia do tego problemu:

### 1. Podejście z zagnieżdżonymi pętlami (`FirstUniqChar`)
- **Złożoność czasowa:** $O(N^2)$ (w najgorszym przypadku)
- **Złożoność pamięciowa:** $O(K)$, gdzie $K$ to liczba unikalnych znaków w alfabecie.
- **Opis:** Funkcja iteruje po znakach w ciągu znaków, a następnie w zagnieżdżonej pętli sprawdza, czy dany znak powtarza się w dalszej części słowa. Została tu dodana optymalizacja (dynamiczny słownik `Dictionary<char, bool>`), która pomija litery wielokrotnie powtarzające się, eliminując konieczność ponownego sprawdzania ich w wewnętrznej pętli (instrukcja `continue`).

### 2. Podejście ze zliczaniem częstotliwości (`FirstUniqCharFreq`)
- **Złożoność czasowa:** $O(N)$
- **Złożoność pamięciowa:** $O(1)$ (używana jest tablica o stałym rozmiarze 256 niezależnie od długości słowa).
- **Opis:** Funkcja przechodzi przez string dwukrotnie:
  - Za pierwszym razem zlicza częstotliwość występowania każdego znaku i zapisuje ją do tablicy (indeksowanej wartością ASCII znaku).
  - Za drugim razem iteruje przez znaki w kolejności ich występowania w oryginalnym słowie i zwraca indeks pierwszego znaku, którego częstotliwość wynosi dokładnie 1. Tablicowe rozwiązywanie tego zadania eliminuje problem pętli w pętli.

## Wyniki Testów i Porównanie Czasów

W metodzie `Main` zaimplementowany jest moduł mierzący czas wykonania obu algorytmów na bazie biblioteki `System.Diagnostics.Stopwatch`. Algorytm oparty na zliczaniu częstotliwości znaków ($O(N)$) cechuje się zauważalnie lepszą wydajnością. W celu zbadania różnic oba algorytmy zostały uruchomione w pętli 1000 razy na kilkunastu przypadkach testowych, włączając w to jeden bardzo długi string testowy zbudowany z 40 000 znaków, w którym znajduje się jeden unikalny.

**Wynik działania programu z konsoli:**

```text
Przypadki testowe i wyniki:
s = "leetcode                      " -> Pierwsza funkcja: 0      | Druga funkcja: 0     
s = "loveleetcode                  " -> Pierwsza funkcja: 2      | Druga funkcja: 2     
s = "aabb                          " -> Pierwsza funkcja: -1     | Druga funkcja: -1    
s = "a                             " -> Pierwsza funkcja: 0      | Druga funkcja: 0     
s = "abcabc                        " -> Pierwsza funkcja: -1     | Druga funkcja: -1    
s = "z                             " -> Pierwsza funkcja: 0      | Druga funkcja: 0     
s = "dddccdbba                     " -> Pierwsza funkcja: 8      | Druga funkcja: 8     
s = "programming                   " -> Pierwsza funkcja: 0      | Druga funkcja: 0     
s = "aabbccddeeffg                 " -> Pierwsza funkcja: 12     | Druga funkcja: 12    
s = "xxyyzz                        " -> Pierwsza funkcja: -1     | Druga funkcja: -1    
s = "abcdefghijklmnopqrstuvwxyz    " -> Pierwsza funkcja: 0      | Druga funkcja: 0     
s = "aaaaaaaaaaaaaaaaaaaaaaaaaaa..." -> Pierwsza funkcja: 10000  | Druga funkcja: 10000 

--- Pomiary czasu (dla wszystkich powyzszych testow uruchamianych 1000 razy) ---
FirstUniqChar (z zagniezdzona petla): 315 ms
FirstUniqCharFreq (zliczanie czestotliwosci): 176 ms
```

Jak widać, rozwiązanie ze zliczaniem częstotliwości (Druga funkcja) wykonuje to samo zadanie prawie **dwa razy szybciej** i unika pułapki kwadratowej złożoności czasowej.
