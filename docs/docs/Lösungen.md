---
sidebar_position: 3
Title: Lösungen
---

# Lösungen

## Bruteforce
Ein Brute-Force-Angriff ist eine Angriffsmethode bei der durch Ausprobieren (Trial and Error, Versuch und Irrtum) versucht wird, um verschlüsselte Daten wie Passwörter oder Schlüssel durch „rohe Gewalt“ zu entschlüsseln, anstatt intellektuelle Strategien anzuwenden. In diesem Teil unseres Spiels war es deine Aufgabe diese Methode anzuwenden. Wie du das angegangen bist ist deine Entscheidung gewesen. Wir haben dir empfohlen ein Code zu schreiben, der die Arbeit des Enschlüsselns für dich übernimmt. Hier ist unsere Lösung:

### Erklärung

Das untenstehende Script geht alle möglichen Zahlenkombinationen (0 - 9999) durch, bis das Passwort erraten worden ist. Wenn die Zahlenkombination korrekt ist, wird die Zahlenkombination ausgegeben. Wenn die Zahlenkombination nicht korrekt ist, wird der Vorgang wiederholt.

Es wird openssl mit der Methode aes-256-cbc verwendet. Bei jeder Iteration wird eine höhere Zahl alls passphrase eingegeben. Sobald das entschlüsselte Resultat im Format der gewünschten Flagge ist, wird die Schleife gestoppt und die entschlüsselte Datei mit der Flagge in `out.txt` gespeichert.

:::note

Jedes Mal, wenn der Container gestartet wird, ändert sich die Zahlenkombination. Nur weil ein Mal eine Kombination funktioniert hat, wird sie ein anderes Mal nicht dieselbe sein.

:::

### Script

```bash title="solution.sh"
for n in $(seq 10000); do
    i=$(($n - 1))
    DECRYPTED=$(cat flag.txt.enc | openssl aes-256-cbc -d -a -pass pass:$i)
    if [ $DECRYPTED == "flag{bruteforce_challenge}" ]; then
        echo "The pin is: $i"
        echo $DECRYPTED >out.txt
        break
    else
        echo "Wrong password: $i"
    fi
done
```

Dieses Script muss sich in der gleichen Directory befinden wie `flag.txt.sh`. Im Normalfall müssen noch Rechte and die Datei ausgeteilt werden, damit diese ausgeführt werden kann. (`chmod +x meineDatei.bsp`)

:::caution

Bitte beachten, dass dieses Script nicht in BASH, sondern in ASH geschrieben ist. Das ist die Shell für die Alpine distribution.

:::


## SQL injection
Bei einer SQL-Injection (kurz SQLi) nutzen Cyberkriminelle gezielt Sicherheitslücken im Quelltext von Software aus, um etwa über Eingabemasken eigene Befehle oder Schadcode in Programme einzubinden. Auf diese Weise gelangen Angreifer an wertvolle Datensätze.

### Erklärung

Bei einem Eingabefeld, welches anfällig für SQL-Injection ist, wird normalerweise der Inhalt vom Feld in einer Variable gespeichert. Diese Variable wird dann direkt in den String, welcher die Query enthaltet verkettet (concatenate). Deshalb kann man mit ein wenig Geschick eine Eingabe machen, welche Teile eines SQL Befehls beinhaltet.

Das eingegebene wird so mit in die Query genommen und von der Datenbank ausgeführt. So kann man Abfrageresultate oder sogar den Datenbestand manipulieren.

Um dieses Level lösen zu können, musst du der Anleitung Schritt für Schritt folgen. Erst wenn du dir sicher bist, dass du alle wichtigen Dateien und Informationen hast, kannst du loslegen.

Um das Passwort umgehen zu können, musstest du die Injection im Passwortfeld anwenden. Der Benutzernme ist "admin". Im Passwortfeld musst du folgende Query eingeben: 'OR' 1'='1

Weil die Eingabe des Korrekten Passworts ein true von der Datenbnank zurückschickt, ist es dem Benutzer möglich sich einzuloggen. Diese Abfrage trickt die Datenbank aus, mit dem Schlüsselbefehl OR 1=1. Das Funktioniert, weil das OR 1=1 ein true zurückgibt, weil 1=1 ist. Somit ist es dir (dem Angreifer) möglich sich anzumelden.

Die Eingabe deiser Query löst die folgende Abfrage aus:

```sql
SELECT username, password FROM users
WHERE username = '[Eingabe Nutzername]'
HAVING password = '[Eingabe Passwort]';
```

### Eingaben

Username:

```
admin
```

Password:

```
' OR '1'='1
```

Lösungsquery, welche im Hintergrund dann ausgeführt wird:

```sql
SELECT username, password FROM users
WHERE username = 'admin'
HAVING password = '' OR '1'='1';
```
