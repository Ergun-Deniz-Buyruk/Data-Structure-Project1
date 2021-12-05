using System;

public class Neuron
{
	// Neuronun kullanacagi Lambda degeri. Simdilik 0.5 aldik.
	public const double LAMBDA = 0.05;

	// Neuronun agirliklarini tutacak olan agirlik arrayi:
	private double[] agirlikArray;

	// Agirliklara ilk basta random deger atamak icin random nesnesi olustur.
	Random rastgele = new Random();

	// Neuronun dogruluk yuzdesini hesaplamak icin gerekli degerler:
	private int dogrulukDegeri;
	private int egitimDegeri;
	
	// Neuron sinifimizin constructori:
	public Neuron()
	{
		agirlikArray = new double[2]; // agirlik arayini iki elemanli sekilde ac.

		// Agirlik arrayinin iki elemanini [-1, 1] araliginda olacak sekilde random degerler ata.
		for (int i = 0; i < 2; i++)
		{
			agirlikArray[i] = 2 * rastgele.NextDouble() - 1;
		}
		sifirla(); // Dogruluk ve egitim degerini neuron ilk olustugunda sifirla.
	}

	// Neuronun dogruluk degerini hesaplayip donduren metot.
	public double getDogrulukYuzdesi()
    {
		return dogrulukDegeri / (double) egitimDegeri * 100;
    }

	/* 
	 * Her epokta dogruluk degerini hesaplayabilmemiz icin her epok sonunda degerleri sifirlamamiz gerekir.
	 * Bu sebeple sifirla metodu her cagrildiganda dogruluk ve egitim degerini sifirlanir.
	 */
	public void sifirla()
    {
		dogrulukDegeri = 0;
		egitimDegeri = 0;
    }

	/*
	 * Verilen veri setinin uygun elemaniyla neuronumuzun uygun agirligini ayri ayri carpip bunlari topluyor.
	 * Daha sonra bulunan deger geri donderiliyor.
	 */
	private double toplamaIslemi(double[] girdiArray)
    {
		double sonuc = 0;
		for(int i = 0; i < girdiArray.Length - 1; i++)
        {
			sonuc += girdiArray[i] * agirlikArray[i];
        }
		return sonuc;
    }

	/*
	 * Toplama isleminden gelen deger eger 0.5'ten buyuk esitse 1, degilse -1 donderen metot.
	 */
	private  int esikDegeriBul(double[] girdiArray)
    {
		if(toplamaIslemi(girdiArray) >= 0.5)
        {
			return 1;
        } else
        {
			return -1;
        }
    }
	/*
	 * Neronun agirliklarini uygun oranlarda azaltip arttirarak neuronu egiten metot.
	 * Bir veri setini parametre olarak alir ve tahmin eder. Her yanlis buldugunda agirliklarini duzelterek
	 * Daha dogru sekilde tahmin etmeye baslar.
	 */
	public void egit(double[] girdiArray)
    {
		egitimDegeri++; // Her egitildiginde bir art.

		int output = esikDegeriBul(girdiArray); // verilen veri setinin esik degerini bul.
		int target =(int) girdiArray[girdiArray.Length - 1]; // Verilen veri setinin beklenen cevabini al.
		// Ogrenme katsayisini hesapla.
		double ogrenmeKatsayisi = LAMBDA * (target - output);

		/*
		 * Eger beklenen deger 1 ve neuronumuzun buldugu deger -1 ise agirligimizi; 
		 * veri setinin uygun elemani ve ogrenme katsayimizin carpimi kadar arttirmaliyiz.
		 */
		if(output == -1 && target == 1)
        {
			for (int i = 0; i < 2; i++)
			{
				agirlikArray[i] += (girdiArray[i] * ogrenmeKatsayisi);

			}
		}
		/*
		 * Ama eger beklenen deger -1 ve neuronumuzun buldugu deger 1 ise agirligimizi; 
		 * veri setinin uygun elemani ve ogrenme katsayimizin carpimi kadar azaltmaliyiz.
		 * 
		 * NOT: Burada azaltmaliyiz deyip, yine de topladik. 
		 * Cunku (target - output) degeri zaten negatif bir degerdir.
		 * Eger biz -= yapip cikartacak olursak, agirliklarimizi yine arttirmis oluruz.
		 */
		else if (output == 1 && target == -1)
		{
			for (int i = 0; i < 2; i++)
			{
				agirlikArray[i] += (girdiArray[i] * ogrenmeKatsayisi);
			}
		}
		/*
		 * Eger beklenen deger ile neuronumuzun buldugu deger ayni ise agirliklara bir sey yapma.
		 * Ama neuron dogru buldugu icin dogruluk degerini bir arttir.
		 */
		else
        {
			dogrulukDegeri++;
        }
    }
}