/*      Aufgabenstellung
                Schreiben Sie ein Programm, das zwei Zahlen einliest und anschließend mit Hilfe
                einer Switch-Anweisung ein Menü anbietet, in welchem der Benutzer zwischen
                den 4 Grundrechnungsarten wählen kann. Inkludieren Sie einen Menüpunkt für
                einen Abbruch des Programmes.

                Nach entsprechender Wahl soll der Anwender das Ergebnis (wenn mathematisch möglich)
                ausgegeben bekommen.

                Nach der Ausgabe der Berechnung soll das Programm automatisch von neuem starten.
*/
namespace TaschenrechnerAufSteroiden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
                    Taschenrechner        
                _______________________
                Macht das was ein Taschenrechner eben so macht.");
            /* Variablen
                 * double Datentypen werden zur leserlichkeit 
                 * in der selben Codezeile deklariert gleiches 
                 * gilt für string       
                 */
            double zahl1, zahl2, zahl3= 0, ergebnis= 0;
            string rechenart1, rechenart2= "";
            bool dritteZahlVorhanden= false;
            bool run= true;

            /* Hauptschleife
             * Solange run (steht für running) den bool 
             * Wert auf True beibehält
             * am ende unserer Rechnung folgt eine Abfrage 
             * Ob Client oder User Quitten möchte, wenn Ja dann
             * run != True demnach wird run = false;
             */
            while (run)
            {
                Console.Write(@"
                Geben Sie die erste Zahl ein:");
                while (!double.TryParse(Console.ReadLine(), out zahl1))
                {
                    Console.WriteLine("Nur Zahlen, bitte!");
                }
                Console.Write(@"
                Wählen sie einen Mathematischen Operator (+, -, *, /): ");
                rechenart1 = Console.ReadLine();

                Console.Write(@"
                Geben Sie die zweite Zahl ein: ");
                while (!double.TryParse(Console.ReadLine(), out zahl2))
                {
                    Console.WriteLine(@"
                Nur Zahlen, bitte!");
                }
                /* Eingabe der Rechenart2
                 * Abfrage ob Client 2 Rechenart wünscht?
                 * Wenn Ja dann Muss Client eingabe Ja oder J,j tätigen 
                 * alle drei optionen sind zulässig da wir für 
                 * Console.ReadLine().Trim().ToUpper() == "J" gesetzt haben 
                 * .Trim() Funktion damit Erster Buchstabe des Inputs verwendet wird
                 * .ToUpper() Funktion die String in Großbuchstaben konvertiert
                 * == "J" Vergleichoperator wenn inout des Clients == "J" dann Bedingung True
                 */
                Console.Write("Möchten Sie eine dritte Zahl mit einer weiteren Rechenart eingeben? (J/N): ");
                if(Console.ReadLine().Trim().ToUpper() == "J")
                {
                    Console.Write("Geben Sie die zweite Rechenart ein (+, -, *, /): ");
                    rechenart2 = Console.ReadLine();

                    Console.Write("Geben Sie die dritte Zahl ein: ");
                    while (!double.TryParse(Console.ReadLine(), out zahl3))
                    {
                        Console.WriteLine("Nur Zahlen, bitte!");
                    }
                    dritteZahlVorhanden = true;
                }

                // Berechnung unter Berücksichtigung der Operator-Priorität
                if (rechenart1 == "*" || rechenart1 == "/")
                {
                    switch (rechenart1)
                    {
                        case "*": ergebnis = zahl1 * zahl2; break;
                        case "/":
                            if (zahl2 != 0) ergebnis = zahl1 / zahl2;
                            else { Console.WriteLine("NO, NULL Senior NO DIVISION!!!"); continue; }
                            break;
                    }
                    if (dritteZahlVorhanden)
                    {
                        switch (rechenart2)
                        {
                            case "+": ergebnis += zahl3; break;
                            case "-": ergebnis -= zahl3; break;
                            case "*": ergebnis *= zahl3; break;
                            case "/":
                                if (zahl3 != 0) ergebnis /= zahl3;
                                else { Console.WriteLine("NO, NULL Senior NO DIVISION!!!"); continue; }
                                break;
                        }
                    }
                }
                else
                {
                    double zwischenergebnis = zahl1;
                    switch (rechenart1)
                    {
                        case "+": zwischenergebnis += zahl2; break;
                        case "-": zwischenergebnis -= zahl2; break;
                    }
                    if (dritteZahlVorhanden && (rechenart2 == "*" || rechenart2 == "/"))
                    {
                        switch (rechenart2)
                        {
                            case "*": ergebnis = zahl2 * zahl3; break;
                            case "/":
                                if (zahl3 != 0) ergebnis = zahl2 / zahl3;
                                else { Console.WriteLine("NO, NULL Senior NO DIVISION!!!"); continue; }
                                break;
                        }
                        ergebnis = (rechenart1 == "+") ? zahl1 + ergebnis : zahl1 - ergebnis;
                    }
                    else
                    {
                        ergebnis = zwischenergebnis;
                        if (dritteZahlVorhanden)
                        {
                            switch (rechenart2)
                            {
                                case "+": ergebnis += zahl3; break;
                                case "-": ergebnis -= zahl3; break;
                            }
                        }
                    }
                }

                switch (rechenart1)
                {
                    case "+": ergebnis = zahl1 + zahl2; break;
                    case "-": ergebnis = zahl1 - zahl2; break;
                    case "*": ergebnis = zahl1 * zahl2; break;
                    case "/":
                        if (zahl2 != 0) ergebnis = zahl1 / zahl2;
                        else Console.WriteLine("NO, NULL Senior!!!");
                        break;
                    default:
                        Console.WriteLine("NO Senior!!!");
                        continue;
                }

                if (dritteZahlVorhanden)
                {
                    switch (rechenart2)
                    {
                        case "+": ergebnis += zahl3; break;
                        case "-": ergebnis -= zahl3; break;
                        case "*": ergebnis *= zahl3; break;
                        case "/":
                            if (zahl3 != 0) ergebnis /= zahl3;
                            else Console.WriteLine("Fehler: Durch Null kann man nicht teilen!");
                            break;
                        default:
                            Console.WriteLine("NO Senior!!!");
                            continue;
                    }
                }
                /* Output        | und |   Abfrage 
                 * vom Ergebnis  |     |   ob Client weiterrechnen möchte
                 */
                Console.WriteLine(@$"
                        {zahl1} {rechenart1} {zahl2} {rechenart2} {zahl3} =
                        Ergebnis: {ergebnis}
                        _____________________
                        Möchten Sie den Rechner beenden?== Q für Beenden
                        beliebige Taste für Weiter");
                if (Console.ReadLine().Trim().ToUpper() == "Q")
                {
                    run = false;
                }
            }

        }
    }
}
