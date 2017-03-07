# ShadowsOfShadows
W ramach projektu będziemy pracowali nad grą o nazwie Shadows of Shadows. Będzie to gra z gatunku Role Playing Game + Slack’n’Slash w klamcie klasycznym, t.j. zorientowanym na gobliny, elfy, trolle, etc. Nasz bohater o imieniu $nick budzi się w tajemniczej komnacie w lochach nalężących do $Boss_name. Od stróża dowiaduje się, że jego ukochana $love_name został uprowadzona przez $Boss_name. $nick postanawia ją  uratować. W związku z tym wydostaje się z celi i wyrusza na walkę z potworami przez lochy, szukając ukochanej $love_name.

Gra będzie się opierać na systemie Czasu Rzeczywistego, czyli nie turowego. Postać gracza będzie wzbogacona o rozwój na podstawie punktów doświadczenia, poziomów oraz punktów umiejętności. Oprócz tego bohater podczas wędrówki będzie miał możliwość zbierania przedmiotów do ekwipunku o charakterze funkcjonalnym, np. odnowa życia, bądź ulepszony atak, lub fabularnym, mającym na celu przechodzenie do kolejnych etapów historii.

Między etapami fabularnymi będziemy tworzyli losowo generowane pokoje aby wydłużyć i urozmaicić rozgrywkę.

Technologia jakiej użyjemy to MonoGame, C#, .NET. Podczas pierwszego sprintu użyjemy biblioteki SadConsole opartej o MonoGame, która dostarcza emulację konsoli wewnątrz okna DirectX lub OpenGL.

Podczas pierwszego sprintu skupimy na funkcjonalności, korzystając z SadConsole do prostej reprezentacji obiektów na ekranie. Natomiast w drugim sprincie rozszerzymy grę o grafikę.

Zadbamy o modularność i obiektowość aplikacji. Uwzględniając dobre praktyki i wzorce projektowe używane w dzisiejszych aplikacjach.


Powyżej korzystamy ze zmiennych $nick, $Boss_name, $love_name, które będą zdefiniowane na początku gry przez gracza.
