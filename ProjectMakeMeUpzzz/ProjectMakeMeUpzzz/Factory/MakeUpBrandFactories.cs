using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Factory
{
    public class MakeUpBrandFactories


    {
        public static MakeupBrand CreateMakeUpBrand(int makeupBrandID, string makeupBrandName, int makeupBrandRating)
        {
            return new MakeupBrand
            {
                MakeupBrandID = makeupBrandID,
                MakeupBrandName = makeupBrandName,
                MakeupBrandRating = makeupBrandRating
            };
        }
    }
}