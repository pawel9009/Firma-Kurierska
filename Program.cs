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
            Pracownik kurier = new Pracownik(Stanowisko.Kurier,"tak", " i nie",7);
            Pracownik kierownik = new Pracownik(Stanowisko.Kierownik, "Jezy", " malina", 4);
            Pracownik sekretarka = new Pracownik(Stanowisko.Sekretarka, "Jola", " Nowakowska", 5);
            Pracownik magazynier = new Pracownik(Stanowisko.Magazynier, "Marian", " Pruszynski", 2);
            Console.ReadKey();

            List<Pracownik> pracownicy = new List<Pracownik>();
            pracownicy.Add(kurier);pracownicy.Add(kierownik); pracownicy.Add(sekretarka);pracownicy.Add(magazynier);

            foreach(Pracownik x in pracownicy)
            {
                x.Pensja(x, x.LataPracy);
            }
            //kurier.Pensja(kurier, kurier.LataPracy);

            foreach(Pracownik z in pracownicy)
            {
                z.PrzedstawSie();
                Console.ReadKey();
            }

            
            
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


    public enum Stanowisko { Sekretarka, Magazynier, Kierownik, Kurier }
}

