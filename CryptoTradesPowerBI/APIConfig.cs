using System;

namespace CryptoTradesPowerBI
{
    class APIConfig
    {
        // Binance & Power BI configuration data

        // Binance API
        private static string _binanceAPIKey    = Environment.GetEnvironmentVariable("BinanceAPIKey");
        private static string _binanceAPISecret = Environment.GetEnvironmentVariable("BinanceAPISecret");
        private static string _binanceSymbol    = "BTCUSDT";

        // Power BI API
        private static string _powerBIAPIURL    = "https://api.powerbi.com/beta/1ff6f94d-008d-4da7-87f3-43fa69d29431/datasets/866dff07-50a1-4f01-bc6b-166c53256d84/rows?key=2AAYHjWUUublbLxTMxaPvJjmxoePp0Vjh7JGbGZe%2F7UdymTfxuD%2BI3UnBzcYd4tq6cNGaHPybMXpeIe7211B%2Bw%3D%3D";

        public static string GetBinanceAPIKey()
        {
            return _binanceAPIKey;
        }

        public static string GetBinanceAPISecret()
        {
            return _binanceAPISecret;
        }

        public static string GetBinanceSymbol()
        {
            return _binanceSymbol;
        }

        public static string GetPowerBIAPIURL()
        {
            return _powerBIAPIURL;
        }
    }
}