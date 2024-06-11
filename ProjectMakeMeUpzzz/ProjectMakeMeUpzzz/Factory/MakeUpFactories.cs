using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;
namespace ProjectMakeMeUpzzz.Factory
{
    public class MakeUpFactories
    {
  
            public static Makeup CreateMakeup(int makeupID, string makeupName, int makeupPrice, int makeupWeight, int makeupTypeID, int makeupBrandID) 
            {
            return new Makeup
            {
                MakeupID = makeupID,
                MakeupName = makeupName,
                MakeupWeight = makeupWeight,
                MakeupTypeID = makeupTypeID,
                MakeupBrandID = makeupBrandID
            };


            }

        internal static Makeup CreateMakeup(string makeupName, int makeupPrice, int makeupWeight, int makeupTypeID, int makeupBrandID)
        {
            throw new NotImplementedException();
        } 
    }
    }
