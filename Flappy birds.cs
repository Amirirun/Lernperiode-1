using System;
using System.Threading;

class Program
{
    static int vogelPosition;
    static int hindernisPosition;
    static int hindernisHoehe;
    static int punkte;
    static int spielfeldHoehe = 20;
    static int spielfeldBreite = 50;
    static bool spielLaeuft;

    static void Main(string[] args)
    {
        // Initiale Anweisungen
        Console.CursorVisible = false;
        Console.SetWindowSize(spielfeldBreite, spielfeldHoehe + 2);
        Console.SetBufferSize(spielfeldBreite, spielfeldHoehe + 2);

        // Start des Spiels
        StartSpiel();
    }

    static void StartSpiel()
    {
        // Initialisiere die Variablen für ein neues Spiel
        vogelPosition = spielfeldHoehe / 2; // Vogel startet in der Mitte des Spielfelds
        hindernisPosition = spielfeldBreite - 1; // Hindernis startet am rechten Rand
        hindernisHoehe = 5; // Initiale Höhe des Hindernisses
        punkte = 0;
        spielLaeuft = true;

        // Starte die Spiel-Schleife
        while (spielLaeuft)
        {
            SpielLogik();
            SpielfeldZeichnen();
            EingabeVerarbeiten();
            Thread.Sleep(100); // Geschwindigkeit des Spiels
        }

        // Nach Game Over automatisch neu starten
        Console.Clear();
        Console.WriteLine("Game Over! Dein Punktestand: " + punkte);
        Console.WriteLine("Drücke 'R', um neu zu starten...");

        // Warte auf die Eingabe 'R', um das Spiel neu zu starten
        while (Console.ReadKey(true).Key != ConsoleKey.R)
        {
        }

        // Spiel neustarten
        StartSpiel();
    }

    static void SpielLogik()
    {
        // Bewegung der Hindernisse
        hindernisPosition--;

        // Wenn das Hindernis den linken Rand erreicht, ein neues Hindernis erstellen
        if (hindernisPosition < 0)
        {
            hindernisPosition = spielfeldBreite - 1; // Hindernis erscheint wieder rechts
            hindernisHoehe = new Random().Next(3, spielfeldHoehe - 3); // Zufällige Höhe des Hindernisses
            punkte++; // Erhöhe den Punktestand, wenn das Hindernis passiert wurde
        }

        // Schwerkraft (Vogel fällt nach unten)
        vogelPosition++;

        // Kollision mit dem Boden oder Hindernis
        if (vogelPosition >= spielfeldHoehe || (hindernisPosition == 5 && (vogelPosition < hindernisHoehe || vogelPosition > hindernisHoehe + 3)))
        {
            spielLaeuft = false;
        }
    }

    static void SpielfeldZeichnen()
    {
        Console.Clear();

        // Zeichne den Vogel, überprüfe ob die Position gültig ist
        if (vogelPosition >= 0 && vogelPosition < spielfeldHoehe)
        {
            Console.SetCursorPosition(5, vogelPosition);
            Console.Write("O"); // Der Vogel wird als "O" dargestellt
        }

        // Zeichne das Hindernis, überprüfe die Positionen
        for (int i = 0; i < spielfeldHoehe; i++)
        {
            if ((i < hindernisHoehe || i > hindernisHoehe + 3) && hindernisPosition >= 0 && hindernisPosition < spielfeldBreite)
            {
                Console.SetCursorPosition(hindernisPosition, i);
                Console.Write("|"); // Hindernis wird als "|" dargestellt
            }
        }

        // Zeichne den Punktestand
        Console.SetCursorPosition(0, spielfeldHoehe + 1);
        Console.Write("Punkte: " + punkte);
    }

    static void EingabeVerarbeiten()
    {
        // Überprüfe, ob eine Taste gedrückt wurde
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo taste = Console.ReadKey(true);
            if (taste.Key == ConsoleKey.W)
            {
                vogelPosition -= 3; // Vogel fliegt nach oben, wenn "W" gedrückt wird
            }
        }
    }
}
