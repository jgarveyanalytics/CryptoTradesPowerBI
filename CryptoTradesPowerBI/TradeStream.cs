using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Binance.Net;
using Binance.Net.Objects.Spot;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using Newtonsoft.Json;

namespace CryptoTradesPowerBI
{
    class TradeStream
    {
        // Client required for posting to Power BI
        static HttpClient httpClient = new HttpClient();

        // Initiate stream
        public static void InitiateStream(string binanceAPIKey, string binanceAPISecret, string symbol, string powerBIAPIURL)
        {

            // Trade aggregations
            int tradeCount = 0;
            decimal cumulativeQuantity = 0;

            // Configure websocket
            BinanceSocketClient.SetDefaultOptions(new BinanceSocketClientOptions()
            {
                ApiCredentials = new ApiCredentials(binanceAPIKey, binanceAPISecret),
                LogVerbosity   = LogVerbosity.None, // Change to Debug if required
                LogWriters     = new List<TextWriter> { Console.Out },
            });

            var socketClient = new BinanceSocketClient();
            Console.WriteLine("Connecting to Binance Websocket @ " + socketClient.BaseAddress + "\n");

            // Binance exposes many streams and we can connect to whichever ones we want
            // Here we are connecting to trade updates for a specified pair
            var successSingleTicker = socketClient.Spot.SubscribeToTradeUpdates(symbol, data =>
            {
                // Increment aggregations
                tradeCount++;
                cumulativeQuantity += data.Quantity;

                // Create Trade instance
                var trade = new Trade(symbol, data.TradeTime, tradeCount, cumulativeQuantity, data.Price, data.Quantity);

                // Convert to string
                var jsonString = JsonConvert.SerializeObject(trade);

                // Write to console
                Console.WriteLine(jsonString + "\n");

                // Post to Power BI Streaming Dataset
                try
                {
                    var postToPowerBi = PowerBIPostAsync(powerBIAPIURL, "[" + jsonString + "]");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            });

            Console.ReadLine();
        }

        // Ansyc post to Power BI method
        static async Task<HttpResponseMessage> PowerBIPostAsync(string pbiurl, string tradeEvent)
        {
            HttpContent         content  = new   StringContent(tradeEvent);
            HttpResponseMessage response = await httpClient.PostAsync(pbiurl, content);
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}