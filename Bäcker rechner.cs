
using System.Security.Cryptography;

double preisButterbroetchen = 1.50;
double preisBrezel = 1.20;
double preisBrot = 3.00;

double preis = 0.0;

Console.WriteLine("Was möchten Sie? Bitte wählen Sie zwischen: Butterbrötchen, Brezel, Brot");

string auswahl = Console.ReadLine(); 


if (auswahl == "Butterbrötchen")
{
    preis = preisButterbroetchen;
    Console.WriteLine("Sie haben Butterbrötchen gewählt.");
}
else if (auswahl == "Brezel")
{
    preis = preisBrezel;
    Console.WriteLine("Sie haben Brezel gewählt.");
}
else if (auswahl == "Brot")
{
    preis = preisBrot;
    Console.WriteLine("Sie haben Brot gewählt.");
}
else
{
    Console.WriteLine("Ungültige Auswahl, bitte wählen Sie zwischen: Butterbrötchen, Brezel oder Brot.");
    return; 
}


Console.WriteLine("Wie viele " + auswahl + " möchten Sie kaufen? Geben Sie hier eine Zahl zwischen 1 und 10 ein:");
string input = Console.ReadLine();
int zahl;

if (int.TryParse(input, out zahl))
{
    if (zahl >= 1 && zahl <= 10)
    {
        double gesamtpreis = preis * zahl; 
        Console.WriteLine("Sie haben " + zahl + " " + auswahl + "(n) gewählt.");
        Console.WriteLine("Der Gesamtpreis beträgt: " + gesamtpreis + " Euro.");
    }
    else
    {
        Console.WriteLine("Sie dürfen höchstens 10 Stück wählen.");
    }
}
else
{
    Console.WriteLine("Das ist keine gültige Zahl.");
}











