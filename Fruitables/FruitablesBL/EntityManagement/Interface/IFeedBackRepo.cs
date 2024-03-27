using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Interface
{
    public interface IFeedBackRepo
    {
        public List<FeedBack> GetAllFeedbacks(int ProdId);

        public List<FeedBack> GetFeedbackByRate(int ProdId, int rate);

        public FeedBack GetFeedbackById(int id);

        public void EditFeedback(FeedBack feedBack);

        public void DeleteFeedback(int id);

        public void CreateFeedback(FeedBack feedBack);

        public int GetUserId(string userName);
    }
}
