using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt2_GrzegrzółkaMateusz46792
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo mgZak;

            Console.Write("\n\t\tProgram wyznacza sume szeregu funkcyjnego S(n)= 0+ ((x^2)(ln(2))/2!)+(((x^3)(ln(3))/3!)+... \n\tdla podanej wartości zmiennej niezależnej X oraz dokładności obliczeń eps. ");
            //deklaracja zmiennych
            float mgEps;
            float mgX;
            //wprowadzanie danych i wypisywanie wyników w pętli 
            do
            {
                Console.Write("\n\tPodaj dokładność eps: ");
                while (!float.TryParse(Console.ReadLine(), out mgEps) || (mgEps <= 0 || mgEps >= 1.0))
                {
                    Console.WriteLine("\n\tBłąd: wystąpił niedozwolony znak w podanej dokładności lub Eps nie jest w przedziale (0,1)");
                    Console.Write("\n\tPodaj dokładność eps: ");
                }

                Console.Write("\n\tPodaj wartość niezależnej X: ");
                while (!float.TryParse(Console.ReadLine(), out mgX))
                {
                    Console.WriteLine("\n\tBłąd: wystąpił niedozwolony znak w podanym X");
                    Console.Write("\n\tPodaj wartość niezależnej X: ");
                }

                //zmienne na wyniki
                int mgi;
                double mgSuma;
                //wykonanie naszej funkcji liczącej sumę
                mgSumowanieSzeregu(mgX, mgEps, out mgSuma, out mgi );
                //wyświetlenie wyników
                Console.WriteLine("\n\nWynik obliczen:");
                Console.WriteLine("\n\tSuma szeregu funkcyjnego ={0} " +
                    "\n\tLiczba zsumowanych wyrazow szeregu = {1}", mgSuma, mgi);

                Console.WriteLine("\n\tNaciśnij dowolony klawisz dla kontynuacji działania programu....");

                Console.ReadKey();

                Console.WriteLine("\n\tWypisanie wyników w rożnych formatach: ");

                Console.WriteLine("\n\tSuma szeregu funkcyjnego (format wykładniczy): {0,10:E} ", mgSuma);

                Console.WriteLine("\n\tSuma szeregu funkcyjnego (format stałopozycyjny): {0,10:F} ", mgSuma);

                Console.WriteLine("\n\tSuma szeregu funkcyjnego (format zwięzły): {0,10:G} ", mgSuma);

                Console.WriteLine("\n\tLiczba zsumowanych szeregow k = {0,3} ", mgi);

                Console.WriteLine("\n\tNacisnij dowolny przycisk dla kontynuacji programu");

                Console.ReadKey();

                Console.WriteLine("\n\tWynik obliczeń (jeszcze raz, ale zapisany w jednej instrukcji):");

                Console.WriteLine("\n\tSuma szeregu funkcyjnego (format wykładniczy): {0,10:E} " +
                   "\n\tSuma szeregu funkcyjnego (format stałopozycyjny): {0,10:F} " +
                   "\n\tSuma szeregu funkcyjnego (format zwięzły): {0,10:G} "
                   + "\n\t\t\t{0,10:G2}\n\n\tLiczba zsumowanych wyrazów szeregu" + " k={1,3}", mgSuma, mgi);

                Console.WriteLine("\n\tNacisnij dowolny przycisk aby kontynuować");

                Console.ReadKey();

                Console.Write("\n\tCzy chcesz zakończyć działanie programu (t/n): ");

                mgZak = Console.ReadKey();
            }
            while (mgZak.Key != ConsoleKey.T);

            Console.WriteLine("\n\tAutor Programu: Mateusz Grzegrzółka nr 46792");

            Console.WriteLine("\n\tDziękuję za skorzystanie z programu.");

            Console.WriteLine("\n\tNacisnij dowolny przycisk");

            Console.ReadKey();
        }

        //funkcja liczy sume szeregu
        public static void mgSumowanieSzeregu(double mgX, double mgEps, out double mgSuma, out int mgi)
        {
            //deklarujemy pustą zmienną na przechowywanie sumy
            mgSuma = 0;
            //bo wiemy że w pierwszym kroku 1
            mgi = 2;

            double mgWyraz = 1.0D;

            //idziemy pętlą do while od 1
            do
            {
                // "przejście" do kolejnego wyrazu szeregu
                mgi++;

                // "przejście" do kolejnego wyrazu szeregu


                // obliczenie i-tego wyrazu szeregu
                mgWyraz *=(mgX * (double)Math.Log(mgi))* (1/ (mgi * (double)Math.Log(mgi - 1)));
                // obliczenie kolejnego przybliżenia sumy szeregu
                mgSuma = mgSuma + mgWyraz;
                
            }
            while (Math.Abs(mgWyraz) > mgEps);

            //korekta ze względu na znalezieniu dokładności w pierwszym kroku pętli
            if (mgSuma == 0 && mgWyraz > 0)
            {
                mgSuma = mgWyraz;
            }

        }
    }
}
