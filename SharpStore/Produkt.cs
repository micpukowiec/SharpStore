using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpStore
{
    public class Produkt
    {
        public string nazwa_produktu;
        public int ilosc;
        public Produkt()
        {

        }

        public Produkt(string nazwa_produktu, int ilosc)
        {
            this.nazwa_produktu = nazwa_produktu;
            this.ilosc = ilosc;
        }
        public void DodajProdukt()
        {

            Console.WriteLine("Podaj nazwe produktu");
            nazwa_produktu = Console.ReadLine();
            Console.WriteLine("Podaj ilosc sztuk");
            ilosc = int.Parse(Console.ReadLine());
        }
        public void WyswietlProdukt()
        {
            Console.WriteLine(nazwa_produktu + " Sztuk: " + ilosc);
        }
       public static bool CzyJestNaStanie(List<Produkt> ListaProduktow, string szukany_nazwa, int szukany_ilosc)
        {
            if(ListaProduktow.Exists(x=>x.nazwa_produktu==szukany_nazwa))
            {
                Produkt produkt = new Produkt();
                produkt = ListaProduktow.Find(x => x.nazwa_produktu == szukany_nazwa);
                if(produkt.ilosc>=szukany_ilosc)
                {
                    return true;
                }
                else { Console.WriteLine("Za malo sztuk na stanie!"); return false; }
            }
            else { Console.WriteLine("Nie ma takiego produktu!!!"); return false; }
        }
    }
}
