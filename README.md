# birdwatcherAPI
Dit cloud API-project is opgezet als applicatie om vogelwaarnemingen bij te houden en te raadplegen.



#### birdwatcherAPI

De database bestaat uit 4 tabellen:

1. Spotters - in deze tabel worden de gegevens van de gebruikers/waarnemers bijgehouden
2. Vogels - in deze tabel worden de verschillende vogels en hun benamingen in andere talen bijgehouden
3. Families - in deze tabel worden vogels gegroepeerd volgens familie 
4. Waarnemingen - in deze tabel worden de waarnemingen bijgehouden - een waarneming bestaat uit een vogel, geslacht van de vogel, locatie van de waarnemingen en door welke spotter de waarneming heeft plaatsgehad

In de applicatie zijn voor de 3 belangrijkste tabellen controllers uitgewerkt waar volgende acties (get, get/{id}, post, put en delete/{id} ) mogelijk zijn. Verder is het ook mogelijk om in elke controller requests te doen naar specifieke gegevens die bij een {id} horen bv. vogels/{id}/spotters geeft een lijst terug van alle spotters die de vogel deze {id} hebben waargenomen.

Sorteren en filteren van de gegevens is uitgewerkt in de waarnemingenController waarbij gefiltert kan worden op vogelnaam en voor- en achternaam van de spotters. Op deze velden kan ook gesorteerd worden bijkomend nog op datum/tijd

Validatie gebeurt bij volgende gegevens:

1. Spotters: voornaam (veld verplicht), achternaam (veld verplicht) en email (moet het goede formaat hebben)
2. Vogels: naam (veld verplicht) en familie (veld verplicht)
3. Familie: naam (veld verplicht)
4. Waarnemingen: datumTijd (veld verplicht), breedtegraad (moet tussen -90° en 90° liggen), lengtegraad (moet tussen -180° en 180° liggen), vogel (veld verplicht) en spotter (veld verplicht)

Authorizatie is uitgewerkt in de waarnemingenController - het is niet mogelijk om de get-request te doen zonder dat er een geldig token (uitgegeven via account.google.cloud) in de request wordt meegegeven.

De applicatie is bereikbaar via volgende url: 

https://birdwatchertest-277214.ew.r.appspot.com

De database zelf is bereikbaar op ip-adres 35.240.88.210



#### birdwatcherClient

De Angular-appliciatie waarmee de API wordt aangesproken is bereikbaar via volgende url:

https://birdwatcherclient.ew.r.appspot.com

In deze applicatie is het mogelijk om alle acties uit te voeren in de vogelController (bekijken, toevoegen, verwijderen en aanpassen). Een evenetuele validatie-error wordt weergegeven in een alert. Bij elke response wordt vanuit de applicatie de pixabay-api (https://pixabay.com/api/docs/) aanspreekt en een afbeelding van deze vogel weergeeft (deze wordt opgezocht aan de hand van de Latijnse naam)

Bekijken van de waarnemingen is enkel mogelijk wanneer de gebruiker is ingelogd via google. De volledige lijst wordt weergeven per 10 en we kunnen door de verschillende pagina's stappen. Verder is het in dit venster mogelijk om de gegevens te sorteren en te filteren.



#### DevOps

In deze repo bevinden zicht ook de Dockerfile, Jenkinsfile en script om de client-applicatie te runnen op een lokale server.