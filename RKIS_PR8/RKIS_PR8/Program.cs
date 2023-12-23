using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class CityDefault
{
    public string City { get; set; }
    
    public CityDefault(string citydefault)
    {
        City = citydefault;
    }

}

namespace RKIS_PR8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\tДОБРО ПОЖАЛОВАТЬ! ^_^");
            
            CityDefault();
            
            bool exit = false;
            do
            {
                Console.WriteLine("\n\t0 - Просмотр погоды по городу\n\t1 - Выбор города по умолчанию\n\t2 - Выход из программы\n");
                int input = int.Parse(Console.ReadLine());
                
                switch (input)
                {
                    case 0:
                        Console.Write("Введите название города: ");
                        string city = Console.ReadLine();
                        ShowWeather(city);
                        break;
                    case 1:
                        Console.Write("Выберите город по умолчанию:");
                        string cityInput = Console.ReadLine();
                        CityDefault cityDefault = new CityDefault(cityInput);
                        CityDefaultEdit(cityDefault);
                        break;
                    case 2:
                        exit = true;
                        Console.WriteLine($"\n\tОДЕВАЙТЕСЬ ПО ПОГОДЕ!\n\tХОРОШЕГО ДНЯ! ^_^");
                        break;
                    default:
                        Console.WriteLine("Такой команды нет -_-");
                        break;
                }
            } while (exit != true);
            
        }

        public static void ShowWeather(string city)
        {
            ConnectToSite(city);
            JObject WeatherInfo = ReadFromJson();
            Console.WriteLine($"\n---> Погода в городе {WeatherInfo["name"]} <---\n{WeatherInfo["main"]["temp"]},\tПо ощущениям {WeatherInfo["main"]["feels_like"]}");
            Console.WriteLine($"Ветер {WeatherInfo["wind"]["speed"]} м/с,\tДавление {WeatherInfo["main"]["pressure"]} гПа");
            Console.WriteLine($"Влажность {WeatherInfo["main"]["humidity"]}%,\tВидимость {WeatherInfo["visibility"]} м");
        }
        
        public static void CityDefault()
        {
            string fileName = @"D:\ТТИТ\РКИС\Практика\КОДЫ\RKIS_PR8\CityDefault.json";

            string cityInJson = File.ReadAllText(fileName);
            
            CityDefault cityDefault = JsonConvert.DeserializeObject<CityDefault>(cityInJson);
            
            if (cityDefault != null)
            {
                ConnectToSite(cityDefault.City);
                ShowWeather(cityDefault.City);
            }
        }
        public static void CityDefaultEdit(CityDefault cityDefault)
        {   
            string fileName = @"D:\ТТИТ\РКИС\Практика\КОДЫ\RKIS_PR8\CityDefault.json";
            string serialized = JsonConvert.SerializeObject(cityDefault);
            File.WriteAllText(fileName, serialized);
        }
        
        public static void ConnectToSite(string city)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&appid=b113a0b21ae5effee075f2fdbbdbbac7";
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            
            string responseText;
            
            Stream stream = response.GetResponseStream();
            
            using (StreamReader reader = new StreamReader(stream))
            {
                responseText = reader.ReadToEnd();
            }
            
            JObject responceTextInJo = JObject.Parse(responseText);

            string fileName = @"D:\ТТИТ\РКИС\Практика\КОДЫ\RKIS_PR8\InfoFromSite.json";
            
            string serializedResponce = JsonConvert.SerializeObject(responceTextInJo);

            File.WriteAllText(fileName, serializedResponce);
        }
        
        public static JObject ReadFromJson()
        {
            string fileName = @"D:\ТТИТ\РКИС\Практика\КОДЫ\RKIS_PR8\InfoFromSite.json";
            string textJson =  File.ReadAllText(fileName);
            JObject TextJo = JsonConvert.DeserializeObject<JObject>(textJson); 
            return TextJo;
        }
        
    }
}