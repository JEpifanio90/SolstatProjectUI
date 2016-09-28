using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolstatProject.Models;

namespace SolstatProjectUI.HelperClasses
{
    public class EvaluacionEconomicaServices
    {
        
        private double _vpn { get; set; }
        
        private double _averageInflation { get; set; }

        public static DateTime startDate { get; set; }
        public static DateTime endDate { get; set; }
        public static double InitialInvestment { get; set; }
        public static double EnergyProduction { get; set; }
        public static double EnergyPrice { get; set; }
        public EvaluacionEconomicaServices()
        {
            _vpn = 0;
            _averageInflation = 0;
        }
        
        public double CalculateVPN(double initialInvestment,List<double> incomes,double discountRate)
        {
            int count = 1;
            _vpn = -InitialInvestment;
            if (incomes != null)
            {
                foreach (double income in incomes)
                {
                    _vpn = _vpn + (income / Math.Pow((1 + discountRate), count));
                    count++;
                }
            }
            
            return _vpn;
        }
        
        public List<double> CalculateIncomes(double energyProduction)
        {
            List<double> result = new List<double>();
            var months = (( endDate.Year - startDate.Year) * 12) + startDate.Month - startDate.Month;
            var avgEnergyPerMonth = EnergyProduction / 12;
            
            for(int i = 0; i < months; i++)
            {
                result.Add(avgEnergyPerMonth * EnergyPrice);
            }
            

            return result;
        }

        public void SetInflation(double inflation)
        {
            if (inflation <100)
            {
                _averageInflation = inflation;
            }
        }
        public double GetAverageInflation()
        {
            return _averageInflation;
        }
        public double GetVPN()
        {
            return _vpn;
        }



    }
}
