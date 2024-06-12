using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Factory
{
    public class MakeUpBrandFactories
    {
        public static MakeupBrand CreateMakeUpBrand(int id, string name, int rating)
        {
            return new MakeupBrand
            {
                MakeupBrandID = id,
                MakeupBrandName = name,
                MakeupBrandRating = rating
            };
        }
    }
}