using System;

namespace  POSChangeCalculator
{
public static class GlobalDenominations
{
    // Current valid countries string values are: Mexico, US
    public static double [] ObtainDenominationsByCountry(string countryName)
    {
        switch(countryName)
        {
            case "Mexico": return MexicoDenominations();

            case "US" : return USDenominations();

            default: return MexicoDenominations();
        }
    }
    private static double[] MexicoDenominations()
    {
        return new double[] {0.05, 0.10, 0.20, 0.50, 1.00, 2.00, 5.00, 10.00, 20.00, 50.00, 100.00};
    }

    private static double[] USDenominations()
    {
        return new double[] {0.01, 0.05, 0.10, 0.25, 0.50, 1.00, 2.00, 5.00, 10.00, 20.00, 50.00, 100.00};
    }
}

}
