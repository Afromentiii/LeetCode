# Palindrome Number

Projekt zawiera implementację rozwiązania problemu "Palindrome Number", w którym należy sprawdzić, czy dana liczba całkowita czytana od lewej do prawej jest taka sama jak czytana od prawej do lewej. Program zwraca wartość logiczną `true` dla palindromów i `false` w przeciwnym razie.

## Implementacje

W pliku `Solution.cs` przygotowano trzy różne warianty algorytmu:

1. **Konwersja na ciąg znaków (`IsPalindrome`)**
   - **Opis:** Zmienia podaną liczbę na ciąg znaków (`string`) i za pomocą dwóch wskaźników sprawdza symetrię skrajnych znaków.
   - **Złożoność:** Czasowa $O(N)$, Pamięciowa $O(N)$ (gdzie $N$ to liczba cyfr).

2. **Podejście matematyczne (`IsPalindromeMath`)**
   - **Opis:** Odwraca całą liczbę poprzez wyciąganie reszty z dzielenia przez 10 (modulo) i budowanie nowej liczby odwróconej, a następnie porównuje z oryginałem. Metoda szybko odrzuca liczby ujemne i zakończone zerem.
   - **Złożoność:** Czasowa $O(N)$, Pamięciowa $O(1)$.

3. **Operacje bitowe BCD (`IsPalindromeBCD`)**
   - **Opis:** Koduje poszczególne cyfry dziesiętne z użyciem formatu BCD (Binary-Coded Decimal) w obrębie zmiennej 64-bitowej (`ulong`). Następnie, za pomocą masek bitowych i przesunięć, weryfikuje parami skrajne bloki 4-bitowe (nibble).
   - **Złożoność:** Czasowa $O(N)$, Pamięciowa $O(1)$.

## Testowanie i Benchmark

W projekcie znajduje się skrypt testowy umieszczony w metodzie `Main`, służący do automatycznej weryfikacji wydajności i spójności przygotowanych algorytmów.

### Zestaw danych (`payload.txt`)
Zestaw testowy stanowi zewnętrzny plik `payload.txt`, który zawiera **124 030** przypadków brzegowych. Został przygotowany dla pełnego zakresu 32-bitowej liczby całkowitej ze znakiem ($-2^{31} \le x \le 2^{31} - 1$). W jego strukturze znajdują się m.in.:
- Symetryczne liczby wygenerowane do długości 10 cyfr.
- Pełen zakres liczb ujemnych od `int.MinValue`.
- Typowe przypadki zer, wielokrotności liczby 10 oraz wartości losowe.

### System pomiarowy
Podczas uruchomienia kompilacji z włączonym testowaniem:
1. Obliczany jest całkowity czas operacji dla konkretnego zestawu metodą `Stopwatch`.
2. Program generuje dla wyników niezależną 64-bitową sumę kontrolną (Fowler–Noll–Vo style). Jej weryfikacja zapewnia tożsamość operacyjną wszystkich 3 algorytmów.
3. System raportuje liczbę znalezionych w pliku wystąpień dla potwierdzenia spójności logiki kodu.

Weryfikacja wykazuje pełną spójność wyników we wszystkich trzech wypadkach.

### Wyniki w LeetCode (Podejście stringowe)
Podstawowe rozwiązanie testowane w pierwotnej wersji na platformie LeetCode uzyskało następujące wyniki dla podanych paczek testowych:
- **Liczba przypadków:** 11 511
- **Czas wykonania:** 2 ms

### Wyniki Benchmarku

```text
--- IsPalindromeBCD ---
Czas przeliczenia: 8,658 ms (86578 ticks)
Liczba palindromow: 12016
Suma kontrolna (checksum): 0x813DBF323B114D3D

--- IsPalindrome (String) ---
Czas przeliczenia: 5,747 ms (57468 ticks)
Liczba palindromow: 12016
Suma kontrolna (checksum): 0x813DBF323B114D3D

--- IsPalindrome (Math) ---
Czas przeliczenia: 8,724 ms (87240 ticks)
Liczba palindromow: 12016
Suma kontrolna (checksum): 0x813DBF323B114D3D
```
