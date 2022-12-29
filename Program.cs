namespace _10._6._bankmanager_deel2;

class Program
{
    static void Main(string[] args)
    {
        Rekening r1 = new Rekening();
        Rekening r2 = new Rekening();
        r1.StortGeld(1000);
        r2.StortGeld(1000);
        
        Rekening.SimuleerOverdracht(r1, r2);
        Console.WriteLine($"Saldo rekening 1 na simuleeroverdracht: {r1.Balans}");    
        Console.WriteLine($"Saldo rekening 2 na simuleeroverdracht: {r2.Balans}");




        Rekening kinderRekening = new Rekening("test");
        Console.WriteLine($"Kinderrekening met overloaded constructor: {kinderRekening.NaamKlant} en balans is {kinderRekening.Balans}");
        Rekening test1 = Rekening.CreeerTienerRekening("test1");
        Console.WriteLine($"Kinderrekening test1 static method in Rekening class: {test1.NaamKlant} en balans is {test1.Balans}");
        Rekening test2 = CreeerTienerRekening1("test2");

        Console.WriteLine($"Kinderrekening test2 static method outside Rekening class: {test2.NaamKlant} en balans is {test2.Balans}");
        
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

    public static Rekening CreeerTienerRekening1(string naam)
    {   
        return new Rekening(naam);
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
        

        public static void SimuleerOverdracht(Rekening a, Rekening b)
        {
            Random amount = new Random();
            for(int i=0; i<5; i++)
            {
                int bedrag = amount.Next(0,101);
            if(i % 2 == 0)
                {
                   
                   a.StortGeld(b.HaalGeldAf(bedrag));
                    Console.WriteLine($"Rekening R2 stort {bedrag} op rekening R1");
                }
                else
                {
                    b.StortGeld(a.HaalGeldAf(bedrag)); 
                    Console.WriteLine($"Rekening R1 stort {bedrag} op rekening R2");
                }

            }
            

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

