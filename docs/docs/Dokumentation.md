---
sidebar_position: 1
title: Dokumentation
---
:::note

Dies ist die Dokumentation des Projekts. Sie wurde nach IPERKA umgesetzt. Es wird der Ablauf und die Vorgehensweise des ganzen Projekts dokumentiert.

In diesem Projekt erstelle ich ein eine Buchhaltungsawendung, welche einfache Buchungssätze ausführen können soll. Es geht vor allem um die objektorientierte Programmierung mit standardisierten Design Patterns.

:::

## Informieren

In diesem Kapitel der Dokumentation wird die Phase festgehalten, in welcher ich mich über das alles Nötige informiere. Dazu gehören auch die Anforderungen, die Zeiteinteilung und die Auflistung [**aller verwendeten Quellen**](#quellen).

### Was verstehe ich unter Design Patterns?

### Was ist mein Ziel?

### Anforderungen

In der folgenden Tabelle sind die Anforderungen für das Projekt vorzufinden.


| Nr. | Muss/Kann | funk./qual. | Beschreibung |
| ----- | ----------- | ------------- | -------------- |
| 1   |           |             |              |
| 2   |           |             |              |
| 3   |           |             |              |
| 4   |           |             |              |
| 5   |           |             |              |
| 6   |           |             |              |
| 7   |           |             |              |
| 8   |           |             |              |
| 9   |           |             |              |
| 10  |           |             |              |

### Technologien

Für dieses Projekt habe ich folgende Technologien verwendet:

- [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [C#](https://de.wikipedia.org/wiki/C-Sharp)

### Quellen

Hier sind alle Quellen aufgelistet, welche während dem Aublauf des Projekts als Hilfe oder Orientation verwendet wurden.

- [Design Patterns](https://refactoring.guru/design-patterns)

## Planen

### Arbeitspakete


| Nr. | Frist      | Beschreibung                                                   | Geplante Zeit in Paketen |
| ----- | ------------ | :--------------------------------------------------------------- | -------------------------- |
| 1   | 28.04.2023 | Informieren (von IPERKA): vor allem über Design Patterns      | 5 (ggf. mehr)            |
| 2   | 28.04.2023 | Planen und Entscheiden (von IPERKA): Tests erstellen           | 2                        |
| 3   | 28.04.2023 | Planen und Entscheiden (von IPERKA): Klassendiagramm erstellen | 3                        |
| 4   | 12.05.2023 | Realisieren (von IPERKA): Klassen ausprogrammieren             | 10                       |
| 5   | 26.05.2023 | Kontrollieren (von IPERKA)                                     | 3                        |
| 6   | 26.05.2023 | Auswerten (von IPERKA)                                         | 2                        |
| 7   | 02.06.2023 | Portfolioeintrag bis am Abend                                  | 3 (ggf. mehr)            |

:::info

1x Arbeitspaket = 45 Minuten = 1x Schullektion

1x Halbtag = 5x Arbeitspakete

5x Halbtage = 25x Arbeitspakete

25x Arbeitspakete + 3x Portfolio = **28x Arbeitspakete**

:::

### Ausführung


| Nr. | Frist      | Bemerkung | Zeit geplant | Zeit effektiv |
| ----- | ------------ | ----------- | -------------- | --------------- |
| 1   | 28.04.2023 |           | 5            |               |
| 2   | 28.04.2023 |           | 2            |               |
| 3   | 28.04.2023 |           | 3            |               |
| 4   | 12.05.2023 |           | 10           |               |
| 5   | 26.05.2023 |           | 3            |               |
| 6   | 26.05.2023 |           | 2            |               |
| 7   | 02.06.2023 |           | 3            |               |

### Testfälle


| Testf.<br />Nr. | Anf.<br />Nr. | Voraussetzungen | Testumgebung | Eingabe | Erw. Ausgabe |
| ----------------- | --------------- | ----------------- | -------------- | --------- | -------------- |
| 1.1             | 1             |                 |              |         |              |
| 2.1             | 2             |                 |              |         |              |

#### Testumgebungen

* XY
  * Version 1.2.3
  * Build xyz123abc
* AB
  * Version 1.2.3

## Entscheiden

## Realisieren

### Konzeptbeschreibung

Das Spiel soll verschiedene Barrieren beinhalten, welche es zu überwinden gilt, um die Flagge (das Ziel) zu erreichen. Wie man an die Flagge kommt ist dem Spieler überlassen, dieser soll einfach die Anleitung beachten und die gegebenen Regeln einhalten. Im Fall, dass der Spieler nicht mehr weiterkommt, kann er bei der entsprechenden Stelle in der Anleitung eine Dropdown-Section öffnen, um die dort notierten Hinweise oder Tips zu verwenden. Für den Fall, dass er gar nicht mehr weiterkommt, gibt es mögliche Lösungen auf einer separaten Seite.

Um das Spiel zu beginnen, soll man den Anweisungen aus der Anleitung folgen können. Diese beinhalten folgende Sachen:

* Was man alles schon installiert haben muss
* Welche Images man von der Registry pullen muss
* Wie man diese Images pullt
* Wie man einen Container aus diesen Images startet
* Bei jedem Level Startanweisungen
* Bei jedem Level 2 bis 3 Hinweise

Der Spieler soll mit diesen Informationen das Spiel vollständig durchspielen können. Als "durchgespielt" zählt, wenn er jede Flagge gefunden hat.

Diese Flaggen müssen alle im folgenden Format sein: `flag{challenge_name}`

## Kontrollieren


| Testf.<br />Nr. | Anf.<br />Nr. | Voraussetzung                                              | Testumgebung | Eingabe                                                                                                        | Erw. Ausgabe                                                                                                      | Bemerkung                                                                                                        | Ergebnis |
| :---------------- | --------------- | :----------------------------------------------------------- | -------------- | :--------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------ | ---------- |
| 1.1             | 1             | PoC ist vorhanden                                          | Docker       | Image von der Registry pullen und mit`docker run` starten. Als nächstes den Befehl `docker ps -a` ausführen. | Container erscheint in der ausgegebenen Liste.                                                                    |                                                                                                                  | OK       |
| 2.1             | 2             | PoC ist am Laufen                                          | Docker       | Mit der Lösung geht man durch das Spiel bis man fertig ist.                                                   | Eine Flagge erscheint.                                                                                            | Bei beiden Lösungen erscheint am Ende eine Flagge.                                                              | OK       |
| 3.1             | 3             | GH-Pages-Dokumentation ist offen                           | Chrome       | Der Spieler öffnet die Unterseite Lösungen und sieht sie sich an.                                            | Die Barrieren haben unterschiedliche Lösungswege                                                                 | Es sind zwei ganz verschiedene Barrieren.                                                                        | OK       |
| 4.1             | 4             | PoC ist am Laufen                                          | Docker       | Ohne Lösungen die Barrieren überwinden                                                                       | IT-Lehrperson oder Klassenkamerad hat die Flagge vor sich.                                                        | Bruteforce konnte gelöst werden. SQLi nicht probiert.                                                           | OK       |
| 5.1             | 5             | GH-Pages-Dokumentation ist offen                           | Chrome       | Der Spieler öffnet die Unterseite mit der Anleitung und führt die Anweisungen darin aus.                     | Der Spieler ist startklar und weiss was er/sie zu tun hat.                                                        |                                                                                                                  | OK       |
| 6.1             | 6             | PoC ist am Laufen                                          | Docker       | Alle Flaggen finden.                                                                                           | Die Flaggen sind im Format: flag{challenge_name}                                                                  |                                                                                                                  | OK       |
| 7.1             | 7             | GH-Pages-Dokumentation ist offen                           | Chrome       | Der Spieler öffnet die Unterseite Lösungen und sieht sie sich an.                                            | Benutzer kann die Barriere überwinden.                                                                           |                                                                                                                  | OK       |
| 8.1             | 8             | PoC am Laufen                                              | Docker       | Der Spieler versucht mit Hilfe von Kenntnissen aus der Informatik die Barrieren zu überwinden.                | Der Spieler findet die Flaggen.                                                                                   | Der Mitschüler musste zuerst Recherchieren, da er nicht alles wusste.                                           | OK       |
| 9.1             | 9             | Shell/Terminal ist offen                                   | Docker       | Der Spieler gibt den Befehl`docker pull <registry URL>` ein.                                                   | Das Image wird gepullt.                                                                                           |                                                                                                                  | OK       |
| 10.1            | 10            | GH-Pages-Dokumentation ist offen                           | Chrome       | Der Spieler geht zur Unterseite der Anleitung und sieht sie sich an.                                           | Ein Regelwerk ist für den Spieler ersichtlich.                                                                   | Es sind zwar "zusätzliche Informationen" vorhanden, es gibt aber kein klares Regelwerk.                         | NOK      |
| 11.1            | 11            | GH-Pages-Dokumentation ist offen und das PoC ist am Laufen | Chrome       | Der Spieler öffnet die Anleitung und liest sich die Hinweise durch.                                           | Mit den Hinweisen ist der Spieler in der Lage die Barriere zu überwinden, ohne dass er die Lösung erfahren hat. | Anfangs hatte der Mitschüler Probleme, jedoch klappte es nach ein wenig Recherche. Die Hinweise haben geholfen. | OK       |

### Testfazit

Fast alle Tests waren erfolgreich. Nur ein einziger (10.1) war nicht OK. Dort geht es um ein Regelwerk, das nicht implementiert wurde. Aber da es eine kann-Anforderungen ist (Anforderung Nr. 10), wird es nicht mehr implementiert.

## Auswerten

### Reflexion

Unser Ziel in diesem Projekt war es ein Proof-Of-Concept für ein Capture The Flag Spiel zu erstellen, um zu beweisen, dass es möglich ist eins solches mit unserer Vorgehensweise zu machen.

Für dieses Projekt haben wir viel Zeit in das Informieren und Planen investiert. Diese Zeitinvestition hat uns im Verlauf vom Projekt sehr geholfen, da wir nicht auf Unerwartetes gestossen sind. Wir konnte somit gut im Zeitplan bleiben und mussten selten ausserhalb der Schule arbeiten.

Die Arbeit am Projekt verlief von Beginn an gut. Wir konnten uns schnell für eine geignete Lösung entscheiden und hatten die selben Vorstellungen vom Endprodukt. Das hat uns viel kostbare Zeit gespart.

Unser Projekt ist vollständig, wir konnten alle relevanten Anforderungen erfüllen und sin dmit dem Endprodukt zufrieden.

### Schlussfolgerung vom PoC

#### Funktionalität

Unser Endprodukt ist funktional und erfüllt seinen Zweck. Beide Levels können ohne Probleme durchgespielt werden. Die Anleitung und die Lösung haben einen Nutzen.

#### Umsetzbarkeit

Mit unseren Kenntnissen ist ein CTF in einem grösserem Mass gut umsetzbar, wir bräuchten einfach mehr Zeit. Es steht dem grösseren Projekt nichts im Wege, beim PoC ist alles reibungslos verlaufen.

#### Erfüllung der Anforderungen

Weil wir im PoC alle Anforderungen erfüllt haben, könnten wir im eigentlichen Spiel dasselbe Format verwenden. Es ist simpel zu implementieren und es gibt eine gewisse Einheitlichkeit.

Wir können uns gut vorstellen, dass wir es in einem grösseren Mass umsetzten könnten.
