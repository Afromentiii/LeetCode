# Two Sum

Projekt zawiera implementację rozwiązania klasycznego problemu "Two Sum", w którym należy odnaleźć dwa elementy w tablicy liczbowej, dające w sumie określoną wartość docelową (`target`). Zwracana jest tablica zawierająca indeksy dwóch elementów. W przypadku braku dopasowania zwracana jest tablica `[-1, -1]`.

## Implementacja

W pliku `Solution.cs` zaimplementowano najprostsze podejście brutalne (ang. *Brute Force*):
- **Złożoność czasowa:** $O(N^2)$
- **Złożoność pamięciowa:** $O(1)$
- **Opis:** Funkcja korzysta z dwóch zagnieżdżonych pętli sprawdzając każdą możliwą kombinację pary wartości z podanej tablicy `nums`. Kiedy tylko program odnajdzie właściwą sumę `nums[i] + nums[j] == target`, natychmiast przerywa działanie i zwraca indeksy, oszczędzając czas.

## Testowanie i Wydajność

Zamiast standardowych krótkich przypadków, projekt został zoptymalizowany pod kątem odczytu **dużego zewnętrznego zestawu danych (payload.json)**.
Wygenerowany plik `payload.json` posiada 5000 różnorodnych przypadków z tablicami o długości od 10 do 800 elementów oraz losowymi wartościami docelowymi.

W kodzie wykorzystano nowoczesne parsowanie JSON w oparciu o wbudowaną bibliotekę `System.Text.Json` posiłkując się **Source Generatorami** (`JsonSerializerContext`). Pozwala to na kompilację projektu z włączonymi profilami obcinającymi kod czy Native AOT, minimalizując błędy braku obsługi klasycznej Serializacji Refleksyjnej.

### Wyniki Działania
Program zaczytuje plik do pamięci oraz uruchamia algorytm *Brute Force* badając wszystkie pięć tysięcy losowych tablic.

Wynik z konsoli:
```text
--- Odczyt zewnętrznego payloadu (payload.json) ---
Pomyślnie wczytano 5000 przypadków testowych z pliku.

--- Pomiar czasu wykonania algorytmu (Brute Force O(N^2)) ---
Całkowity czas dla 5000 przypadków testowych: 335 ms
-> Sukces (znaleziono parę): 3810 razy
-> Porażka (brak pary): 1190 razy
```
Pomimo pesymistycznej kwadratowej złożoności czasowej $O(N^2)$, zoptymalizowane struktury tablic w C# pozwoliły przetworzyć tak ogromny zestaw próbny w zaledwie ponad jedną trzecią sekundy (~330ms).
