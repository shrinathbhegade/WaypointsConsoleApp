using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace RouteReader
{
   public class Reader
    {
    
      
        public List<string> ReadRout()
        {
            try
            {
                List<string> ReadFile = File.ReadAllLines("sample.txt").ToList();
                return ReadFile;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception related to file");
            }
            return null;
                


            
        }

        public ArrayList ConvertDegreeAngleToDouble(List<string> list)
        {
            double degrees;
            double minutes;
            double seconds;

            ArrayList cordinates = new ArrayList();

            foreach (string point in list)
            {
                WayPoint wp = new WayPoint();
                string position = point;
                var multiplier = (point.Contains("S") || point.Contains("W")) ? -1 : 1;

                position = Regex.Replace(position, "[^.0-9 ]", "");
                position = Regex.Replace(position, "[^0-9]", " ");

                string[] digits = position.Split('.', ' ');
                
                degrees = double.Parse(digits[0]);
                minutes = double.Parse(digits[1]) / 60;
                seconds = double.Parse(digits[2]) / 3600;
                wp.Latitude = (degrees + minutes + seconds) * multiplier;
                degrees = double.Parse(digits[3]);
                minutes = double.Parse(digits[4]) / 60;
                seconds = double.Parse(digits[5]) / 3600;
                wp.Longitude = (degrees + minutes + seconds) * multiplier;
                cordinates.Add(wp);
            }
            return cordinates;
        }
    }
}
