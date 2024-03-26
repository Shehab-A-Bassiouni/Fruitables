using FruitablesBL.EntityManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.ViewModels
{
    public class DashboardVM
    {
        public List<dashboardRec> salesRecs = new List<dashboardRec>();
        public List<bestSellingRec> bestSellingRecs = new List<bestSellingRec>();
    }
}
