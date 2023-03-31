---
sidebar_position: 2
Title: Anleitungen
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';
import Admonition from '@theme/Admonition';

# Anleitungen

### Installation

Damit das Spiel auf jenem Computer spielbar ist, müssen zuerst gewisse Programme auf dem System vorhanden sein und manche Einstellungen konfiguriert werden.

Zu diesen Programmen gehören [Docker](https://www.docker.com/) und bei Windows noch das [WSL](https://en.wikipedia.org/wiki/Windows_Subsystem_for_Linux). Unten wird beim jeweiligen Tab für Windows, MacOS und Linux erklärt, wie man die benötigten Dinge installiert.

<Tabs
    defaultValue="windows"
    groupId="operatingSystems"
    values={[
        {label: 'Windows', value: 'windows'},
        {label: 'MacOS', value: 'macos'},
        {label: 'Linux', value: 'linux'},
    ]}>
<TabItem value="windows">
    <p>
        Für Windows muss man sich zuerst das Windows Subsystem for Linux installieren, da Docker dieses auf dem System benötigt, um laufen zu können. Wie dies gemacht wird, ist in der <a href="https://learn.microsoft.com/en-us/windows/wsl/install" >offiziellen Dokumentation von Microsoft ersichtlich</a>.<br/>
        Dabei muss man beachten, dass man die <strong>Version 2</strong> installiert, da die Version 1 nicht von Docker verwendet werden kann.
    </p>
    <p>
        Nachdem das WSL erfolgreich installiert wurde, kann man Docker Desktop installieren. Für dies gibt es auch eine <a href="https://docs.docker.com/desktop/install/windows-install/">offizielle Anleitung von Docker</a>. Diese soll wieder befolgt werden. Sobald alles installiert ist, können die weiteren Anleitungen (unten) für das Spiel befolgt werden, um fortzufahren.
    </p>
</TabItem>
<TabItem value="macos">
    <p>
        Für MacOS muss nur Docker Desktop installiert werden. Es gilt zu beachten, dass es zwei separate Anleitungen gibt. Die einte ist für Geräte mit einer Intel-CPU, die andere für Geräte, welche schon eine Apple silicon CPU haben.
    </p>
    <p>
        Am einfachsten kann man herausfinden, welche CPU man hat, indem man eine kurze Internetrecherche über das Modell des Geräts durchführt.<br/>
        Sobald man weiss, ob man nun eine Intel- oder Apple silicon CPU hat, kann man sich über die Installation von Docker Desktop für MacOS bei der <a href="https://docs.docker.com/desktop/install/mac-install/">offiziellen Anleitung von Docker</a> informieren. Sobald alles installiert ist, können die weiteren Anleitungen (unten) für das Spiel befolgt werden, um fortzufahren.
    </p>
</TabItem>
<TabItem value="linux">
<p>
    Bei Linux sieht die ganze Sache ein wenig anders aus, als bei Windows und MacOS. Man braucht theoretisch kein Docker Desktop, sondern nur die Docker Engine (welche bein Docker Desktop mit inbegriffen ist). Es gibt zwar eine Version von <a href="https://docs.docker.com/desktop/install/linux-install/">Docker Desktop für Linux</a>, diese ist aber für unseren Usecase nicht relevant, da es einfacher ist die Befehle aus dieser Anleitung zu kopieren.
</p>
<p>
    Bei Bedarf, kann Docker Desktop installiert werden, aber wir empfehlen die folgenden Befehle einzugeben, um nur die Docker Engine zu installieren.
</p>
<div>
    <Admonition type="info">
        <p>
            Die folgenden Befehle sind mit einem Package Manager namens <a href="https://ubuntu.com/server/docs/package-management">Advance Packaging Tool (apt)</a> und <a href="https://de.wikipedia.org/wiki/Bash_(Shell)">BASH</a> vorgezeigt. Um einen anderen Package Manager zu verwenden, ist eigenständige Recherche benötigt. (Der Ablauf ist jedoch ähnlich und das Resultat praktisch überall gleich.)
        </p>
    </Admonition>
</div>
<p>

Um allfällige, bisher installierte Versionen von Docker zu entfernen:
```bash
sudo apt-get remove docker docker-engine docker.io containerd runc
```

</p>
<p>

Updates am Package Manager durchführen
```bash
sudo apt-get update
```

</p>
<p>

Aktuellste Version von Docker installieren:
```bash
sudo apt-get install docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin
```

</p>
<p>

Testen, ob Docker richtig installiert wurde:
```bash
sudo docker run hello-world
```

</p>
<p>

Wenn folgende (oder ähnliche) Nachricht ausgegeben wird, ist alles in Ordnung. Das Spiel kann angefangen werden.
```
Hello from Docker!
This message shows that your installation appears to be working correctly.

To generate this message, Docker took the following steps:
 1. The Docker client contacted the Docker daemon.
 2. The Docker daemon pulled the "hello-world" image from the Docker Hub.
    (amd64)
 3. The Docker daemon created a new container from that image which runs the
    executable that produces the output you are currently reading.
 4. The Docker daemon streamed that output to the Docker client, which sent it
    to your terminal.

To try something more ambitious, you can run an Ubuntu container with:
 $ docker run -it ubuntu bash

Share images, automate workflows, and more with a free Docker ID:
 https://hub.docker.com/

For more examples and ideas, visit:
 https://docs.docker.com/get-started/
```

</p>
</TabItem>
</Tabs>

## Bruteforce

### Aufgabenstellung

Das Ziel ist, die Flagge zu finden. Diese sieht so aus: flag{bruteforce_challenge}
Um an die Flagge heranzukommen, muss ein Pin zwischen 0 und 9999 gefunden werden. Deine Aufgabe ist es dies zu tun, indem du eine Bruteforce-Methode anwendest.

Das Level ist überwunden, wenn folgende Flagge gefunden wurde:  
`flag{bruteforce_challenge}`

Zusätzliche Informationen:
- Es wurde **OpenSSL** zum Verschlüsseln der Flagge verwendet.
- **aes-256-cbc** wurde als Methode genommen.
- Der Pin muss nicht unbedingt vierstellig sein.
- Das zu entschlüsselnde File befindet sich im Filesystem des Containers unter */home/root*
- Es wird **nicht** BASH im Container verwendet, sondern die **Alpine Shell**.
- Vergiss nicht Rechte an auszuführende Dateien auszuteilen! (`chmod +x meineDatei.bsp`)

Um zu starten:

```bash
docker run -it --name ash mnaray/bruteforce:latest
```

### Hilfestellungen

<details><summary>1. Hinweis</summary>
<p>
Bei der Verwendung vom openssl-Befehl ist zu beachten, dass die Ver- und Entschlüsselung auf einer binären Ebene geschieht. Damit du das Resultat dann auch lesen kannst, muss <code>-a</code> im Befehl verwendet werden. Dies en(t)kodiert die Ausgabe zu Base-64.
</p>
</details>

<details><summary>2. Hinweis</summary>
<p>
Schau auf den Namen dieser Aufgabenstellung. Was ist der Titel? Google was es ist. Vergiss nicht, dass der geheime Pin sich zwischen 0 und 9999 befindet.
</p>
</details>

<details><summary>3. Hinweis</summary>
<p>
Am schnellsten geht es, ein Script zu schreiben, welches die Arbeit vom Ausprobieren aller Optionen für dich übernimmt. Es muss aber nicht unbedingt ein Script sein, es gibt sonst auch noch viele Bibliotheken und Tools, mit denen so etwas gemacht werden kann.
</p>
<p>
Hier ist es einfacher ein kurzes Script zu schreiben, da es nur 10000 mögliche Kombinationen für den Code gibt. In einer Situation, in der es vielleicht sogar milliarden von Optionen gibt, ist z.B. ein Bruteforcing-Tool empfehlenswert.
</p>
</details>

## SQL-Injection

### Aufgabenstellung

Das Ziel ist, die Flagge zu finden. Diese sieht so aus: flag{sql_injection_challenge}
Um an die Flagge heranzukommen muss das Login via einer SQL-Injection umgangen werden.

Das Level ist überwunden, wenn folgende Flagge gefunden wurde:
`flag{sql_injection_challenge}`

Zusätzliche Informationen:
- Es darf nicht mit einer direkten auf die Datenbank zugegriffen werden.
- Du sollst dich als "admin" einloggen.
- Das Passwort soll nicht geraten werden. Es gilt das Login zu umgehen.
- Es laufen zwei Container in einem Netzwerk; die Datenbank und die Node-Laufzeit (Webserver)
- Die Container müssen mit `docker-compose` gestartet werden.

Um zu starten:

Erstelle eine Datei mit dem Namen `docker-compose.yaml`.  
In diese Datei sollst du folgenden Inhalt einfügen:

```yml
version: '3.8'

services:
  database:
    image: mnaray/sql_injection_db:latest
    container_name: usersdb
    restart: always
    environment:
      - MYSQL_ALLOW_EMPTY_PASSWORD=true

  server:
    image: mnaray/sql_injection_server:latest
    container_name: server
    restart: always
    depends_on:
      - database
    links:
      - database
    ports:
      - "80:80"
```

Sobald du den Inhalt eingefügt hast, navigiere mit der Kommandozeile an den Ort der Datei.  
Dort sollst du folgenden Befehl ausführen:

```bash
docker-compose up -d
```

Es kann ein wenig dauern bis alles ausgeführt wurde, wenn du die Dockerimages noch nicht auf deinem Gerät hast. Das ist nicht schlimm, es wird alles automatisch heruntergeladen und installiert, wenn der Inhalt von der docker-compose-Datei stimmt.

Wenn alles vollständig hochgefahren ist, kannst du nun einen beliebigen Browser öffnen und `http://localhost` als URL eingeben. Es soll sich eine einfache Loginseite öffnen, welche der Startpunkt der Challenge ist. Dort kannst du dann versuchen, das Login zu umgehen und dich als "admin" anzumelden.

### Hilfestellungen

<details><summary>1. Hinweis</summary>
<p>
Weisst du was SQL-Injection ist? Falls nicht, dann sollst du dich kurz informieren und versuchen die gefundenen Informationen im nächsten Schritt anzuwenden.
</p>
<p>
Schreibe dir eine Query auf, die möglicherweise verwendet wird, um die Datenbank nach den Logindaten abzufragen. Wie kannst du nun diese Query mit (zum Beispiel) den Eingabefeldern manipulieren?
</p>
</details>

<details><summary>2. Hinweis</summary>
<p>
Die eigentliche Injection findet hier im Passwortfeld statt. Der Nutzername soll "admin" sein.
</p>
</details>

<details><summary>3. Hinweis</summary>
<p>

Die Query im für das Loginfenster sieht so aus:<br/>
```sql
SELECT username, password FROM users
WHERE username = '[Eingabe Nutzername]'
HAVING password = '[Eingabe Passwort]';
```

</p>
</details>
