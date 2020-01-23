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
            Pracownik kurier = new Pracownik(Stanowisko.Kurier,"Marek ", " Pomidor",7);
            Pracownik kierownik = new Pracownik(Stanowisko.Kierownik, "Jezy", " malina", 4);
            Pracownik sekretarka = new Pracownik(Stanowisko.Sekretarka, "Jola", " Nowakowska", 5);
            Pracownik magazynier = new Pracownik(Stanowisko.Magazynier, "Marian", " Pruszynski", 2);
            

            List<Pracownik> pracownicy = new List<Pracownik>();
            pracownicy.Add(kurier);pracownicy.Add(kierownik); pracownicy.Add(sekretarka);pracownicy.Add(magazynier);

            foreach(Pracownik x in pracownicy)
            {
                x.Pensja(x, x.LataPracy);
            }
            

            foreach(Pracownik z in pracownicy)
            {
                z.PrzedstawSie();
                
            }

            Przesylka przesylka_1 = new Przesylka("rolki");
            Przesylka przesylka_2 = new Przesylka("krawat");

          

           
            
            
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


    abstract class Magazyn
    {
        public M_Docelowe kierunek;
        

        public abstract void DodajDoMagazynu(Przesylka przes);

        public abstract void PokazZawartosc();

        public abstract void Wyslij(Przesylka przes,M_Docelowe kierunek);
        
    }

    class Mag_warszawa:Magazyn
    {
        List<Przesylka>wawa = new List<Przesylka>();

        public override void DodajDoMagazynu(Przesylka przes)
        {
            wawa.Add(przes);
            Console.WriteLine("Dodano " + przes.nazwa + " do magazynu w Warszawie ");
        }

        public override void PokazZawartosc()
        {
            if (wawa.Count == 0)
                Console.WriteLine("Magazyn aktualnie pusty ");
            else
            {
                foreach (var x in wawa)
                    Console.WriteLine(x.nazwa);
            }
        }

        public override void Wyslij(Przesylka przes ,M_Docelowe kierunek)
        {
            
        }
    }

    class Mag_Olsztyn : Magazyn
    {
        List<Przesylka> olsz = new List<Przesylka>();
        public override void DodajDoMagazynu(Przesylka przes)
        {
            olsz.Add(przes);
            Console.WriteLine("Dodano " + przes.nazwa + " do magazynu w Warszawie ");
        }

        public override void PokazZawartosc()
        {
            if (olsz.Count == 0)
                Console.WriteLine("Magazyn aktualnie pusty ");
            else
            {
                foreach (var x in olsz)
                    Console.WriteLine(x.nazwa);
            }
        }

        public override void Wyslij(Przesylka przes, M_Docelowe kierunek)
        {

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


    public enum M_Docelowe { Warszawa, Olsztyn , Gdansk }
    public enum Stanowisko { Sekretarka, Magazynier, Kierownik, Kurier }
}

