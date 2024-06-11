using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;
namespace ProjectMakeMeUpzzz.Factory
{
    public class MakeUpFactories
    {
  
            public static Makeup CreateMakeup(int MakeupID, string MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID) 
            {
            return new Makeup
            {
                MakeupID = MakeupID,
                MakeupName = MakeupName,
                MakeupWeight = MakeupWeight,
                MakeupTypeID = MakeupTypeID,
                MakeupBrandID = MakeupBrandID
            };


            }

        internal static Makeup CreateMakeup(string makeupName, int makeupPrice, int makeupWeight, int makeupTypeID, int makeupBrandID)
        {
            throw new NotImplementedException();
        }
    }
    }
