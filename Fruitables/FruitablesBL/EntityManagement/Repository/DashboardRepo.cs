using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Repository
{


    public class DashboardRepo : IDashboardrepo
    {
        private readonly FRUITABLESContext fruitableContext;
        //private readonly global fruitableContext;
        public DashboardRepo(FRUITABLESContext ctx)
        {
            fruitableContext = ctx;
        }

        public DashboardVM GetAllSalesData(int userID)
        {
            DashboardVM dashVM = new DashboardVM();
            dashVM.salesRecs = getsalesDAta(userID);

            return dashVM;
        }

        public List<bestSellersRec> GetbestSelers(int year)
        {
            try
            {
                var results = fruitableContext.Database.SqlQuery<bestSellersRec>($"EXEC getBestSelelrs {year}").ToList();
                return results ?? new List<bestSellersRec>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new List<bestSellersRec>();
            }

           
        }

        public List<bestSellingRec> GetBestSellingData(int year, int userID)
        {
            try
            {
                var results = fruitableContext.Database.SqlQuery<bestSellingRec>($"EXEC GetBestSellProduct {userID},  {year}").ToList();
                return results ?? new List<bestSellingRec>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new List<bestSellingRec>();
            }
            
        }

        public List<monthsSalesRec> GetMonthSalesDAta(int year, int userID)
        {
            try
            {

            
            var results = fruitableContext.Database.SqlQuery<monthsSalesRec>($"EXEC GetMonthRevenue {userID},  {year}").ToList();
            return results ?? new List<monthsSalesRec>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new List<monthsSalesRec>();
            }
        }

        public List<dashboardRec> getsalesDAta(int userID)
        {
            try
            {

                var results = fruitableContext.Database.SqlQuery<dashboardRec>($"EXEC GetSellerStatistics {userID}").ToList();
                return results;
            }
            catch (Exception ex) {
                Debug.WriteLine(ex);    
                return new List<dashboardRec>();
            }
        }

       

        
    }
}
//$"exec SelectAllProductsAbovePrice {PrdPrice}"