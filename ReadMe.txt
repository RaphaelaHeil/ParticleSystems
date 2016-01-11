Hinzufügen eines neuen Partikelsystems (Beispiel: s. LinearUpdatingParticleSystem)

1) Anlegen einer neuen Klasse im Ordner <ParticleSystems>, die von ParticleSystem.cs erbt
	--> class NAME:ParticleSystem{...}

2) Sollte spezieller Userinput benötigt werden, kann ein Steuerelement vom ParticleSystemSettingsPanel abgeleitet und entsprechend designt werden (siehe unten)
	2.1) Idealerweise sollte eine Instanz des neuen Panels im Defaultkonstruktor dem Feld "Panel" zugewiesen werden, sodass dieses später verwendet werden kann,
		um die Eingabewerte auszulesen.

3) Implementieren der ParticleSystem Methoden, ggf. unter Verwendung von Daten aus dem implementierten ParticleSystemSettingsPanel

4) Hinzufügen des neuen ParticleSystems zur Anwendung
	--> s. Info in der Klasse ParticleSystemRegistration


Anlegen eines neuen ParticleSystemSettingsPanel (Beispiel: s. TestPanel)

1) Bitte keine Änderungen direkt am ParticleSystemSettingsPanel vornehmen, da dies Auswirkungen auf die Panels von allen anderen Partikelsystem haben kann.

2) Erstellen einer neuen Klasse im Ordner <SettingsPanels>

3) Hinzufügen der Ableitung vom ParticleSystemSettingsPanel
	--> z.B.: class NAME : ParticleSystemSettingsPanel {...}

4) Aufrufen der grafischen Designoberfläche: Rechtsklick auf der neu erstellten Klasse -> Ansicht Desgner wählen oder Shift+F7 drücken

HINWEIS: Die Größe des Panels sollte beibehalten werden, damit es ohne Probleme automatisch in die restliche Anwendung eingefügt werden kann. 
Um sicherzustellen, dass tatsächlich die gleiche Größe verwendet wird kann als vorletzter Aufruf in InitializeComponents (vor PerformLayout) "this.Size = base.Size;" verwendet werden. 
Die Größenänderung wird dann auch direkt auf den Designer übertragen/dort angezeigt.