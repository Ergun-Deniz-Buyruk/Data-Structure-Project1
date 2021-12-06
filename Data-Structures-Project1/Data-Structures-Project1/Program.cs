using System;
using System.Collections;

namespace Data_Structures_Project1
{
    class Program
    {
        public const int EN_KISA_YOL_SAYISI = 10;

        static Random rastgele = new Random();

        public static double[,] rastgeleNoktaBul(int noktaSayisi, int genislik, int yukseklik)//rastgele nokta üreten metot
        {
            double[,] noktalarListesi = new double[noktaSayisi, 2];//nx2 lik bir matris
            
            for (int i = 0; i < noktaSayisi; i++)
            {
                double xKoordinati = rastgele.NextDouble() * genislik;      //nextdouble metodu 0 ile 1 arasında değer ürettiği için genislik ile çarpıyorum
                double yKoordinati = rastgele.NextDouble() * yukseklik; //nextdouble metodu 0 ile 1 arasında değer ürettiği için yukseklik ile çarpıyorum

                noktalarListesi[i, 0] = xKoordinati; //değerleri matrise atıyorum
                noktalarListesi[i, 1] = yKoordinati;
            }
            return noktalarListesi; //matrisi döndürüyorum
        }

        //en kısa yolu bulan metot
        public static void dolasim(double[,] noktalarListesi, double[,] uzaklikMatrisi)
        {
            ArrayList siraListesi = new ArrayList(); // Sira listesini tutan Arraylist
            
            double toplamYolUzunlugu = 0; // Toplam yol uzunlugu                            

            int baslangicNoktasi = rastgele.Next(noktalarListesi.GetLength(0)); // Baslangic noktasini random atadim.

            siraListesi.Add(baslangicNoktasi); // Baslangic listesini sira listesine ekle.             

            int suAnkiNokta = baslangicNoktasi; // Su an uzerinde bulundugumuz noktaya ilk noktayı atadık.

            double minUzaklik; // Minumum uzakligi tanimladim.
            // Su anki noktaya en yakin noktamiz bir sonraki noktamiz olacak. bunu ilk basta su anki nokta diyelim.
            int birSonrakiNokta = suAnkiNokta; // to make compiler happy

            // Listedeki tum elemanlari gezerek su anki noktaya en yakin noktayi bulalim.
            for (int i = 0; i < noktalarListesi.GetLength(0) - 1; i++) 
            {
                minUzaklik = 1.7976931348623157E+308;// Min uzakliga verilebilecek en buyuk  noktayi verelim.

                for (int j = 0; j < noktalarListesi.GetLength(0); j++) // her bir noktayı tek tek gezerek en yakını bul.
                {
                    // Eger noktamizin uzakligi en kücükse ve daha önce bu noktaya gidilmemisse bir sonraki noktamizi bulduk demektir.
                    if ((uzaklikMatrisi[suAnkiNokta, j] < minUzaklik) && (siraListesi.Contains(j) == false))
                    {
                        minUzaklik = uzaklikMatrisi[suAnkiNokta, j]; // min uzaklik degerini al.
                        birSonrakiNokta = j;// Bir sonraki noktamizi degistir.
                    }
                }
                toplamYolUzunlugu += minUzaklik; // Toplam uzakligi bulmak icin su anki uzakligi ekle.
                siraListesi.Add(birSonrakiNokta);// Buldugumuz noktayi sira listesine ekle.
                suAnkiNokta = birSonrakiNokta;// Noktamizi buldugumuza göre artık bir sonraki noktaya gecebiliriz. Bunun icin su anki noktamizi bir sonraki noktamiz yapalim.
            } // End For

            // Tum noktalar da bulunduguna gore sira listemizi konsola yazdıralım.
            Console.WriteLine("Yol Uzunluğu: " + toplamYolUzunlugu);
            Console.Write("Uğradığı Noktalar: ");
            foreach (int nokta in siraListesi)
            {
                Console.Write($"{nokta}-");           
            }
            Console.WriteLine();
        }

