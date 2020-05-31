Gebruik VanDamHuisAgendareporter als volgt:

CSV bestand maken
1. Log als administrator in op https://vandamhuis.nl
3. Ga op het dashboard naar Evenementen > Export Events as CSV
4. Selecteer: delimiter Semicolon (;)
5. Kies: Export CSV file
6. Sla op als My Documents\Van Dam Huis agenda\events.csv

PDF rapport genereren
1. Zorg dat het events.csv bestand aanwezig is in de bovengenoemde map.
2. VanDamHuisAgendaReporter.exe vanaf de command line met eventuele optionele argumenten.
3. Het rapport wordt als PDF bestand opgeslagen in My Documents\Van Dam Huis agenda\

Command line argumenten:
inhclude=private ; standaard worden alleen publieke evenementen getoond
until=2020-12-31 ; standaard worden evenementen tot een jaar vooruit getoond.

Voorbeelden:
app\VanDamHuisAgendaReporter.exe 
app\VanDamHuisAgendaReporter.exe include=private
app\VanDamHuisAgendaReporter.exe include=private until=2020-12-31
app\VanDamHuisAgendaReporter.exe until=2020-12-31



