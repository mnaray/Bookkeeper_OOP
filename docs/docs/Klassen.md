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

### DbConnection

#### Zusammenfassung

Dise Klasse erstellt ein Singleton-Objekt. Somit kann immer und überall auf die Verbindung zur Datenbank zugegriffen werden. Es können auch nicht versehentlich zwei Verbindungen mit der Datenbank entstehen.

#### Superklasse

*keine*

#### Interfaces

*keine*

#### Felder

 - **private static DbConnection _instance**
   - Enthält eine statische Instanz von der eigenen Klasse.

#### Eigenschaften

*keine*

#### Methoden

- **private DbConnection()**
  - Ist der private Konstruktor, der das Singleton-Pattern ermöglicht.
  - Erstellt ein neues Objekt der Klasse DbConnection.
- **public static DbConnection GetInstance()**
  - Ruft den Konstruktor ab, falls *_instance* noch null ist.
  - Gibt das Objekt in *_instance* zurück.
- **public void ExecuteQuery(string query)**
  - Nimmt einen String als Parameter.
  - Durchgepasster Parameter wird über die Verbindung als SQL-Befehl ausgeführt.

#### Subklassen

*keine*

### Konto

#### Zusammenfassung

Die Klasse Konto ist eine abstrakte Superklasse für Passiv- und Aktivkonto. Diese Unterscheidung der Konten ist essentiell in der Buchhalten, sie haben aber trotzdessen viele Gemeinsamkeiten. Diese werden in dieser abstrakten Klasse vorgegeben.

#### Superklasse

*keine*

#### Interfaces

*keine*

#### Felder

- **private int _kontoId**
  - Beinhaltet die Kontonummer aus dem KMU-Kontenrahmen.
- **private string _kontoName**
  - Beinhaltet den Kontonamen aus dem KMU-Kontenrahmen.
