using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Interface
{
    public record dashboardRec(decimal todaySales, decimal yesterDaySales, decimal monthSales, decimal lastmonthSales);
    public record monthsSalesRec(int Month, decimal TotalSales);
    public record bestSellingRec(string pname, int quantity);
    public record bestSellersRec(string Commercialname, decimal totalSales);

    public interface IDashboardrepo
    {
        public List<dashboardRec> getsalesDAta(int userID);
        List<monthsSalesRec> GetMonthSalesDAta(int year, int userID);
        List<bestSellingRec> GetBestSellingData(int year, int userID);
        DashboardVM GetAllSalesData(int userID);
        List<bestSellersRec> GetbestSelers(int year);


    }
}
