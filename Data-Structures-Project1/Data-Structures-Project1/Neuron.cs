using System;

public class Neuron
{
	public const double LAMBDA = 0.15;

	private double[] agirlikArray;
	public int dogrulukDegeri;
	public int egitimDegeri;
	Random rastgele = new Random();

	public Neuron()
	{
		agirlikArray = new double[2];
		for (int i = 0; i < 2; i++)
		{
			agirlikArray[i] = 2 * rastgele.NextDouble() - 1;
		}
		sifirla();
	}

	public double getDogrulukYuzdesi()
    {
		return dogrulukDegeri / (double)egitimDegeri * 100;
    }

	public void sifirla()
    {
		dogrulukDegeri = 0;
		egitimDegeri = 0;
    }

	private double toplamaIslemi(double[] girdiArray)
    {
		double sonuc = 0;
		for(int i = 0; i < girdiArray.Length - 1; i++)
        {
			sonuc += girdiArray[i] * agirlikArray[i];
        }
		return sonuc;
    }

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
	public void egit(double[] girdiArray)
    {
		egitimDegeri++;
		int output = esikDegeriBul(girdiArray);
		int target =(int) girdiArray[girdiArray.Length - 1];
		double ogrenmeKatsayisi = LAMBDA * (target - output);

		if(output == -1 && target == 1)
        {
			for (int i = 0; i < 2; i++)
			{
				agirlikArray[i] += agirlikArray[i] * ogrenmeKatsayisi;

			}
		} 
		else if (output == 1 && target == -1)
		{
			for (int i = 0; i < 2; i++)
			{
				agirlikArray[i] -= agirlikArray[i] * ogrenmeKatsayisi;
			}
		}
		else
        {
			dogrulukDegeri++;
        }
    }
}
