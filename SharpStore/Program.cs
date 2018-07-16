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








namespace SharpStore
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Klient> ListaKlientow = new List<Klient>();
            List<Produkt> ListaProduktow = new List<Produkt>();
            for (; ; )
            {
                Console.WriteLine("MENU \nCo chcesz zrobić?\n1. Wyswietl liste produktow\n2. Wyswietl liste klientow\n3. Wyswietl liste zakupow klienta\n4. Kup\n5. Dodaj Produkt\n6. Dodaj Klienta \n7. Edytuj...\n0. Wyjscie z programu");
                int wybor = int.Parse(Console.ReadLine());

                switch (wybor)
                {
                    case 1:
                        {
                            Console.Clear();
                            foreach (Produkt produkt in ListaProduktow)
                            {
                                produkt.WyswietlProdukt();
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            foreach (Klient klient in ListaKlientow)
                            {
                                Console.WriteLine(klient.imie + " " + klient.nazwisko);
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            string szukany_imie, szukany_nazwisko;
                            Console.WriteLine("Podaj imie klienta, ktorego liste chcesz wyswietlic");
                            szukany_imie = Console.ReadLine();
                            Console.WriteLine("Podaj nazwisko klienta, ktorego liste chcesz wyswietlic");
                            szukany_nazwisko = Console.ReadLine();
                            if (Klient.CzyKlientIstnieje(ListaKlientow, szukany_imie, szukany_nazwisko))
                            {
                                Klient.ZnajdzKlienta(ListaKlientow, szukany_imie, szukany_nazwisko).WyswietlListeZakupow();
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            
                            
                                Console.Clear();
                                string szukany_imie, szukany_nazwisko;
                                Console.WriteLine("Podaj imie klienta, ktory dokonuje zakupu");
                                szukany_imie = Console.ReadLine();
                                Console.WriteLine("Podaj nazwisko klienta, ktory dokonuje zakupu");
                                szukany_nazwisko = Console.ReadLine();
                                if (Klient.CzyKlientIstnieje(ListaKlientow, szukany_imie, szukany_nazwisko))
                                {
                                    DodajDoZakupu:
                                
                                    Console.Clear();
                                    Console.WriteLine("Podaj nazwe produktu");
                                    string nazwa = Console.ReadLine();
                                    Console.WriteLine("Podaj ilosc sztuk");
                                    int sztuki = int.Parse(Console.ReadLine());
                                    if (Produkt.CzyJestNaStanie(ListaProduktow, nazwa, sztuki))
                                    {
                                        Klient.ZnajdzKlienta(ListaKlientow, szukany_imie, szukany_nazwisko).Kup(ListaProduktow, nazwa, sztuki);
                                    }
                                    Console.WriteLine("Czy chcesz dodać kolejny produkt?\n1. Tak\n2. Nie");
                                    int wybrano = int.Parse(Console.ReadLine());
                                    switch(wybrano)
                                    {
                                        case 1: { goto DodajDoZakupu;
                                            break; }
                                        case 2: { break; }
                                    }
                                         

                                
                                }
                                
                                
   
                                
                            
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Produkt produkt = new Produkt();
                            produkt.DodajProdukt();
                            ListaProduktow.Add(produkt);
                            Console.WriteLine("Dodano Produkt");
                            Console.ReadLine();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Klient klient = new Klient();
                            klient.DodajKlienta();
                            ListaKlientow.Add(klient);
                            Console.WriteLine("Dodano Klienta");
                            Console.ReadLine();
                            break;
                        }
                    case 0:
                        {
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                            break;
                        }
                    default: { Console.WriteLine("Nie ma takiej opcji"); } break;
                }

                Console.Clear();

            }
        }
    }
}
