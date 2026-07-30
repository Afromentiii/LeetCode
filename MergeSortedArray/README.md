# Merge Sorted Array

Rozwiązanie problemu **Merge Sorted Array** (LeetCode 88) w języku C#.

## Opis problemu
Dane są dwie posortowane rosnąco tablice liczb całkowitych `nums1` oraz `nums2`. Zadaniem jest scalenie elementów `nums2` do `nums1` w taki sposób, aby wynik końcowy znajdował się w `nums1` i pozostał posortowany.
Tablica `nums1` ma rozmiar `m + n`, gdzie początkowe `m` elementów to liczby docelowe, a końcowe `n` elementów ma wartość `0` (stanowiąc rezerwację miejsca na elementy z `nums2`).

## Zaimplementowane podejścia

Przygotowano dwie metody scalania w celu przetestowania wydajności różnych rozwiązań:

1. **Klasyczne, oryginalne podejście (`MergeOriginal`)**:
   Działa głównie w oparciu o wstawianie (algorytm zbliżony do Insertion Sort). Analizuje elementy z `nums2` i znajduje dla nich miejsce w `nums1`, w razie konieczności przesuwając odpowiedni fragment tablicy. Główną zaletą jest działanie w miejscu (in-place) — algorytm nie wymaga alokacji dodatkowej tablicy w pamięci.
   
2. **Podejście oparte na QuickSort (`MergeQuickSort`)**:
   Opiera się na złączeniu zbiorów bez wykorzystania faktu, że tablice wejściowe są już posortowane:
   - Kopiuje zawartość obu tablic do nowej, tymczasowej tablicy.
   - Uruchamia własną implementację algorytmu **QuickSort** w celu posortowania całego zbioru.
   - Kopiuje posortowany zbiór z powrotem do tablicy docelowej.
   - Złożoność to $O((m+n)\log(m+n))$ i użycie dodatkowej pamięci w rozmiarze połączonych tablic.

## Pomiary wydajności

Zbudowano mechanizm służący do obiektywnego testowania obu podejść.
Skrypt Python (`generate_payload.py`) generuje zestaw 1000 testowych przypadków (w tym brzegowych) zgodnych z wytycznymi problemu, zapisując je w pliku `payload.txt`. Program testujący w C# odczytuje zawartość, parsuje dane, tworzy niezależne kopie tablic dla każdej z metod w celu izolacji wywołań i dokonuje pomiaru łącznego czasu ich wykonania (przy użyciu klasy `Stopwatch`).
W celu potwierdzenia poprawności wdrożono weryfikację. Mechanizm sprawdza, czy **suma kontrolna** wyliczana dla metody opartej na `QuickSort` daje dokładnie ten sam wynik, co algorytm pierwotny.

### Wnioski z pomiarów
Na podstawie testów składających się z 1000 iteracji uzyskano następujące wyniki czasowe:
- **`MergeOriginal`**: ~14 ms
- **`MergeQuickSort`**: ~24 ms

Podejście wykorzystujące fakt, że części składowe są domyślnie posortowane (pierwsza implementacja), wykonuje się zauważalnie szybciej. Użycie algorytmu QuickSort, połączone z koniecznością alokowania i klonowania nowej, pomocniczej tablicy, stwarza odczuwalny narzut obniżający wydajność przy analizowanych ilościach danych.
