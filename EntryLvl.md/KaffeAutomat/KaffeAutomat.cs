using System;
using System.Xml;
using System.Threading;
using System.Collections.Generic;
using System.Text.Json; // Damit man in C# 
using Newtonsoft.Json; // Damit man Wie bei Python Json dateien erstellen und auslesen kann 
/* Aufgabenstellung:
   Programmiere einen Kaffeautomaten
   Der Kaffeautomat hat eine bestimmte Menge Wasser, eine bestimmte Bohnen 
   Der Tank sowohl für Bohnen als auch für Wasser hat eine Maximale größe
   Die Kaffemaschine hat ein Menü wo man einen Kafee zubereiten kann
   Bei der Umsetzung eines Kaffes wird eine bestimmte Menge an Bohnen und an Wasser verbraucht
   Wenn Bohnen oder wasser nicht mehr ausreichen wird man dazu aufgefordert entsprechend Bohnen oder Wasser neu aufzufüllen
   Nach 30 Kaffeausgaben soll die maschine um eine Entkalkung bitten.
   Über das menü kann man ebenfalls die anzahl der Kaffes, das nachfühlen von zutaten und die letzten entkalkungen einsehen (diese sollen untereinander aufgelsitet werden)
   Nutze dafür, Arrays , Dictionarys und Schleifen um die Aufgabe umzusetzten
   Informiere dich über Thread.sleep() +  DateTime
   Die Historie soll in eine Json gespeichert werden
 */
namespace KaffeeAutomat
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Dictionary<string, int> gerätDetails = new Dictionary<string, int>
                {
                    { "Wassertank", 2000 },
                    { "Bohnenstand", 1000 },
                    { "Menge200", 200 },
                    { "Menge500", 500 },
                    { "Menge650", 650 },
                    { "Intensität1", 1 },
                    { "Intensität2", 2 },
                    { "Intensität3", 3 },
                    { "Intensität4", 4 },
                    { "Auswahl-Kaffee", 1 },
                    { "Auswahl-Schokolade", 2 }
                };   // Ende der Code- "Zeilen" Anweisung  durch Semikolon

                int kaffeAusgaben =0 ;
                List<DateTime> entkalkungWartung = new List<DateTime>();
                List<DateTime> bohnenWartung = new List<DateTime>();
                List<DateTime> wasserWartung = new List<DateTime>();

                bool run = true;
                do
                {
                    Console.WriteLine(@"
                    Bitte wählen Sie ein Programm 1 für Trinkschokolade oder 2 für Kaffee oder '0' zum Beenden:
                    1
                    ");
                    int.TryParse(Console.ReadLine(), out int input);

                    switch (input)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("System fährt herunter..");
                            for (int i = 3; i > 0; i--)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("...." + i + "...");
                            }
                            run = false;
                            break;

                        case 1:
                        Console.WriteLine("" +
                           "Getränke Auswahl:\t Trinkschokolade" +
                           "Auswahl der gebrühten\t ml (1: 200 ml, 2: 500 ml, 3: 650 ml):");
                        int.TryParse(Console.ReadLine(), out int userAuswahlMenge);
                        int menge = userAuswahlMenge switch   // Dieser Switch ausdruck beinhaltet Vertiefungsinhalte er hat mehrere Lamdafunktionen er übergibt keine werte !!! sondern führt eine Aktion durch 
                        {
                            1 => gerätDetails["Menge200"],
                            2 => gerätDetails["Menge500"],
                            3 => gerätDetails["Menge650"],
                            _ => 0
                        };
                        if (menge > 0 && menge <= gerätDetails["Wassertank"])
                        {
                            Console.WriteLine("Brühvorgang startet");
                            for (int i = 0; i < 3; i++)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("..." + i + "...");
                            }
                            Console.WriteLine("Vorgang abgeschlossen");
                            gerätDetails["Wassertank"] -= menge;
                            kaffeAusgaben++;

                            // Wartungslogik
                            if (kaffeAusgaben >= 30)
                            {
                                Console.WriteLine("Bitte entkalken Sie die Maschine.");
                                entkalkungWartung.Add(DateTime.Now);
                                kaffeAusgaben = 0;
                            }

                            if (gerätDetails["Wassertank"] <= 0)
                            {
                                Console.WriteLine("Wassertank ist leer. Bitte Wasser nachfüllen.");
                                wasserWartung.Add(DateTime.Now);
                                gerätDetails["Wassertank"] = 2000; // Annahme: Wassertank wird nachgefüllt
                            }

                            if (gerätDetails["Bohnenstand"] <= 0)
                            {
                                Console.WriteLine("Bohnenstand ist leer. Bitte Bohnen nachfüllen.");
                                bohnenWartung.Add(DateTime.Now);
                                gerätDetails["Bohnenstand"] = 1000; // Annahme: Bohnen werden nachgefüllt
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nicht genug Wasser im Wassertank. Bitte Nachfüllen und Vorgang wiederholen.");
                            wasserWartung.Add(DateTime.Now);
                        }
                        break;
                        case 2:
                            Console.WriteLine("" +
                                "Getränke Auswahl:\t Trinkschokolade" +
                                "Auswahl der gebrühten\t ml (1: 200 ml, 2: 500 ml, 3: 650 ml):");
                            int.TryParse(Console.ReadLine(), out  userAuswahlMenge);
                            menge = userAuswahlMenge switch
                            {
                                1 => gerätDetails["Menge200"],
                                2 => gerätDetails["Menge500"],
                                3 => gerätDetails["Menge650"],
                                _ => 0
                            };

                            if (menge > 0 && menge <= gerätDetails["Wassertank"])
                            {
                                Console.WriteLine("Brühvorgang startet");
                                for (int i = 0; i < 3; i++)
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine("..." + i + "...");
                                }
                                Console.WriteLine("Vorgang abgeschlossen");
                                gerätDetails["Wassertank"] -= menge;
                                kaffeAusgaben++;

                                if (kaffeAusgaben >= 30)
                                {
                                    Console.WriteLine("Bitte entkalken Sie die Maschine.");
                                    entkalkungWartung.Add(DateTime.Now);
                                    kaffeAusgaben = 0;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nicht genug Wasser im Wassertank. Bitte Nachfüllen und Vorgang wiederholen.");
                            }
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Ungültige Eingabe. System fährt herunter..");
                            for (int i = 3; i > 0; i--)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("...." + i + "...");
                            }
                            run = false;
                            break;
                    }
                string entkalkungJson = JsonConvert.SerializeObject(entkalkungWartung, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText("entkalkungWartung.json", entkalkungJson);

                string bohnenWartungJson = JsonConvert.SerializeObject(bohnenWartung, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText("bohnenWartung.json", bohnenWartungJson);

                string wasserWartungJson = JsonConvert.SerializeObject(wasserWartung, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText("wasserWartung.json", wasserWartungJson);
            } while (run);
            }
        }
    }
