<div style="text-align: justify;">

# Binary Tree Inorder Traversal

## Opis problemu
**94. Binary Tree Inorder Traversal** (Easy)

Mając dany korzeń (`root`) drzewa binarnego, zwróć wartości jego węzłów (nodes) po kolei, używając przejścia zwanego *Inorder Traversal* (Przejście poprzeczne/wzdłużne - najpierw lewe poddrzewo, następnie korzeń, a na końcu prawe poddrzewo).

**Przykład 1:**
Wejście: `root = [1,null,2,3]`
Wyjście: `[1,3,2]`

**Przykład 2:**
Wejście: `root = []`
Wyjście: `[]`

**Przykład 3:**
Wejście: `root = [1]`
Wyjście: `[1]`

**Ograniczenia:**
- Liczba węzłów w drzewie mieści się w przedziale `[0, 100]`.
- `-100 <= Node.val <= 100`

**Dodatkowe wyzwanie (Follow up):** Rozwiązanie rekurencyjne jest trywialne, czy potrafisz zrobić to iteracyjnie? (Obecnie w kodzie zaimplementowano wersję rekurencyjną).

## Zrealizowane cele
- Zaimplementowano prawidłowe i niezwykle wydajne rozwiązanie oparte na rekurencji z wydzieloną, wyizolowaną metodą pomocniczą.
- Osiągnięto złożoność czasową rzędu O(n), co jest wartością najbardziej optymalną dla tego zadania, ponieważ konieczne jest jednorazowe odwiedzenie każdego z n węzłów.
- Stworzono zestaw czterech precyzyjnych testów wraz z wbudowanym mikro-profilerem czasu (`Stopwatch`), co pozwala na obserwację czasu narzutu wirtualnej maszyny (.NET JIT) oraz testowanie wariantów brzegowych drzew o różnej budowie.

## Uzasadnienie i metodologia realizacji
- Użyto podejścia z osobną metodą pomocniczą `Traverse`. W funkcji głównej inicjowana jest pojedyncza struktura `List<int>`, która służy jako jednolity pojemnik dla dodawanych w trakcie przemieszczania wartości.
- Lista ta przekazywana jest (jako referencja do obiektu) głębiej do wszystkich poziomów wywołań rekurencyjnych stosu programu. Pozwala to na uniknięcie skomplikowanego łączenia list zwracanych z różnych gałęzi rekurencji oraz używania kosztownych zasobowo operacji typu `.AddRange()`. Dzięki temu złożoność alokowania pamięci wynosi stabilne O(n).
- Logika algorytmu Inorder zakłada badanie struktury drzewa w 3 uporządkowanych krokach: 
  1. Zejdź tak głęboko jak to możliwe w lewo (`Traverse(node.left)`).
  2. Po powrocie – przetwórz obecny węzeł na tym poziomie (`result.Add(node.val)`).
  3. Zejdź w prawo na tej samej zasadzie (`Traverse(node.right)`).
- Ten porządek odwiedzin zapewnia na przykład, że gdyby do algorytmu załadowano Drzewo Poszukiwań Binarnych (BST), do tablicy dodane zostałyby perfekcyjnie rosnące, posortowane wartości.

## Wady
- Rozwiązanie rekurencyjne wykorzystuje automatyczny stos wywołań, co zawsze oddelegowuje ryzyko błędu do środowiska. Dla głębokich i silnie zdegenerowanych (przypominających linię) drzew liczących dziesiątki tysięcy węzłów, taka konstrukcja pochłonęłaby gigantyczną ilość pamięci, natychmiast prowadząc do twardego uszkodzenia programu błędem `StackOverflowException`. 
- Idealnym (choć niekiedy mniej eleganckim, jeśli chodzi o czytelność) sposobem zabezpieczenia się na skalę komercyjną byłoby przepisanie algorytmu na iterację z użyciem manualnej pętli `while` oraz jawnej deklaracji obiektu `Stack<TreeNode>`. Chroniłoby to nas przed awariami na poziomie samego stosu wykonawczego procesu.

</div>
