---
sidebar_position: 2
Title: Klassendokumentation
---
:::note

Dies ist die Klassendokumentation der Klassen im Quellcode. Für jede Klasse werden folgende Punkte dokumentiert.

- **Klassentitel**
- *Kurze* Zusammenfassung vom Sinn und Zweck
- Die Superklasse (Elternklassen), falls vorhanden
- Liste aller implementierten Interaces, falls vorhanden
- Alle Felder, Eigenschaften und Methoden
- Liste aller Subklassen

:::

## Bookkeeper Namespace

:::caution

Dieses Namespace ist nur für die Initialisierung des Programms vorgesehen. Es soll nur die [Entrypoint-Klasse](#entrypoint) beinhalten und keine andere. Unter anderem darf das *setup.sql* auch hier gespeichert werden.

:::

### Entrypoint

#### Zusammenfassung

Diese Klasse ist für die Initialisierung des eigentlichen Programms zuständig. Sie stellt auch noch sicher, dass die Datenbank vorhanden und zum Gebrauch bereit ist.

#### Superklasse

*keine*

#### Interfaces

*keine*

#### Felder

*keine*

#### Eigenschaften

*keine*

#### Methoden

- **static void Main(string[] args)**
   - Führt SetupDB() aus.
   - Startet die eigentliche Anwendung.
- **private static void SetUpDB()**
   - Erstellt DB, wenn nötig.
   - Führt bei neuer DB ExecuteScript() aus.
- **private static void ExecuteScript(SQLiteConnection connection)**
   - Erstellt einen SQL-Befehl und führt diesen über die angegebene Verbindung aus.

#### Subklassen

*keine*

## Model Namespace

## View Namespace

## Controller Namespace
