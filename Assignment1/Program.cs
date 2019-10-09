using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;


namespace Assignment1
{
    
    public class Station
    {
        public string id { get; set; }
        public string name { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public int bikesAvailable { get; set; }
        public int spacesAvailable { get; set; }
        public bool allowDropoff { get; set; }
        public bool isFloatingBike { get; set; }
        public bool isCarStation { get; set; }
        public string state { get; set; }

        public bool realTimeData { get; set; }
    }


    public class Stations
    {
        public List<Station> stations { get; set; }
    }

    class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
    {

        public string URL = "http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental";
        System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
        
    public Stations bikeRentalStationList;
        public async Task<String> GetUrlAsync()
        {

                Console.WriteLine("test");
                var result = await httpClient.GetStringAsync(URL);
                
                
                
                bikeRentalStationList = JsonConvert.DeserializeObject<Stations>(result);

               
                return result;
         }

        public async Task<int> GetBikeCountInStation(string stationName)
        {
            Exception NotFoundException = new Exception("Not Found");
            try
            {
                if (stationName.Any(char.IsDigit)){
                    throw new Exception("contains a number");
                }
                if (stationName == null) throw new ArgumentNullException ("asema on null");
                foreach(var item in bikeRentalStationList.stations)
                {
                //Console.WriteLine("id: {0}, name: {1}, available bikes: {2}",item.id,item.name,item.bikesAvailable);
                    if(item.name == stationName)
                    {
                        
                    Console.WriteLine("Aseman nimi: " + item.name + " Polkupyoria vapaana: " + item.bikesAvailable);
                        return item.bikesAvailable;
                    }
                }

                throw NotFoundException;
        
            
            }
            catch(Exception ex)
            {
                Console.WriteLine("Invalid argument: " + ex);
                
            }
            return 1;
        }

            public async void GetUrl()
            {
                Console.WriteLine("Test2");


                string[] nimet= {"Koivutori","Armas Launiksen katu", "Hagelstaminpuisto"} ;
                foreach (string nimi in nimet)
                {
                await GetBikeCountInStation(nimi);

                }

            }

    }

    class OfflineCityBikeDataFetcher : ICityBikeDataFetcher
    {
        public async Task<int> GetBikeCountInStation(string stationName){
            
            string[] lines = System.IO.File.ReadAllLines(@"bikedata.txt");
            foreach (var tekstiPatka in lines){
                if(tekstiPatka.Contains(stationName)){
                    Console.WriteLine(tekstiPatka);

                }
            }
            
            
            
        return 1;
        }
    }


    class Program
    {
            static async Task Main(string[] args)
            {
                if(args[0] == "realtime"){
                    RealTimeCityBikeDataFetcher realTimeCityBikeDataFetcher = new RealTimeCityBikeDataFetcher();
                    await realTimeCityBikeDataFetcher.GetUrlAsync();
                    realTimeCityBikeDataFetcher.GetUrl();
                
                  
                } 
		else if(args[0] == "offline")
                {
                    OfflineCityBikeDataFetcher offlineCityBikeDataFetcher = new OfflineCityBikeDataFetcher();
                    await offlineCityBikeDataFetcher.GetBikeCountInStation("Olympiastadion");
                    
                } 
		else 
		{

                    RealTimeCityBikeDataFetcher realTimeCityBikeDataFetcher = new RealTimeCityBikeDataFetcher();
                    await realTimeCityBikeDataFetcher.GetUrlAsync();
                    realTimeCityBikeDataFetcher.GetUrl();
                
                }   
            }
    }

    public interface ICityBikeDataFetcher
    {

        Task<int> GetBikeCountInStation(string stationName);

    }
}