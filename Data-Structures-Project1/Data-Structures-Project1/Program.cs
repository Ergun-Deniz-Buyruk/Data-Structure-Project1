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
         * Noktalar matrisini parametre olarak alan, bu noktalar arasindaki uzakligi bulup 
         * uzaklik matrisine ekleyen ve bu uzaklik matrisini donduren metot.
         */
        public static double[,] uzaklikMatrisiniBul(double[,] noktalarMatrisi)
        {
            // Toplam nokta sayisini bulalim.
            int noktaSayisi = noktalarMatrisi.Length / 2;

            // Once uzaklik matrisimizi olusturalim.
            double[,] uzaklikMatrisi = new double[noktaSayisi, noktaSayisi];

            /*
             * Noktalar matrisindeki her bir eleman ile diger elemanlari 
             * tek tek gezerek aralarindaki uzakligi bul.
             */
            for(int i = 0; i < noktaSayisi; i++)
            {
                // Ilk noktanin koordinatlarini al.
                double birinciNoktaApsisi = noktalarMatrisi[i, 0];
                double birinciNoktaOrdinati = noktalarMatrisi[i, 1];
                for(int j = 0; j < noktaSayisi; j++)
                {

                    /*
                     * matris[i, j] = matris[j, i] olacagindan eğer matrisin bu degerleri sifir degilse 
                     * yani daha onceden uzakligi bulunup yazilmissa bir daha hesaplayip yazmaya gerek olmadigindan 
                     * if ile once kontrol et. Hesaplanmamissa hesaplayip matrise ekle.
                     */
                    if (uzaklikMatrisi[i, j] == 0)
                    {
                        // Ikinci noktanin korrdinatlarini al.
                        double ikinciNoktaApsisi = noktalarMatrisi[j, 0];
                        double ikinciNoktaOrdinati = noktalarMatrisi[j, 1];

                        // Iki nokta arasindaki uzakligi hesapla.
                        double apsislerArasiUzaklik = birinciNoktaApsisi - ikinciNoktaApsisi;
                        double ordinatlarArasiUzaklik = birinciNoktaOrdinati - ikinciNoktaOrdinati;

                        double ikiNoktaUzakligi = Math.Sqrt(Math.Pow(apsislerArasiUzaklik, 2)
                            + Math.Pow(ordinatlarArasiUzaklik, 2));

                        // Bulunan bu uzakligi matrise, simetrik olarak her iki deger icin de ekle.
                        uzaklikMatrisi[i, j] = ikiNoktaUzakligi;
                        uzaklikMatrisi[j, i] = ikiNoktaUzakligi;
                    }
                    
                }
            }
            return uzaklikMatrisi;
        }

        static void Main(string[] args)
        {
            double[] veri1 = { 0.6, 0.5, 1 };
            double[] veri2 = { 0.2, 0.4, 1 };
            double[] veri3 = { -0.3, -0.5, -1 };
            double[] veri4 = { -0.1, -0.1, -1 };
            double[] veri5 = { 0.1, 0.1, 1 };
            double[] veri6 = { -0.2, 0.7, 1 };
            double[] veri7 = { -0.4, -0.2, -1 };
            double[] veri8 = { -0.6, 0.3, -1 };

            Neuron neuron = new Neuron();
            neuron.setGirdiArray(veri5);

            for(int i = 0; i < 100; i++)
            {
                neuron.egit();
                Console.WriteLine("sonuc: %" + neuron.getDogrulukDegeri() /(double) i * 100);
            }

            Console.ReadLine();
        }
    }
}

    
    
