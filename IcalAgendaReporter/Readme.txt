Gebruik VanDamHuisAgendareporter als volgt:


PDF rapport genereren
1. Start VanDamHuisAgendaReporter.exe vanaf de command line met eventuele optionele argumenten.
3. Het rapport wordt als PDF bestand opgeslagen in My Documents\Van Dam Huis agenda\

Command line argumenten:

<geen argumenten>
- Alle publieke evenementen vanaf vandaag tot een jaar vooruit worden getoond.

include=private
- neem ook privé evenementen op
- standaard worden alleen publieke evenementen getoond

from=2020-07-01
- evenementen vanaf deze datum worden getoond 
- standaard worden evenementen vanaf vandaag getoond

until=2020-12-31
- evenementen tot deze datum worden getoond
- standaard worden evenementen tot een jaar vooruit getoond.

weeks=5
- evenementen worden tot 5 weken vooruit getoond
- als je weeks gebruikt dan worden from en until genegeerd.

bg=true
- toont de achtergrond
- standaard is false

Voorbeelden:
app\VanDamHuisAgendaReporter.exe 
app\VanDamHuisAgendaReporter.exe include=private
app\VanDamHuisAgendaReporter.exe include=private until=2020-12-31
app\VanDamHuisAgendaReporter.exe until=2020-12-31
app\VanDamHuisAgendaReporter.exe weeks=5



