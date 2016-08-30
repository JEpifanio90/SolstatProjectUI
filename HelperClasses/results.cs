using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolstatProjectUI.HelperClasses
{
    class results
    {
        DateTime start, end;
        Double lat, lng, H0, days, ws = 0.00, oz = 0.00;
        public results(DateTime start, DateTime end, Double lat, Double longi)
        {
            this.start = start;
            this.end = end;
            this.lat = lat;
            this.lng = longi;
            doCalculations();

        }
        private void doCalculations()
        {
            DateTime aux;
            if (start > end)
            {
                aux = end;
                end = start;
                start = aux;
            }
            days = (end - start).TotalDays;
            int day = 0;
            for (double totalDays = 0; totalDays < days; totalDays++)
            {
                if (365 != day)
                {
                    double sConstant = 23.45 * Math.Sin((360.0 * ((284.0 + day) / 365.0)));
                    double tanSconstant = Math.Tan(sConstant);
                    double tanLatitude = -Math.Tan(lat);
                    double tanAngleTimesTanS = tanLatitude * tanSconstant;
                    if (Math.Acos(tanAngleTimesTanS) > 0)
                    {
                        ws = Math.Acos(tanAngleTimesTanS); //degrees
                    }
                    if ((Math.Cos(lat) * Math.Cos(sConstant) * Math.Sin(ws)) + (((Math.PI * ws) / 180) * Math.Sin(lat) * Math.Sin(sConstant)) > 0)
                    {
                        oz = (Math.Cos(lat) * Math.Cos(sConstant) * Math.Sin(ws)) + (((Math.PI * ws) / 180) * Math.Sin(lat) * Math.Sin(sConstant));
                    }
                    double radiationConstant = 0.333828427;
                    double x = 44567 / Math.PI;
                    double y = Math.Cos(360 * (day / 365));
                    double z = (1 + 0.033 * Math.Cos(360 * (day / 365)));
                    double a = ((x * (1 + 0.033 * y * oz)) / 1000000) * radiationConstant;
                    if (a > 0.00)
                    {
                        H0 = H0 + a;
                    }
                    day += 1;
                }
                else
                {
                    day = 0;
                }
            }
        }
        public double getLatitude() { return lat; }
        public double getLongitude() { return lng; }
        public double getDays() { return days; }
        public double getws() { return ws; }
        public double getoz() { return oz; }
        public double getH0() { return H0; }
        public double getYears() { return days / 365; }
    }
}
