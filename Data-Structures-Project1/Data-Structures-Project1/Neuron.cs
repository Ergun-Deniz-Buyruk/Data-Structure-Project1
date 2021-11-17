using System;

public class Neuron
{
	public static double LAMBDA = 0.05;
	private double[] girdiArray;
	private double[] agirlikArray;
	public int dogrulukDegeri;
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

	public double toplamaIslemi()
    {
		double sonuc = 0;
		for(int i = 0; i < girdiArray.Length - 1; i++)
        {
			sonuc += girdiArray[i] * agirlikArray[i];
        }
		return sonuc;
    }

	public int esikDegeriBul()
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
		double katsayi = LAMBDA * (target - output);

		if(output == -1 && target == 1)
        {
			for (int i = 0; i < 2; i++)
			{
				agirlikArray[i]+= agirlikArray[i] * katsayi;

			}
		}
		else if (output == 1 && target == -1)
        {
			for (int i = 0; i < 2; i++)
			{
				agirlikArray[i] -= agirlikArray[i] * katsayi;
			}
		} else if (output == -1 && target == -1 || output == 1 && target == 1)
        {
			dogrulukDegeri++;
        }
    }
}