        /*
         * Noktalar matrisini parametre olarak alan, bu noktalar arasindaki uzakligi bulup 
         * uzaklik matrisine ekleyen ve bu uzaklik matrisini donduren metot.
         */
        public static double[,] uzaklikMatrisiniBul(double[,] noktalarMatrisi)
        {
            // Toplam nokta sayisini bulalim.
            int noktaSayisi = noktalarMatrisi.GetLength(0);

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

        // Ilk sorunun a secenegindeki test verileri
        public static void IlkSorununASecenegi()
        {
            double[,] noktalarListem1 = rastgeleNoktaBul(20, 100, 100);
            double[,] noktalarListem2 = rastgeleNoktaBul(50, 100, 100);

            for (int i = 0; i < noktalarListem1.GetLength(0); i++)
            {
                Console.Write(noktalarListem1[i, 0] + ", " + noktalarListem1[i, 1]);
                Console.WriteLine();
            }

            Console.WriteLine("-----------------------------------------------------");

            for (int i = 0; i < noktalarListem2.GetLength(0); i++)
            {
                Console.Write(noktalarListem2[i, 0] + ", " + noktalarListem2[i, 1]);
                Console.WriteLine();
            }
        }

        // Ilk sorunun b secenegi
        public static void IlkSorununBSecenegi()
        {
            double[,] noktalarListem1 = rastgeleNoktaBul(20, 100, 100);
            double[,] uzaklikMatrisim = uzaklikMatrisiniBul(noktalarListem1);

            Console.WriteLine();
            Console.WriteLine("{0,90}", "Uzaklık Matrisi (DM)");
            Console.WriteLine();
            for (int i = 0; i < uzaklikMatrisim.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Console.Write("    ");
                    for (int k = 0; k < uzaklikMatrisim.GetLength(0); k++)
                    {
                        Console.Write("{0,-8}", k);
                    }
                    Console.WriteLine();
                }
                Console.Write("{0, -4}", i);
                for (int j = 0; j < uzaklikMatrisim.GetLength(0); j++)
                {
                    Console.Write("{0,-8:N2}", uzaklikMatrisim[i, j]);
                }
                Console.WriteLine();
            }
        }
        
        // Ilk sorunun c secenegi
        public static void IlkSorununCSecenegi()
        {
            double[,] noktalarListem1 = rastgeleNoktaBul(20, 100, 100);
            double[,] uzaklikMatrisim = uzaklikMatrisiniBul(noktalarListem1);

            for (int i = 0; i < EN_KISA_YOL_SAYISI; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Tur Numarası: " + (i + 1));
                dolasim(noktalarListem1, uzaklikMatrisim);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {

            IlkSorununASecenegi();
            IlkSorununBSecenegi();
            IlkSorununCSecenegi();

            // 2. Soru

            // Veri setlerimizi tanimlayalim.
            double[] veri1 = { 0.6, 0.5, 1 };
            double[] veri2 = { 0.2, 0.4, 1 };
            double[] veri3 = { -0.3, -0.5, -1 };
            double[] veri4 = { -0.1, -0.1, -1 };
            double[] veri5 = { 0.1, 0.1, 1 };
            double[] veri6 = { -0.2, 0.7, 1 };
            double[] veri7 = { -0.4, -0.2, -1 };
            double[] veri8 = { -0.6, 0.3, -1 };

            // Neuronumuzu yaratalim.
            Neuron neuron = new Neuron();

            
            // 100 kere epok islemini uygulayalim. Her turda tum veri setlerini birer kere alarak kendini egitiyor.
            for (int i = 0; i < 100; i++)
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

                // 10. turda basari yuzdesini konsola yazdiralim.
                if (i == 9)
                {
                    Console.WriteLine("10 epok sonundaki doğruluk değeri: %" + neuron.getDogrulukYuzdesi());
                }

            }
            // 100 epok sonunda basari yuzdesini konsola yazdiralim.
            Console.WriteLine("100 epok sonundaki doğruluk değeri: %" + neuron.getDogrulukYuzdesi());

            // Test verileri:
            double[] testVeri1 = { 0.7, 0.4, 1 };
            double[] testVeri2 = { 0.4, -0.9, -1 };
            double[] testVeri3 = { -0.3, 0.5, 1 };
            double[] testVeri4 = { -0.6, -0.8, -1 };
            double[] testVeri5 = { 0.8, -0.1, 1 };

            neuron.sifirla();
            neuron.egit(testVeri1);
            neuron.egit(testVeri2);
            neuron.egit(testVeri3);
            neuron.egit(testVeri4);
            neuron.egit(testVeri5);

            Console.WriteLine("5 Test verisinin doğruluk değeri: %" + neuron.getDogrulukYuzdesi());
        }

    }
}