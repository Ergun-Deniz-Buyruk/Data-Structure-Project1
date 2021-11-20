using System;

public class Neuron
{
	public const double LAMBDA = 0.05;

	private double[] girdiArray;
	private double[] agirlikArray;

	private int dogrulukDegeri;
	Random rastgele = new Random();

	public Neuron()
	{
		agirlikArray = new double[2];
		for (int i = 0; i < 2; i++)
		{
			agirlikArray[i] = 2 * rastgele.NextDouble() - 1;
		}
		dogrulukDegeri = 0;
	}
	public void setGirdiArray(double[] girdiArray)
    {
		this.girdiArray = girdiArray;
	}

	public int getDogrulukDegeri()
    {
		return dogrulukDegeri;
    }

	private double toplamaIslemi()
    {
		double sonuc = 0;
		for(int i = 0; i < girdiArray.Length - 1; i++)
        {
			sonuc += girdiArray[i] * agirlikArray[i];
        }
		return sonuc;
    }

	private  int esikDegeriBul()
    {
		if(toplamaIslemi() >= 0.5)
        {
			return 1;
        } else
        {
			return -1;
        }
    }
	public void egit()
    {
		int output = esikDegeriBul();
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
