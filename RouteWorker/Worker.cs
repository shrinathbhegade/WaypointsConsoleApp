using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RouteReader;
using System.Collections;

namespace RouteWorker
{
    public class Worker
    {

        public Int32 SearchLocation(double latd, double longd)
        {
            Int32 loc = 0;

            Reader read = new Reader();
            List<string> list = read.ReadRout();
            ArrayList positions = read.ConvertDegreeAngleToDouble(list);

            foreach(object item in positions)
            {
                WayPoint wp =(WayPoint) item;
                loc++;
                wp.Latitude = Math.Round(wp.Latitude, 2);
                wp.Longitude = Math.Round(wp.Longitude, 2);
                if (wp.Latitude == latd && wp.Longitude == longd)
                {
                    return loc;
                }
                
            }
            return loc; 
        }

        public void DisplayAllLocations()
        {
            Reader read = new Reader();
            List<string> list = read.ReadRout();
            ArrayList positions = read.ConvertDegreeAngleToDouble(list);

            Console.WriteLine($"\t   Latitude\t\t   Longitude");
            Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");

            foreach (object item in positions)
            {
                WayPoint obj = (WayPoint)item;
                Console.WriteLine($"\t{obj.Latitude}\t{obj.Longitude}");

            }
        }

        public void GetHigherLocations(double latd, double longd)
        {
            

            Reader read = new Reader();
            List<string> list = read.ReadRout();
            ArrayList positions = read.ConvertDegreeAngleToDouble(list);
            Console.WriteLine($"\nAll the latitude and longitude larger than {latd} and {longd} are :\n");
            Console.WriteLine($"\t   Latitude\t\t   Longitude");
            Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            foreach (object item in positions)
            {
                WayPoint wp = (WayPoint)item;
                if (wp.Latitude > latd && wp.Longitude > longd)
                {
                    Console.WriteLine($"\t{wp.Latitude}\t{wp.Longitude}");
                }                
            }
        }
        public void GetLowerLocations(double latd, double longd)
        {
            Reader read = new Reader();
            List<string> list = read.ReadRout();
            ArrayList positions = read.ConvertDegreeAngleToDouble(list);
            Console.WriteLine($"\nAll the latitude and longitude smaller than {latd} and {longd} are :\n");
            Console.WriteLine($"\t   Latitude\t\t   Longitude");
            Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            foreach (object item in positions)
            {
                WayPoint wp = (WayPoint)item;
                if (wp.Latitude < latd && wp.Longitude < longd)
                {
                    Console.WriteLine($"\t{wp.Latitude}\t{wp.Longitude}");
                }
            }



        }

        private static void GetInput(out double latd, out double longd)
        {
            Console.WriteLine("Enter latitude");
            latd = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter longitude");
            longd = double.Parse(Console.ReadLine());
        }

    }
}
