 
# Projekt stworzony w celach rekrutacyjnych

Tworząc ten projekt miałem w zamyśle stworzyć coś dzięki czemu całkowicie niezależny będzie od siebie backend i frontend. 
Chciałem także żeby aplikacja była jak najbardziej skalowalna.
Tworząc tą aplikację trzymałem się takich konwencji i wzorców jak:
* SOLID
* YAGNI
* DRY
* KISS
* IoC
* Dependency injection
* Repository pattern
* CQRS.
* Onion architecture

##
###	Uruchamianie

* Aplikacja do uruchomienia wymaga bazy danych MongoDB uruchomionej na domyślnym porcie z domyślym użytkownikiem.
[Wiki](https://docs.mongodb.com/manual/installation/), oraz [.NET core](https://github.com/dotnet/core/blob/master/release-notes/download-archive.md) w wersji 1.1 .

* Pobraną i wypakowana [aplikację](https://drive.google.com/open?id=0B3fm0ZCW9xYJTlVlSW9HOGN4X2M) uruchamiamy z poziomu cmd lub terminala komendą ```dotnet tools.api.dll```

* Aplikacja powinna być teraz uruchomiona i działać na porcie 5000. 
 
![tak powinno być](http://i.imgur.com/aoIxBVt.jpg)


##
### Korzystanie

``Niestety z braku czasu i zasobów nie byłem w stanie wdrożyć  rozwiązania jak i stworzyć front endu aplikacji.``

* GET ``http://localhost:5000/tools`` - Zwraca listę narzędzi jako object JSON
* POST ``http://localhost:5000/tools`` - Tworzy nowe narzędzie w bazie; JSON przekazany powinnien mieć formę ``[ 
     {
        "model": "model
        "brand": "marka
        "type": "typ
        "box": numerszafki
    }
]``

* POST ``http://localhost:5000/tools/delete`` - Usuwa narzędzie o Id podanym w JSON. 
* PUT ``http://localhost:5000/tools/update`` - Aktualizuje narzędzie w bazie; Przekazany JSON powinnien mieć formę ``{
	"id": "id",
    "model": "model",
    "brand": "marka",
    "type": "typ",
    "box": numerszafki
}``

* GET ``http://localhost:5000/tools/{nazwa_modelu}`` - zwraca ogólne informację o modelu.


