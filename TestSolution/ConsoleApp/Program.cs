using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var deliveryTimeList = new List<DeliveryTime>() 
            //{
            //    new DeliveryTime{StartTime = "06:00"},
            //    new DeliveryTime{StartTime = "13:00"},
            //    new DeliveryTime{StartTime = "10:00"},
            //    new DeliveryTime{StartTime = "09:00"},
            //    new DeliveryTime{StartTime = "08:00"},
            //};

            //var hoursDiference = (DateTime.Now - DateTime.Now.ToUniversalTime()).TotalHours;

            //deliveryTimeList.ForEach(deliveryTime => 
            //{ 
            //    deliveryTime.StartTimeToSort = Convert.ToDateTime(deliveryTime.StartTime).AddHours(hoursDiference);
            //});

            //deliveryTimeList = deliveryTimeList.OrderBy(deliveryTime => deliveryTime.StartTimeToSort.TimeOfDay.TotalHours).ToList();


            var dict = new Dictionary<string, string> 
            {
                {"keyOne", "valueOne" },
                {"keyTwo", "valueTwo" },
                {"keyThree","" },
            };
            


            Console.WriteLine(dict.Keys.Contains("keyThree"));
        }
    }

    public class DeliveryTime
    {
        public string StartTime { get; set; }
        public DateTime StartTimeToSort { get; set; }
    }
}
