using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpStore
{
    public class Klient
    {
        public string imie;
        public string nazwisko;
        List<Zakup> lista_zakupow = new List<Zakup>();
        public Klient()
        { }
        public Klient(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
        public void DodajKlienta()
        {
            
            Console.WriteLine("Podaj imie klienta");
            imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko klienta");
            nazwisko = Console.ReadLine();
            
        }

        public void Kup(List<Produkt>ListaProduktow, string nazwa_kupowanego, int ilosc_kupowanego)
        {
            Zakup zakup = new Zakup();
            zakup.dataZakupu = DateTime.Now;
            zakup.produkt.nazwa_produktu = nazwa_kupowanego;
            zakup.produkt.ilosc = ilosc_kupowanego;
            lista_zakupow.Add(zakup);
            if (zakup.produkt.ilosc < ListaProduktow.Find(x => x.nazwa_produktu == nazwa_kupowanego).ilosc)
            {
                ListaProduktow.Find(x => x.nazwa_produktu == nazwa_kupowanego).ilosc = ListaProduktow.Find(x => x.nazwa_produktu == nazwa_kupowanego).ilosc-ilosc_kupowanego;
            }
            else if((zakup.produkt.ilosc == ListaProduktow.Find(x => x.nazwa_produktu == nazwa_kupowanego).ilosc))
                {
                ListaProduktow.Remove(ListaProduktow.Find(x => x.nazwa_produktu == nazwa_kupowanego));
                }
        }
        public static bool CzyKlientIstnieje(List<Klient> ListaKlientow, string szukany_imie, string szukany_nazwisko)
        {

           if (ListaKlientow.Exists(x => x.nazwisko == szukany_nazwisko) && (ListaKlientow.Exists(x => x.imie == szukany_imie)))
            {
                return true;
            }
            else { Console.WriteLine("Nie ma takiego kienta"); return false;  }
        }
        public static Klient ZnajdzKlienta (List<Klient> ListaKlientow, string szukany_imie, string szukany_nazwisko)
        {
           
           
                Klient szukany = new Klient();

                szukany = ListaKlientow.Find(x => x.nazwisko == szukany_nazwisko);
                return szukany;
            
            
        }
        public void WyswietlListeZakupow()
        {
            foreach (var i in lista_zakupow)
            {
                Console.WriteLine(i.produkt.nazwa_produktu + " Sztuk: " + i.produkt.ilosc + " Dnia: " + i.dataZakupu);
            }
        }

    }
}
