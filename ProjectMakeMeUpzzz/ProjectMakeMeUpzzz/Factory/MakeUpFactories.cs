using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;
namespace ProjectMakeMeUpzzz.Factory
{
    public class MakeUpFactories
    {
  
            public static Makeup CreateMakeup(int id, string Name, int Price, int Weight, int TypeID, int BrandID) 
            {
            return new Makeup
            {
                MakeupID = id,
                MakeupName = Name,
                MakeupWeight = Weight,
                MakeupTypeID = TypeID,
                MakeupBrandID = BrandID
            };


            }
        }
    }
