﻿using System;

namespace CryptoTradesPowerBI
{
    public class Trade
    {
        // This class represents a Trade
        // A Trade object is instantiated using the stream event returned from Binance
        // The Trade data is then pushed to the Power BI Streaming Dataset

        public readonly string  Symbol;             // e.g. BTCUSDT
        public readonly string  Timestamp;          // Date & Time of the Trade
        public readonly decimal Price;              // Price Trade took place at
        public readonly int     TradeCount;         // # of Trades (including this) since stream began
        public readonly decimal AverageQuantity;    // Average Trade quantity
        public readonly decimal CumulativeQuantity; // Cumulative Trade quantity (including this)
        public readonly decimal Quantity;           // This Trade's quantity

        public Trade(string symbol, DateTime timestamp, int previousTradeCount, decimal previousCumulativeQuantity, decimal price, decimal quantity)
        {
            Symbol             = symbol;
            Timestamp          = timestamp.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"); // Power BI expects this format
            TradeCount         = previousTradeCount++;
            CumulativeQuantity = previousCumulativeQuantity + quantity;
            AverageQuantity    = CumulativeQuantity / TradeCount;
            Price              = price;
            Quantity           = quantity;
        }
    }
}