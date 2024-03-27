using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;

namespace Fruitables.Models.Success
{
    public class SuccessModel
    {
        private readonly IMemoryCache _memoryCache;
        private readonly FRUITABLESContext context;
        private int UserID;


        public SuccessModel(IMemoryCache memoryCache, FRUITABLESContext _context, int _UserID)
        {
            _memoryCache = memoryCache;
            context = _context;
            UserID = _UserID;
        }

       
    }
}
