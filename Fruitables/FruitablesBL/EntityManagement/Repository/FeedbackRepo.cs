using FruitablesBL.EntityManagement.Interface;
using FruitablesDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Repository
{
    public class FeedbackRepo : IFeedBackRepo
    {
        public FRUITABLESContext Context {  get; set; }
        public FeedbackRepo(FRUITABLESContext context)
        {
            Context = context;
        }

        List<FeedBack> IFeedBackRepo.GetAllFeedbacks(int ProdId)
        {
            var FeedBackResult = Context.FeedBacks.Where(fb=>fb.ProductId==ProdId)
                                .Include(fb=>fb.Customer).ThenInclude(c=>c.CustomerNavigation).ToList();
            return FeedBackResult;
        }

        FeedBack IFeedBackRepo.GetFeedbackById(int id)
        {
            return  Context.FeedBacks.Include(fb => fb.Customer).ThenInclude(c => c.CustomerNavigation)
                            .FirstOrDefault(fb => fb.FeedbackId == id);

        }

        List<FeedBack> IFeedBackRepo.GetFeedbackByRate(int ProdId , int rate)
        {
            var FeedBackResult = Context.FeedBacks.Where(fb=>fb.Rate == rate && fb.ProductId==ProdId)
                                                    .Include(fb => fb.Customer).ThenInclude(c => c.CustomerNavigation)
                                                   .ToList();
            return FeedBackResult;
        }

        void IFeedBackRepo.CreateFeedback(FeedBack feedBack)
        {
            if (feedBack != null)
            {
                Context.Add(feedBack);
                Context.SaveChanges();
            }
        }

        void IFeedBackRepo.EditFeedback(FeedBack feedBack)
        {
            FeedBack EditedFeedBack = Context.FeedBacks.Find(feedBack.FeedbackId);
            if (EditedFeedBack != null)
            {
                EditedFeedBack.Review = feedBack.Review;
                EditedFeedBack.Rate = feedBack.Rate;

                Context.SaveChanges();
            }
        }

        void IFeedBackRepo.DeleteFeedback(int id)
        {
            FeedBack DeletedFeedBack = Context.FeedBacks.Find(id);
            DeletedFeedBack.IsActive = false;
            Context.SaveChanges();
        }
        public int GetUserId(string userName)
        {
            return Context.Users.Where(U=>U.UserName == userName).Select(U => U.UserId).FirstOrDefault();
        }

    }
}
