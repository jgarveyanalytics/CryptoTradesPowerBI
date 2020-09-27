using System;

namespace CryptoTradesPowerBI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Import Binance & Power BI config
            var binanceAPIKey    = APIConfig.GetBinanceAPIKey();
            var binanceAPISecret = APIConfig.GetBinanceAPISecret();
            var binanceSymbol    = APIConfig.GetBinanceSymbol();
            var powerBIAPIURL    = APIConfig.GetPowerBIAPIURL();

            try
            {
                // Start Stream
                Console.WriteLine("**** Powering up Binance to Power BI {0} stream ****\n", binanceSymbol);
                TradeStream.InitiateStream(binanceAPIKey, binanceAPISecret, binanceSymbol, powerBIAPIURL);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}