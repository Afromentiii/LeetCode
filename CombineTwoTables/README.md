<div style="text-align: justify;">

# Combine Two Tables

## Opis problemu
**Combine Two Tables**

Zadanie polega na napisaniu zapytania SQL, które zwróci imię (`firstName`), nazwisko (`lastName`), miasto (`city`) oraz stan (`state`) dla każdej osoby znajdującej się w tabeli `Person`. Jeśli dana osoba (identyfikowana przez `personId`) nie ma przypisanego adresu w tabeli `Address`, wartości w kolumnach `city` oraz `state` powinny przyjmować wartość `null`.

Struktura tabel:
- **Person:** `personId` (klucz główny), `lastName`, `firstName`.
- **Address:** `addressId` (klucz główny), `personId`, `city`, `state`.

**Przykład:**
Tabela `Person`:
| personId | lastName | firstName |
| -------- | -------- | --------- |
| 1        | Wang     | Allen     |
| 2        | Alice    | Bob       |

Tabela `Address`:
| addressId | personId | city          | state      |
| --------- | -------- | ------------- | ---------- |
| 1         | 2        | New York City | New York   |
| 2         | 3        | Leetcode      | California |

Oczekiwane wyjście:
| firstName | lastName | city          | state    |
| --------- | -------- | ------------- | -------- |
| Allen     | Wang     | null          | null     |
| Bob       | Alice    | New York City | New York |

## Implementacja
W pliku `Solution.sql` zaimplementowano rozwiązanie z wykorzystaniem języka SQL:
- **Opis podejścia:** Wykorzystano operację `LEFT JOIN` do połączenia tabeli `Person` (oznaczonej aliasem `p`) z tabelą `Address` (alias `a`) za pomocą klucza `personId`. Wybór lewego złączenia jest tutaj kluczowy – gwarantuje on, że wszystkie rekordy z lewej tabeli (`Person`) pojawią się w wyniku, nawet jeśli w prawej tabeli (`Address`) nie ma pasującego adresu. W takiej sytuacji kolumny pochodzące z tabeli `Address` (`city`, `state`) zostaną automatycznie uzupełnione wartościami `null`.

## Testowanie
Rozwiązanie stanowi gotowe zapytanie SQL. Aby je przetestować, należy uruchomić je w wybranym środowisku relacyjnej bazy danych (np. MySQL, PostgreSQL, SQL Server), upewniając się wcześniej, że odpowiednie tabele zostały utworzone i zasilone danymi przykładowymi.

</div>