- **private DbConnection _db**
  - Zeigt auf das Singleton-Objekt [DbConnection](#dbconnection).

#### Eigenschaften

- **public int KontoId { get; }**
  - Gibt die Kontennummer zurück.
  - Wert kann mehr nicht gesetzt werden.
- **public string Kontoname { get; }**
  - Gibt den Kontonamen zurück.
  - Wert kann mehr nicht gesetzt werden.

#### Methoden

- **public Konto(int kontoId, string kontoName)**
  - Ist der Konstruktor der Klasse.
  - Nimmt die Felder als Parameter an.
  - Setzt die Singleton-Instanz des [DbConnection-Objekts](#dbconnection) als Feld.
- **public abstract void TaetigeSollBuchung(decimal betrag)**
  - Ist abstrakt, wird erst in einer Subklasse implementiert.
- **public abstract void TaetigeHabenBuchung(decimal betrag)**
  - Ist abstrakt, wird erst in einer Subklasse implementiert.
- **public abstract decimal BerechneSaldo()**
  - Führt eine Abfrage der Datenbank über die Buchungssätze aus.
  - Verrechnet die jeweiligen Soll- und Haben-Buchungen.
  - Gibt den aktuellen Saldo des Kontos aus.

#### Subklassen

- [AktivKonto](#aktivkonto)
- [PassivKonto]

### AktivKonto

#### Zusammenfassung

Diese Klasse stammt von [Konto](#konto) ab. Sie implementiert die Funktionen eines Aktivkontos in der Buchhaltung.

#### Superklasse

- [Konto](#konto)

#### Interfaces

*keine*

#### Felder

- **private int _kontoId**
  - Beinhaltet die Kontonummer aus dem KMU-Kontenrahmen.
- **private string _kontoName**
  - Beinhaltet den Kontonamen aus dem KMU-Kontenrahmen.
- **private DbConnection _db**
  - Zeigt auf das Singleton-Objekt [DbConnection](#dbconnection).

#### Eigenschaften

- **public int KontoId { get; }**
  - Gibt die Kontennummer zurück.
  - Wert kann mehr nicht gesetzt werden.
- **public string Kontoname { get; }**
  - Gibt den Kontonamen zurück.
  - Wert kann mehr nicht gesetzt werden.

#### Methoden

- **public AktivKonto(int kontoId, string kontoName)**
  - Ist der Konstruktor der Klasse.
  - Gibt die Parameter an den Base-Konstruktor (von [Konto](#konto)) weiter.
- **public void TaetigeSollBuchung(decimal betrag)**
  - Erhöht den Saldo des Kontos.
  - (Erst zu implementieren, wenn Saldo in der DB gespeichert wird.)
- **public void TaetigeHabenBuchung(decimal betrag)**
  - Verringert den Saldo des Kontos.
  - (Erst zu implementieren, wenn Saldo in der DB gespeichert wird.)
- **public decimal BerechneSaldo()**
  - Führt eine Abfrage der Datenbank über die Buchungssätze aus.
  - Verrechnet die jeweiligen Soll- und Haben-Buchungen.
  - Gibt den aktuellen Saldo des Kontos aus.

#### Subklassen

*keine*

### PassivKonto

#### Zusammenfassung

Diese Klasse stammt von [Konto](#konto) ab. Sie implementiert die Funktionen eines Passivkontos in der Buchhaltung.

#### Superklasse

- [Konto](#konto)

#### Interfaces

*keine*

#### Felder

- **private int _kontoId**
  - Beinhaltet die Kontonummer aus dem KMU-Kontenrahmen.
- **private string _kontoName**
  - Beinhaltet den Kontonamen aus dem KMU-Kontenrahmen.
- **private DbConnection _db**
  - Zeigt auf das Singleton-Objekt [DbConnection](#dbconnection).

#### Eigenschaften

- **public int KontoId { get; }**
  - Gibt die Kontennummer zurück.
  - Wert kann mehr nicht gesetzt werden.
- **public string Kontoname { get; }**
  - Gibt den Kontonamen zurück.
  - Wert kann mehr nicht gesetzt werden.

#### Methoden

- **public AktivKonto(int kontoId, string kontoName)**
  - Ist der Konstruktor der Klasse.
  - Gibt die Parameter an den Base-Konstruktor (von [Konto](#konto)) weiter.
- **public void TaetigeSollBuchung(decimal betrag)**
  - Verringert den Saldo des Kontos.
  - (Erst zu implementieren, wenn Saldo in der DB gespeichert wird.)
- **public void TaetigeHabenBuchung(decimal betrag)**
  - Erhöht den Saldo des Kontos.
  - (Erst zu implementieren, wenn Saldo in der DB gespeichert wird.)
- **public decimal BerechneSaldo()**
  - Führt eine Abfrage der Datenbank über die Buchungssätze aus.
  - Verrechnet die jeweiligen Soll- und Haben-Buchungen.
  - Gibt den aktuellen Saldo des Kontos aus.

#### Subklassen

*keine*

### Buchungssatz

#### Zusammenfassung

Diese Klasse beinhaltet beschreibt, wie ein Buchungssatz beinhaltet (siehe UML für mehr Details). Er kann auch ausgeführt werden, damit ein neuer Eintrag in der Datenbank entsteht. Wenn nötig, können die Daten aus der entsprechenden Tabelle in dieses Objekt eingefügt werden.

#### Superklasse

*keine*

#### Interfaces

*keine*

#### Felder

- **private int? _id**
  - Beinhaltet die ID in der Datenbank, falls diese schon vorhanden ist.
  - Wenn neuer Buchungssatz, dann null. Datenbank vergibt automatisch eine ID.
- **private string _buchungstext**
  - Ein kleiner Buchungstext, der Informationen zur dazugehörigen Buchung beinhaltet.
- **private int _buchungsdatum**
  - Datum der Buchung.
  - Wird im Unix-Timestamp Format in der DB gespeichert.
- **private Konto _sollKonto**
  - Ein [Konto-Objekt](#konto) im Soll der Buchung
- **private Konto _habenKonto**
  - Ein [Konto-Objekt](#konto) im Haben der Buchung
- **private decimal _betrag**

#### Eigenschaften

- **public int? Id**
  - Gibt die ID in *_id* zurück, falls diese nicht null ist.
- **public string Buchungstext**
  - Gibt den Buchungstext zurück.
- **public Konto SollKonto**
  - Gibt das Soll-Konto der Buchung zurück.
- **public Konto HabenKonto**
  - Gibt das Haben-Konto der Buchung zurück.
- **public decimal Betrag**
  - Gibt den Betrag der Buchung zurück.

#### Methoden

- **public Buchungssatz()**
  - Ist der Konstruktor der Klasse.
- **public void Ausführen**
  - Führt die Buchung aus.
  - Erstellt einen Eintrag in der Datenbank.

#### Subklassen

*keine*

## View Namespace

## Controller Namespace
