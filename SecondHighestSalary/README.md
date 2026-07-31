<div style="text-align: justify;">

# Second Highest Salary

## Opis problemu
**Second Highest Salary**

Zadanie polega na napisaniu zapytania SQL, które zwróci drugą najwyższą pensję z tabeli `Employee`. Jeśli druga najwyższa pensja nie istnieje (np. w tabeli jest tylko jeden pracownik lub wszyscy pracownicy mają dokładnie taką samą pensję), zapytanie powinno zwrócić wartość `null`.

Struktura tabeli:
- **Employee:** `id` (klucz główny), `salary`.

**Przykład 1:**
Tabela `Employee`:
| id | salary |
| -- | ------ |
| 1  | 100    |
| 2  | 200    |
| 3  | 300    |

Oczekiwane wyjście:
| SecondHighestSalary |
| ------------------- |
| 200                 |

**Przykład 2:**
Tabela `Employee`:
| id | salary |
| -- | ------ |
| 1  | 100    |

Oczekiwane wyjście:
| SecondHighestSalary |
| ------------------- |
| null                |

## Implementacja
W pliku `Solution.sql` zaimplementowano rozwiązanie z wykorzystaniem języka SQL:
- **Opis podejścia:** Podzapytanie pobiera unikalne wartości pensji (`DISTINCT salary`) z tabeli `Employee` i sortuje je w kolejności malejącej (`ORDER BY salary DESC`). Następnie za pomocą klauzul `LIMIT 1` i `OFFSET 1` odrzucana jest najwyższa wartość i wybierana ta druga w kolejności.
- By upewnić się, że w przypadku braku drugiego wyniku zapytanie zwróci `null` zamiast pustego zbioru, podzapytanie zostało otoczone zewnętrznym blikiem: `SELECT (...) AS SecondHighestSalary`. W języku SQL, użycie takiego podzapytania jako wartości kolumny skutkuje zwróceniem wartości systemowej `null` w przypadku pustego wyniku.

## Testowanie
Rozwiązanie stanowi gotowe zapytanie SQL. Możesz przetestować jego poprawne działanie, uruchamiając skrypt na dowolnym silniku bazy danych (np. MySQL, PostgreSQL) upewniając się wcześniej, że przygotowałeś tabelę `Employee` z odpowiednimi rekordami, uwzględniając także przypadek brzegowy z tylko jednym wpisem.

</div>
