using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Data_Structures_Project1
{
    class Program
    {

        static Random rastgele = new Random();
        public static double[,] rastgele_nokta(int n_par, int genişlik_par, int yükseklik_par)
        {
            double[,] a = new double[n_par, 2];
            for (int i = 0; i < n_par; i++)
            {
                double genişlik = rastgele.NextDouble() * 100;
                double yükseklik = rastgele.NextDouble() * 100;

                //

                a[i, 0] = genişlik;
                a[i, 1] = yükseklik;
            }
            return a;
        }

        public static void dolaşım(double[,] liste1_par, double[,] liste_n_x_n_par)
        {
            for (int tur_numarası = 0; tur_numarası < 10; tur_numarası++)
            {
                ArrayList sıra_listesi = new ArrayList();
                double yol_uzunluğu = 0;

                double[,] kopya_liste = new double[liste1_par.GetLength(0), 2];
                for (int len = 0; len < liste1_par.GetLength(0); len++)
                {
                    kopya_liste[len, 0] = liste1_par[len, 0];
                    kopya_liste[len, 1] = liste1_par[len, 1];
                }
                int başlangıç_noktası = rastgele.Next(20);

                sıra_listesi.Add(başlangıç_noktası);
                int bir_sonraki_nokta = 50;




                double min_uzaklık;
                if (başlangıç_noktası != 0)
                {
                    min_uzaklık = liste_n_x_n_par[başlangıç_noktası, başlangıç_noktası - 1];

                }
                else
                {
                    min_uzaklık = liste_n_x_n_par[başlangıç_noktası, başlangıç_noktası + 1];

                }


                for (int y = 0; y < 20; y++)
                {
                    if ((liste_n_x_n_par[başlangıç_noktası, y] < min_uzaklık) && (liste_n_x_n_par[başlangıç_noktası, y] != 0))
                    {
                        min_uzaklık = liste_n_x_n_par[başlangıç_noktası, y];
                        bir_sonraki_nokta = y;
                    }


                }
                yol_uzunluğu += min_uzaklık;

                for (int d = 0; d < 19; d++)
                {
                    sıra_listesi.Add(bir_sonraki_nokta);
                    double min_uzaklık_2;
                    if (bir_sonraki_nokta != 0)
                    {
                        min_uzaklık_2 = liste_n_x_n_par[bir_sonraki_nokta, bir_sonraki_nokta - 1];

                    }
                    else
                    {
                        min_uzaklık_2 = liste_n_x_n_par[bir_sonraki_nokta, bir_sonraki_nokta + 1];

                    }
                    for (int ü = 0; ü < 20; ü++)
                    {
                        if ((liste_n_x_n_par[bir_sonraki_nokta, ü] < min_uzaklık_2) && (liste_n_x_n_par[bir_sonraki_nokta, ü] != 0) && sıra_listesi.Contains(bir_sonraki_nokta) == false)
                        {
                            min_uzaklık_2 = liste_n_x_n_par[başlangıç_noktası, ü];
                            bir_sonraki_nokta = ü;
                        }


                    }
                    yol_uzunluğu += min_uzaklık_2;

                }

                Console.WriteLine("tur numarası: " + tur_numarası);
                Console.WriteLine("uzunluk: " + yol_uzunluğu);
                for (int n = 0; n < 20; n++)
                {
                    Console.Write(sıra_listesi[n] + "  ");

                }

                //matrisi yazdır

            }
        }

        /* 
         * Kendisine verilen noktalar matrisini alarak her nokta arasindaki 
         * uzakligi bulup n*n lik uzaklik matrisini uretip bu matrisi donduren metot. 
         */
        public static double[,] uzaklikMatrisi(double[,] noktalarMatrisi)
        {
            // Gelen matristeki toplam nokta sayisini bul.
            private int noktaSayisi = noktalarMatrisi.Length();

        // Once uzaklik matrisini uretelim.
        private double[noktaSayisi, noktaSayisi] uzaklikMatrisi = new double[noktaSayisi, noktaSayisi];




    }

    public static void Main(string[] args)
    {

        double[,] listem = rastgele_nokta(20, 100, 100);


        Console.ReadLine();


    }
    
}
