namespace _10._6._bankmanager_deel2;

class Program
{
    static void Main(string[] args)
    {
        Rekening r1 = new Rekening();
        Rekening r2 = new Rekening();
        Rekening kinderRekening = new Rekening("test");
        Console.WriteLine($"Kinderrekening naam: {kinderRekening.NaamKlant} en balans is {kinderRekening.Balans}");
        Rekening test1 = Rekening.CreeerTienerRekening("test1");
        Console.WriteLine($"Kinderrekening naam1: {test1.NaamKlant} en balans is {test1.Balans}");
        string klantenNaam1 = "Pol";
        string klantenNaam2 = "Piet";
        string rekeningNummer1 = "03085464";
        string rekeningNummer2 = "05899314";
        r1.NaamKlant= klantenNaam1;
        r2.NaamKlant= klantenNaam2;
        r1.RekeningNummer = rekeningNummer1;
        r2.RekeningNummer = rekeningNummer2;
        Console.WriteLine(r1.Staat);
        Console.WriteLine(r2.Staat);
        Console.WriteLine($"Begin saldo: {r1.Balans}");    
        Console.WriteLine($"Begin saldo: {r2.Balans}");
        
        r1.StortGeld(1000);
        r1.HaalGeldAf(1200);
        Console.WriteLine(r1.Staat);
        r2.StortGeld(1000);
        r2.VeranderStaat();

        Console.WriteLine($"Saldo na intiële storing van 1000 euro: {r1.Balans}");    
        Console.WriteLine($"Saldo na intiële storing van 1000 euro: {r2.Balans}");
        Console.WriteLine("Piet doet overschrijving van 300 euro naar rekening Pol");
        r1.StortGeld(r2.HaalGeldAf(300));
        Console.WriteLine($"Klant: {r1.NaamKlant}, Rekeningnummer: {r1.RekeningNummer}, Saldo: {r1.Balans}");
        Console.WriteLine($"Klant: {r2.NaamKlant}, Rekeningnummer: {r2.RekeningNummer}, Saldo: {r2.Balans}");

    }

    // Classes
    public class Rekening
    {
        // Instance variables
        public int Balans { get; private set; }

        public string? NaamKlant { get; set; }
        public string? RekeningNummer { get; set; }

        public enum RekeningStaat { Geldig, Geblokkeerd}
        public RekeningStaat Staat { get; private set; } = RekeningStaat.Geldig;

        // Constructors
        public Rekening()
        {
           
        }
        public Rekening(string klantnaam)
        {
            NaamKlant = klantnaam;
            Balans = 50;
        }

        // Methods
        

        public void SimuleerOverdracht(Rekening a, Rekening B)
        {

        }

        public static Rekening CreeerTienerRekening(string naam)
        {
            
            Rekening a = new Rekening(naam);
            return a;
        }
        

       
        
        public void VeranderStaat()
        {
            if(Staat == RekeningStaat.Geblokkeerd)
            {
                Staat = RekeningStaat.Geldig;
            }
            else
            {
                Staat = RekeningStaat.Geblokkeerd; 
            }
        }




        

        public int HaalGeldAf (int bedrag)
        {
            if (Staat == RekeningStaat.Geldig)
            {
                if (bedrag > Balans)
                {
                    Console.WriteLine("Niet alle geld kon gegeven, saldo ontoereikend, rekening leeg nu.");
                    VeranderStaat();
                    return Balans;
                }
                else
                {
                    Balans -= bedrag;
                    return bedrag;
                }
            }
            else
            {
                Console.WriteLine("Gaat niet, Rekening geblokkeerd");
                return 0;
            }

        }

        public void StortGeld (int bedrag)
        {
            if(Staat == RekeningStaat.Geldig)
            {
                Balans += bedrag;
            }
            else
            {
                Console.WriteLine("Gaat niet, Rekening geblokkeerd");
            }
        }

        public void ToonInfo ()
        {
            Console.WriteLine($"Klantnaam: {NaamKlant}");
            Console.WriteLine($"Rekeningnummer: {RekeningNummer}");
            Console.WriteLine($"Saldo: {Balans}");

     
        }



    }

    
}

