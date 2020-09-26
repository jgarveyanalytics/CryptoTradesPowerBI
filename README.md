# CryptoTradesPowerBI
### A simple .Net Core console application that streams crypto trades from an Exchange to a Power BI Streaming Dataset

### Credits
* Chris Koester. For inspiration on how to [push data from .Net to a Power BI Streaming Dataset](https://chris.koester.io/index.php/2017/11/05/push-data-into-power-bi-streaming-datasets-with-csharp/).
* [Jan Korf] (https://github.com/JKorf). For his contribution to Crypto Exchange API Extensibility.

### How it came about
The idea behind this application was to come up with a simple program that I could write about in my first blog post. The program had to encompass my hobbies including cryptocurrencies, trading and analytics.

### Components
* Power BI Dashboard
* Power BI Streaming Dataset
* Data Source - Binance Exchange 
* Core Application

### Conceptual Workflow
Information related to live trades on the Binance Exchange are retreived by the application and sent to Power BI to display on a dashboard.

### Technical Overview
The program opens a websocket connection to the Binance Exchange and pushes trade events onto a Power BI streaming Dataset. Power BI consumes the events by pushing data in real-time to a dashboard.

#### Running the program / Accounts
To run the program, users will need in addition to Visual Studio:
* Power BI account
* Binance Exchange Account
* Binance API
* Power BI Streaming Dataset & API Endpoint

#### Endpoints
* Binance (Websocket API URL)
* Power BI (Streaming Dataset API URL)

#### Program External dependencies
* Binance.Net ([Jkorf](https://github.com/JKorf), Nikkozp, CaptHolley)
* CryptoExchange.Net ([Jkorf](https://github.com/JKorf))

#### Environment Variables
* BinanceAPIKey
* BinanceAPISecret

#### Power BI Streaming Dataset
##### Type
API

##### Schema
Field | Data Type
----- | -----
Symbol | Text
Timestamp | DateTime
Price | Number
Quantity | Number
PriceFormatted | Text
AverageQuantity | Number
CumulativeQuantity | Number
TradeCount | Number

##### Historic Data Analysis
Disabled
