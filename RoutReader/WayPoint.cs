using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteReader
{
   public class WayPoint
    {
        private double latitude;
        private double longitude;
        public double Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                latitude = value;
            }
        }
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude=value;
            }

        }

        public WayPoint()
        {
            Latitude = 0.0;
            Longitude = 0.0;
        }

        public WayPoint(double latd, double longd)
        {
            Latitude = latd;
            Longitude = longd;
        }
    }
}
