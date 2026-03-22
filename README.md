Projekt cw3 s34366 20c:

Kod podzieliłem na 4 sekcje. W projekcie "serwis" surowo leżą klasy odpowiadające za logikę biznesową 
i interakcję użytkownika z CLI. 

Są też trzy foldery - "Users", "Equipment" i "Utils". Przechowują one odpowiednio 
typy użytkowników "Student" i "Employee" oraz ich enumeratory - korzystają oni z dziedziczenia po userze.

Analogicznie w folderze "Equipment" znajdują się klasy dotyczące wyposażenia serwisu zbudowane w ten sam sposób.

Folder utils przechowuje jedną klasę - InputUtils. Przechowuje ona funkcje, które pobierają inputy od użytkownika i są wykorzystywane kilkukrotnie w klasie UI.
Dzięki temu mogłem uniknąc wielokrotnego powtarzania kodu pobierania inputu.

Zdecydowałem się na takie rozwiązanie, ponieważ wygląda ono czytelniej, przyjemniej dla oka oraz jest bardziej modularne.
To podejście umożliwia mi "przyjemniejszy" proces dalszego rozwoju aplikacji.


