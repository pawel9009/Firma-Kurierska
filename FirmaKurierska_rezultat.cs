using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaKurierska
{
    class Program
    {
        static void Main(string[] args)
        {
            Budzet srodki = new Budzet();
            srodki.PokazdostepneSrodki();

            // pracownicy i ich wynagrodzenia
            Pracownik kurier = new Pracownik(Stanowisko.Kurier,"Marek ", " Pomidor",7);
            Pracownik kierownik = new Pracownik(Stanowisko.Kierownik, "Jezy", " malina", 4);
            Pracownik sekretarka = new Pracownik(Stanowisko.Sekretarka, "Jola", " Nowakowska", 5);
            Pracownik magazynier = new Pracownik(Stanowisko.Magazynier, "Marian", " Pruszynski", 2);
            
            //dodanie ich do listy 
            List<Pracownik> pracownicy = new List<Pracownik>();
            pracownicy.Add(kurier);pracownicy.Add(kierownik); pracownicy.Add(sekretarka);pracownicy.Add(magazynier);

            //metoda obliczajaca pensje
            foreach(Pracownik x in pracownicy)
            {
                x.Pensja(x, x.LataPracy);
            }
            

            foreach(Pracownik z in pracownicy)
            {
                z.PrzedstawSie();
                
            }

            // tworzenie przaedmiotow 
            Przesylka przesylka_1 = new Przesylka("rolki");
            Przesylka przesylka_2 = new Przesylka("krawat");
            Przesylka przesylka_3 = new Przesylka("paprotka");
            Przesylka przesylka_4 = new Przesylka("sedes");
            Przesylka przesylka_5 = new Przesylka("palec");
            Przesylka przesylka_6 = new Przesylka("woda");
            Przesylka przesylka_7 = new Przesylka("krzeslo");
            Przesylka przesylka_8 = new Przesylka("parapet");
            Przesylka przesylka_9 = new Przesylka("pizza");
            Przesylka przesylka_10 = new Przesylka("zeszyt");
            Przesylka przesylka_11 = new Przesylka("kabelki");
            Przesylka przesylka_12 = new Przesylka("maslo");
            Przesylka przesylka_13 = new Przesylka("mleczyk");


            // ttorzenie magazynów
            Mag_warszawa M_wawa = new Mag_warszawa();
            Mag_Olsztyn M_olsz = new Mag_Olsztyn();
            Mag_Gdansk M_gda = new Mag_Gdansk();

            // uzupelnianie list przedmiotami
            M_wawa.DodajDoMagazynu(przesylka_1);
            M_wawa.DodajDoMagazynu(przesylka_2);
            M_wawa.DodajDoMagazynu(przesylka_3);
            M_olsz.DodajDoMagazynu(przesylka_4);
            M_gda.DodajDoMagazynu(przesylka_5);
            M_wawa.DodajDoMagazynu(przesylka_6);
            M_olsz.DodajDoMagazynu(przesylka_7);
            M_gda.DodajDoMagazynu(przesylka_8);
            M_olsz.DodajDoMagazynu(przesylka_9);
            M_gda.DodajDoMagazynu(przesylka_10);
            M_wawa.DodajDoMagazynu(przesylka_11);
            M_wawa.DodajDoMagazynu(przesylka_12);
            M_olsz.DodajDoMagazynu(przesylka_13);



            //wysylka z jednego do drugiego 
            M_wawa.Wyslij(przesylka_3, M_olsz.olsz,srodki);
            M_gda.Wyslij(przesylka_3, M_olsz.olsz, srodki);
            M_olsz.Wyslij(przesylka_8, M_gda.gda, srodki);
            M_wawa.Wyslij(przesylka_4, M_gda.gda, srodki);
            M_wawa.Wyslij(przesylka_4, M_gda.gda, srodki);
            M_olsz.Wyslij(przesylka_1, M_wawa.wawa, srodki);
            M_wawa.Wyslij(przesylka_1, M_gda.gda, srodki);
            M_wawa.Wyslij(przesylka_1, M_olsz.olsz, srodki);
            M_gda.Wyslij(przesylka_1, M_olsz.olsz, srodki);
            M_gda.Wyslij(przesylka_1, M_wawa.wawa, srodki);
            M_wawa.Wyslij(przesylka_1, M_olsz.olsz, srodki);
            M_olsz.Wyslij(przesylka_1, M_wawa.wawa, srodki);


            Console.WriteLine();
            M_wawa.PokazZawartosc();
            Console.WriteLine();
            M_olsz.PokazZawartosc();
            Console.WriteLine();
            M_gda.PokazZawartosc();
            // dostepne srodki  po wysyłkach
            srodki.PokazdostepneSrodki();

            //wyplata dla pracownikow
            srodki.Wyplata(kierownik);
            srodki.Wyplata(kurier);
            srodki.Wyplata(sekretarka);
            srodki.Wyplata(magazynier);
            //dostepne srodki po wyplacie
            srodki.PokazdostepneSrodki();




            Console.ReadKey();
        }
    }

   interface IZawod
    {
        Stanowisko stanowisko
        {
            get;
            set;
        }
    }

    abstract class Osoba
    {
        public string imie;
        public string nazwisko;
        public int LataPracy;
        protected static double Podstawa = 2000;
        public double Wynagrodzenie;
             
        public virtual void PrzedstawSie()
        {
            Console.WriteLine("Mam na imie " + imie + nazwisko + " posiadam " + LataPracy + " lat doswiadczenia"+" i z tego "+Wynagrodzenie+" wynagrodzenia");
        }
    }

    class Pracownik : Osoba, IZawod
    {
        public Pracownik(Stanowisko stan,string imie,string naz, int Latapr)
        {
            stanowisko = stan;
            this.imie = imie;
            nazwisko = naz;
            LataPracy = Latapr;
        }
        public Stanowisko stanowisko { get ; set ; }

        public override void PrzedstawSie()
        {
            base.PrzedstawSie();
        }

        //metoda ustawiajaca pensje na podstawie wypracowanych lat w zaleznosci od stanowiska
        public virtual double Pensja(Pracownik pracownik, int lata)
        {
            string nazwa = Convert.ToString(pracownik.stanowisko);
            switch (nazwa)
            {
                case "Kurier":
                    pracownik.Wynagrodzenie = Podstawa + (lata * 170);
                    break;
                case "Kierownik":
                    pracownik.Wynagrodzenie = Podstawa + (lata * 280);
                    break;
                case "Sekretarka":
                    pracownik.Wynagrodzenie = Podstawa + (lata * 190);
                    break;
                case "Magazynier":
                    pracownik.Wynagrodzenie = Podstawa + (lata * 230);
                    break;
            }
            return pracownik.Wynagrodzenie;
        }   
    }

    class Budzet
    {
        private double dostepneSrodki = 50000;

        public void Wyplata(Pracownik prac)
        {
            dostepneSrodki -= prac.Wynagrodzenie;
        }

        public void PokazdostepneSrodki()
        {
            Console.WriteLine("Kwota :"+dostepneSrodki);
        }

        public void Transakcja()
        {
            Random rand = new Random();
            dostepneSrodki += rand.Next(504, 764);
        }
    }
    abstract class Magazyn
    {        
        public abstract void DodajDoMagazynu(Przesylka przes);
        public abstract void PokazZawartosc();
        public abstract void Wyslij(Przesylka przes, List<Przesylka> prze, Budzet konto);       
    }

    class Mag_warszawa:Magazyn
    {
        public List<Przesylka> wawa = new List<Przesylka>();

        public override void DodajDoMagazynu(Przesylka przes)
        {
            wawa.Add(przes);            
        }

        //wyswietlanie aktualnego stanu magazynu
        public override void PokazZawartosc()
        {
            if (wawa.Count == 0)
                Console.WriteLine("Warszawa = Magazyn aktualnie pusty ");
            else
            {
                Console.WriteLine("Magazyn Warszawa:");
                foreach (var x in wawa)
                    Console.WriteLine(x.nazwa);
            }
        }
        // transport przedmiotu z jednego miejsca do drugiego, dodajac jeszcze jakas kwote do konta 
        public override void Wyslij(Przesylka przes ,List<Przesylka> prz, Budzet konto)
        {
            if (wawa.Count == 0)
                Console.WriteLine("Pusto");
            else
            {
                prz.Add(wawa.First());
                wawa.Remove(wawa.First());
                konto.Transakcja();               
            }          
        }
    }

    class Mag_Gdansk : Magazyn
    {
        public List<Przesylka> gda = new List<Przesylka>();

        public override void DodajDoMagazynu(Przesylka przes)
        {
            gda.Add(przes);
           
        }

        public override void PokazZawartosc()
        {
            if (gda.Count == 0)
                Console.WriteLine("Gdansk = Magazyn aktualnie pusty ");
            else
            {
                Console.WriteLine("Magazyn Gdansk:");
                foreach (var x in gda)
                    Console.WriteLine(x.nazwa);
            }
        }

        public override void Wyslij(Przesylka przes, List<Przesylka> prz, Budzet konto)
        {
            if (gda.Count == 0)
                Console.WriteLine("Pusto");
            else
            {
                prz.Add(gda.First());
                gda.Remove(gda.First());
                konto.Transakcja();
            }


        }
    }

    class Mag_Olsztyn : Magazyn
    {
        public List<Przesylka> olsz = new List<Przesylka>();
        public override void DodajDoMagazynu(Przesylka przes)
        {
            olsz.Add(przes);
           
        }

        public override void PokazZawartosc()
        {
            if (olsz.Count == 0)
                Console.WriteLine("Olsztyn = Magazyn aktualnie pusty ");
            else
            {
                Console.WriteLine("Magazyn Olsztyn:");
                foreach (var x in olsz)
                    Console.WriteLine(x.nazwa);
            }
        }

        public override void Wyslij(Przesylka przes, List<Przesylka> prz, Budzet konto)
        {
            if (olsz.Count == 0)
                Console.WriteLine("Pusto");
            else
            {
                prz.Add(olsz.First());
                olsz.Remove(olsz.First());
                konto.Transakcja();
            }


        }



    }

    class Przesylka
    {
        public string nazwa;


        public Przesylka(string naz)
        {
            nazwa = naz;
        }                    
        
    }

    public enum Stanowisko { Sekretarka, Magazynier, Kierownik, Kurier }
}

