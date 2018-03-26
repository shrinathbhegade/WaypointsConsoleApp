using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouteWorker;


namespace RouteHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker work = new Worker();

            Int32 option1 = DisplayMainMenu();
            MainCall(option1);
            Console.Read();
        }

   
        private static void MainCall(Int32 option)
        {
            Worker work=new Worker();
            double latd;
            double longd;

            switch (option)
            {
                case 1:
                    GetInput(out latd, out longd);

                    Int32 res = work.SearchLocation(latd, longd);
                    if (res != 0)
                    {
                        Console.WriteLine("Waypoint is available at line no" + res);
                    }
                    else
                        Console.WriteLine("Waypoint is not available");
                    Int32 option1 = DisplayMainMenu();
                    MainCall(option1);
                    break;

                case 2:                    
                    work.DisplayAllLocations();
                    option1 = DisplayMainMenu();
                    MainCall(option1);
                    break;
                case 3:
                    GetInput(out latd, out longd);
                    work.GetLowerLocations(latd, longd);
                    option1 = DisplayMainMenu();
                    MainCall(option1);
                    break;
                case 4:
                    GetInput(out latd, out longd);
                    work.GetHigherLocations(latd, longd);
                    option1 = DisplayMainMenu();
                    MainCall(option1);
                    break;
                case 5:
                    Console.WriteLine("exit");
                    break;
                default:
                    Console.WriteLine("Invalid Input!!!!!!Re-Enter");
                    option1 = DisplayMainMenu();
                    MainCall(option1);
                    break;
            }
        }

        private static void GetInput(out double latd, out double longd)
        {
            Console.WriteLine("\nEnter latitude");
            latd = double.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter longitude");
            longd = double.Parse(Console.ReadLine());
        }

        private static int DisplayMainMenu()
        {
            Console.WriteLine("\nSelect any option:");
            Console.WriteLine("1. Select a file:");
            Console.WriteLine("2. Search Location");
            Console.WriteLine("3. Display All Locations");
            Console.WriteLine("4. Display Lower Latitude and Longitude");
            Console.WriteLine("5. Display Higher Latitude and Longitude");
            Console.WriteLine("6. Exit");

            Int32 option = 0;
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
                
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input Please try again");
            }
            return option;
        }

     
        }
}

