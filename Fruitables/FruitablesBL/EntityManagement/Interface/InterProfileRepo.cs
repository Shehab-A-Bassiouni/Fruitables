using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FruitablesBL.EntityManagement.Interface
{
    public interface InterProfileRepo
    {
        ProfileVM GetProfile(int userId);
        void UpdateProfile(ProfileVM profile);

    }
}
