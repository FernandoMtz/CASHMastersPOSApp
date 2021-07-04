using System;

namespace  CashMastersPOS
{
public static class GlobalDenominations
{
    // Current valid countries string values are: Mexico, US
    public static decimal [] ObtainDenominationsByCountry(string countryName)
    {
        switch(countryName)
        {
            case "Mexico": return MexicoDenominations();

            case "US" : return USDenominations();

            default: return MexicoDenominations();
        }
    }
    private static decimal[] MexicoDenominations()
    {
        return new decimal[] {0.05m, 0.10m, 0.20m, 0.50m, 1.00m, 2.00m, 5.00m, 10.00m, 20.00m, 50.00m, 100.00m};
    }

    private static decimal[] USDenominations()
    {
        return new decimal[] {0.01m, 0.05m, 0.10m, 0.25m, 0.50m, 1.00m, 2.00m, 5.00m, 10.00m, 20.00m, 50.00m, 100.00m};
    }
}

}
