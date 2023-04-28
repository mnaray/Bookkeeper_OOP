---
sidebar_position: 1
title: Dokumentation
---
:::note

Dies ist die Dokumentation des Projekts. Sie wurde nach IPERKA umgesetzt. Es wird der Ablauf und die Vorgehensweise des ganzen Projekts dokumentiert.

In diesem Projekt erstelle ich ein eine Buchhaltungsawendung, welche einfache Buchungssätze ausführen können soll. Es geht vor allem um die objektorientierte Programmierung mit standardisierten Design Patterns.

:::

## Informieren

In diesem Kapitel der Dokumentation wird die Phase festgehalten, in welcher ich mich über alles Nötige informiere. Dazu gehören auch die Anforderungen, die Zeiteinteilung und die Auflistung [**aller verwendeten Quellen**](#quellen).

### Was versteht man unter Design Patterns?

Design Patterns sind bewährte Lösungsansätze für häufig auftretende Probleme in der Softwareentwicklung. Sie bieten Entwicklern eine strukturierte Herangehensweise zur Lösung dieser Probleme. Sie helfen bei der Entwicklung von effizienter, wartbarer und flexibler Software. Unter anderem wird auch die Wiederverwendbarkeit und Erweiterbarkeit von Code mit ihnen verbessert.

### Was ist mein Ziel?

Es ist in diesem Projekt mein Ziel, eine einfache, funktionsfähige Buchhaltungsapplikation für die Kommandozeile zu gestalten und diese dann zu implementieren.

Dabei möchte ich grundlegende Design Patterns in der objektorientierten Programmierung anwenden. So soll der Code einfach Erweiterbar und wartbarer werden. Dies ist mir wichtig, da ich ggf. in zukünftigen Projekten auf diese Anwendung aufbauen möchte.

### Anforderungen

In der folgenden Tabelle sind die Anforderungen für das Projekt vorzufinden.


| Nr. | Muss/<br />Kann | funk./<br />qual./ rand | Beschreibung                                                                                        |
| ----- | ----------------- | ------------------------- | ----------------------------------------------------------------------------------------------------- |
| 1   | M               | funk.                   | Die Software muss eine Bilanz nach dem KMU-Kontenrahmen haben.                                      |
| 2   | M               | funk.                   | Die Software muss eine Erfolgsrechnung nach dem KMU-Kontenrahmen haben.                             |
| 3   | M               | funk.                   | Die Software muss Buchungssätze ausführen können und dabei die betroffenen Konten aktualisieren. |
| 4   | M               | funk.                   | Ein Buchungssatz muss Buchungstext, Soll-Konto, Haben-Konto und Betrag umfassen.                    |
| 5   | M               | funk.                   | Alle gebuchten Buchungssätze müssen in einer Datenbank gespeichert werden.                        |
| 6   | M               | funk.                   | Die Bilanz muss in einer Datenbank festgehalten werden.                                             |
| 7   | M               | funk.                   | Die Software muss über die Kommandozeile bedienbar sein.                                           |
| 8   | K               | qual.                   | Es soll einen Hilfe-Befehl haben, der alle möglichen Befehle auflistet und erklärt.               |
| 9   | K               | qual.                   | Jeder Befehl soll eine kleine Erklärung dazu haben.                                                |
| 10  | M               | funk.                   | Es braucht einen Befehl, um Buchungssätze zu bilden.                                               |
| 11  | M               | funk.                   | Es braucht einen Befehl, um die Bilanz auszugeben.                                                  |
| 12  | M               | funk.                   | Es braucht einen Befehl, um die Erfolgsrechnung auszugeben.                                         |
| 13  | M               | rand                    | Es muss ein Klassendiagramm in UML vorhanden sein.                                                  |
| 14  | M               | rand                    | Die Software soll nach dem MVC-Konzept aufgebaut sein.                                              |
| 15  | M               | rand                    | Diese erste Version soll vollständig auf Englisch sein.                                            |

### Technologien

Für dieses Projekt habe ich folgende Technologien verwendet:

- [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [C#](https://de.wikipedia.org/wiki/C-Sharp)
- [SQLite](https://sqlite.org/index.html)

### Quellen

Hier sind alle Quellen aufgelistet, welche während dem Aublauf des Projekts als Hilfe oder Orientation verwendet wurden.

- [Design Patterns](https://refactoring.guru/design-patterns)
- [SQLite offizielle Doku](https://sqlite.org/docs.html)
- [Anwendung von SQLite in einer C# App](https://www.codeguru.com/dotnet/using-sqlite-in-a-c-application/)

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


| Nr. | Frist      | Bemerkung                            | Zeit geplant | Zeit effektiv |
| ----- | ------------ | -------------------------------------- | -------------- | --------------- |
| 1   | 28.04.2023 | Zusätzlich in SQLite eingearbeitet. | 5            | 7             |
| 2   | 28.04.2023 |                                      | 2            |               |
| 3   | 28.04.2023 |                                      | 3            |               |
| 4   | 12.05.2023 |                                      | 10           |               |
| 5   | 26.05.2023 |                                      | 3            |               |
| 6   | 26.05.2023 |                                      | 2            |               |
| 7   | 02.06.2023 |                                      | 3            |               |

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

### Architektur

#### Klassendiagramm

**HIER KOMMT NOCH EIN BILD VOM FERTIGEN DIAGRAMM HIN!!!**

#### Klassendokumentation

In der Klassendokumentation werden die Klassen aus dem Diagramm noch ein Mal genauer Dokumentiert. Es wird erklärt für was sie zuständig sind und welche Felder, Eigentschaften und Methoden sie haben.

Die Klassendokumentation ist [auf dieser Seite](Klassen.md) vorzufinden.

## Entscheiden

### Welches DBMS?

Für diesen Anwendungszweck würde sich definitiv ein SQL-DBMS eignen.
Die Software muss zur Zeit nicht gross skaliert werden, da sie lokal laufen wird. Es werden auch immer wieder dieselben Daten verwendet, zum Beispiel die Konten aus dem Kontenrahmen. Diese Werte könnten möglicherweise in eine zugewiesene Tabelle.

Es gibt auch diverse SQL-DBMS, die sicher funktionieren würden. Am geignetsten wäre aber ganz sicher [SQLite](https://sqlite.org/index.html). Dieses DBMS, weil sie mit der Software geliefert werden kann und einfach gehalten ist. Der einzige Nachteil wäre die Untauglichkeit für Multiuser-Anwendungen, dies schränkt mich hier aber nicht ein.

## Realisieren

## Kontrollieren

### Testfazit

## Auswerten
