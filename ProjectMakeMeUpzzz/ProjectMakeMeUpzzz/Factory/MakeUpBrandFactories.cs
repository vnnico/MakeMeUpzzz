using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Factory
{
    public class MakeUpBrandFactories
    {
        public static MakeupBrand CreateMakeUpBrand(int MakeupBrandID, string MakeupBrandName, int MakeupBrandRating)
        {
            return new MakeupBrand
            {
                MakeupBrandID = MakeupBrandID,
                MakeupBrandName = MakeupBrandName,
                MakeupBrandRating = MakeupBrandRating
            };
        }
    }
}