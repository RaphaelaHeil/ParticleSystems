Hinzufügen eines neuen Partikelsystems: 

1) Anlegen einer neuen Klasse, die von ParticleSystem.cs erbt
2) Sollte spezieller Userinput benötigt werden, kann ein Steuerelement vom ParticleSystemSettingsPanel abgeleitet und entsprechend designt werden (siehe unten)
	2.1) Überschreiben der GetParticleSystemSettingsPanel() Methode im neuen ParticleSystem 
3) Implementieren der ParticleSystem Methoden, ggf. unter Verwendung von Daten aus dem implementierten ParticleSystemSettingsPanel
4) Hinzufügen des neuen ParticleSystems zur Anwendung //TODO 


Anlegen eines neuen ParticleSystemSettingsPanel:

1) Bitte keine Änderungen direkt am ParticleSystemSettingsPanel vornehmen!
2) Erstellen einer neuen Klasse im Projekt 
3) Hinzufügen der Ableitung vom ParticleSystemSettingsPanel, z.B.: "class TestPanel : ParticleSystemSettingsPanel {...}"
4) Aufrufen der grafischen Designoberfläche: Rechtsklick auf der neu erstellten Klasse -> Ansicht Desgner wählen oder Shift+F7 drücken
5) Die Größe des Panels sollte beibehalten werden, damit es ohne Probleme automatisch in die restliche Anwendung eingefügt werden kann. 