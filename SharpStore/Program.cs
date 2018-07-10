using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Sharp Store
Utworzenie systemu magazynowego przechowującego produkty i ich stan (ilość).
Możliwość kupowania produktów przez klientów. 
Lista wszystkich klientów dodatkowo zawiera listę produktów które kupił klient oraz kiedy je kupił.
*/

public class Produkt
{
    public string nazwa_produktu;
    public int ilosc;
    public Produkt ()
    {
        ;
    }
    public Produkt(string nazwa_produktu, int ilosc, List<Produkt> lista)
    {
        this.nazwa_produktu = nazwa_produktu;
        this.ilosc = ilosc;
        DodajDoListy(lista);
    }

    public Produkt(string nazwa_produktu, int ilosc)
    {
        this.nazwa_produktu = nazwa_produktu;
        this.ilosc = ilosc;
    }

    public void WyswietlProdukt()
    {
        Console.WriteLine(nazwa_produktu + " Sztuk: " + ilosc);
    }
    public void DodajDoListy (List<Produkt> lista)
    {
        lista.Add(new Produkt(nazwa_produktu,ilosc));
    }
}


public class Zakup : Produkt
{
    public short dzien;
    public short miesiac;
    public short rok;
    public Zakup()
    {
    ;
    }
    public Zakup (string nazwa_produktu, int ilosc, short dzien, short miesiac, short rok, List<Produkt> lista)
    {
        this.nazwa_produktu = nazwa_produktu;
        this.ilosc = ilosc;
        this.dzien = dzien;
        this.miesiac = miesiac;
        this.rok = rok;
        if(CzyJestNaStanie(lista))
        { UsunZListy(lista); }
        

        
    }
    public bool CzyJestNaStanie(List<Produkt>lista)
    {
        Produkt szukany = lista.Find(x => x.nazwa_produktu == nazwa_produktu);
        if (szukany.ilosc >= ilosc)
        { return true; }
        else {
            Console.WriteLine(szukany.nazwa_produktu + " Niewystarczajaco sztuk!!!");
            return false;
                }
    }
    public void UsunZListy(List<Produkt> lista)
    {
        Produkt szukany = lista.Find(x=>x.nazwa_produktu==nazwa_produktu);
        
        szukany.ilosc -= ilosc; 
     
        if(szukany.ilosc==0)
        {
            lista.Remove(szukany);
        }
    }
}


class Klient
{
    string imie;
    string nazwisko;
    List<Zakup> lista_zakupow = new List<Zakup>();
    public Klient(string imie, string nazwisko)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
    }

    public void Kup(Zakup zakup)
    {
        lista_zakupow.Add(zakup);
    }
    public void WyswietlListeZakupow()
    {
        foreach(var i in lista_zakupow)
        {
            Console.WriteLine(i.nazwa_produktu+" Sztuk: "+i.ilosc+" Dnia: "+i.dzien+"."+i.miesiac+"."+i.rok);
        }
    }
}

namespace SharpStore
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Produkt fotel = new Produkt ("Fotel", 5);
            fotel.WyswietlProdukt();

            Zakup fotele = new Zakup("Fotel", 3,1,4,2015);
            Zakup krzesla = new Zakup("Krzeslo", 2, 2, 2, 2015);*/
            Klient nowak = new Klient("Jan", "Nowak");
           
            
            List<Produkt> lista_produktow = new List<Produkt>();
            //lista_produktow.Add(new Produkt("Komoda", 1));
            //lista_produktow.Add(new Produkt("Szafa", 2));
            Produkt spodnie = new Produkt("Spodnie", 1,lista_produktow);
            Produkt koszula = new Produkt("Koszula", 2,lista_produktow);
            Produkt garnitur = new Produkt("Garnitur", 2, lista_produktow);
            Produkt krawat = new Produkt("Krawat", 2, lista_produktow);
            foreach (var i in lista_produktow)
            {
                Console.WriteLine(i.nazwa_produktu + " Sztuk: " + i.ilosc);
            }
            Zakup garnituru = new Zakup("Garnitur", 1, 2, 4, 2018, lista_produktow);
            Zakup koszul = new Zakup("Koszula", 2, 5, 4, 2017, lista_produktow);
            Zakup spodni = new Zakup("Spodnie", 5, 6, 3, 2002, lista_produktow);
            nowak.Kup(garnituru);
            nowak.Kup(koszul);
            nowak.Kup(spodni);
            nowak.WyswietlListeZakupow();
            foreach (var i in lista_produktow)
            {
                Console.WriteLine(i.nazwa_produktu + " Sztuk: " + i.ilosc);
            }
        }
    }
}
