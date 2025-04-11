namespace wekckerZeit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Musterlösung von Miachael Lutz ====");

            Console.Write("Stelle deinen Wecker im Format \"HH:mm:ss\" ");
            string weckZeit= Console.ReadLine()??"";


            int weckerStunden = char.IsDigit(weckZeit[0]) && char.IsDigit((char)weckZeit[1]) ? int.Parse("" + weckZeit[0] + weckZeit[1]) : -1;
            int weckerMinuten = char.IsDigit(weckZeit[3]) && char.IsDigit((char)weckZeit[4]) ? int.Parse("" + weckZeit[3] + weckZeit[4]) : -1;
            int weckerSekunden = char.IsDigit(weckZeit[6]) && char.IsDigit((char)weckZeit[7]) ? int.Parse("" + weckZeit[6] + weckZeit[7]) : -1;

            if (weckZeit.Length > 8 || weckZeit.Length < 8  ||  // WeckerZeit.Length bestimmt die länge  unseres User eingabe Strings  in länge zwichen größer 8 und kleiner 8 !!! also werden dann die ersten 8 Strings des User Inputs entnommen
                 weckerStunden  < 0 || weckerStunden   > 23 ||     // Stunden zwischen  größer <0 , und kleiner > 23
                 weckerMinuten  < 0 || weckerMinuten   > 60 ||     // Minuten zwischen  gr <0 , kl >60
                 weckerSekunden < 0 || weckerSekunden  > 60)     // Sekunden zwischen gr <0 , kl >60
            {
                Console.WriteLine(@$"
                                    Fehlerhafte Uhrzeit.
                                    _____________________________________
                                    Aktion konnte nciht ausgeführt werden
                                                                            ");
            }
            else 
            {
                Console.WriteLine("Wecker gestellt auf "+weckZeit); Thread.Sleep(1000);           
          
            }
            string aktuelleZeit = DateTime.Now.ToString("HH:mm:ss");
            int stunden = int.Parse(""  + aktuelleZeit[0] + aktuelleZeit[1]);
            int minuten = int.Parse(""  + aktuelleZeit[3] + aktuelleZeit[4]);
            int sekunden = int.Parse("" + aktuelleZeit[6] + aktuelleZeit[7]);
            while (true)
            {
                if (stunden == weckerStunden && minuten == weckerMinuten && sekunden == weckerSekunden) break;

                Console.Clear();
                string stundenStr = stunden > 9 ? stunden.ToString() : "0" + stunden;
                string minutenStr = minuten > 9 ? minuten.ToString() : "0" + minuten;
                string sekundenStr = sekunden > 9 ? sekunden.ToString() : "0" + sekunden;

                System.Console.WriteLine(stundenStr + ":" + minutenStr + ":" + sekundenStr);
                Thread.Sleep(1000);

                sekunden++;
                if (sekunden == 60)
                {
                    sekunden = 0;
                    minuten++;
                }
                if (minuten == 60)
                {
                    minuten = 0;
                    sekunden = 0;
                    stunden++;
                }
                if (stunden == 24)
                {
                    stunden = 0;
                    minuten = 0;
                    sekunden = 0;
                }

            }
            System.Console.WriteLine("Der Wecker klingelt!");

        }

    }
}
