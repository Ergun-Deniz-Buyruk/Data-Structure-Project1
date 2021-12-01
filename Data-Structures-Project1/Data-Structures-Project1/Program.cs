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


        public static void dolasim(double[,] liste1_par, double[,] liste_n_x_n_par)
        {
            for (int tur_numarası = 0; tur_numarası < 10; tur_numarası++)
            {
                ArrayList sıra_listesi = new ArrayList();
                double yol_uzunluğu = 0;

                int başlangıç_noktası = rastgele.Next(20);

                sıra_listesi.Add(başlangıç_noktası);

                double min_uzaklık;

                if (başlangıç_noktası != 0)
                {
                    min_uzaklık = liste_n_x_n_par[başlangıç_noktası, başlangıç_noktası - 1];

                }
                else
                {
                    min_uzaklık = liste_n_x_n_par[başlangıç_noktası, başlangıç_noktası + 1];

                }
                int bir_sonraki_nokta = başlangıç_noktası;

                for (int d = 0; d < 18; d++)
                {
                    int su_anki_nokta = bir_sonraki_nokta;
                    double min_uzaklık_2 = 1.7976931348623157E+308;
                    
                    for (int ü = 0; ü < 20; ü++)
                    {
                        if ((liste_n_x_n_par[bir_sonraki_nokta, ü] < min_uzaklık_2)
                            && sıra_listesi.Contains(ü) == false)
                        {
                            min_uzaklık_2 = liste_n_x_n_par[bir_sonraki_nokta, ü];
                            bir_sonraki_nokta = ü;
                        }

                    }
                    Console.WriteLine(min_uzaklık_2);

                    yol_uzunluğu += min_uzaklık_2;

                }

                Console.WriteLine("tur numarası: " + (tur_numarası + 1));
                Console.WriteLine("uzunluk: " + yol_uzunluğu);
                for (int n = 0; n < 19; n++)
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

            for(int i = 0; i < 10000000; i++)
            {
                neuron.sifirla();

                neuron.egit(veri1);
                neuron.egit(veri2);
                neuron.egit(veri3);
                neuron.egit(veri4);
                neuron.egit(veri5);
                neuron.egit(veri6);
                neuron.egit(veri7);
                neuron.egit(veri8);

                Console.WriteLine(neuron.dogrulukDegeri + " / " + neuron.egitimDegeri);
                Console.WriteLine("sonuc: %" + neuron.getDogrulukYuzdesi());
                Console.WriteLine();
                /*if (i == 9)
                {
                    Console.WriteLine("sonuc: %" + neuron.getDogrulukYuzdesi());
                }*/
                
            }


            /*
            double[,] listem = rastgele_nokta(20, 100, 100);
            double[,] uzaklikMatrisim = uzaklikMatrisiniBul(listem);

            Console.WriteLine(uzaklikMatrisim.Length);

            for (int i = 0; i < Math.Sqrt(uzaklikMatrisim.Length); i++)
            {
                for (int j = 0; j < listem.Length / 2; j++)
                {
                    Console.Write(String.Format("{0:F3}", uzaklikMatrisim[i, j]) + "  ");
                }

                Console.WriteLine();
            }

            dolasim(listem, uzaklikMatrisim);
            */
            Console.ReadLine();
            
        }
        
    }
}

    
    
