using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;
namespace ProjectMakeMeUpzzz.Factory
{
    public class MakeUpFactories
    {
  
            public static Makeup CreateMakeup(int id, string name, int price, int weight, int typeid, int brandid) 
            {
            return new Makeup
            {
                MakeupID = id,
                MakeupName = name,
                MakeupPrice = price,
                MakeupWeight = weight,
                MakeupTypeID = typeid,
                MakeupBrandID = brandid
            };



        }

  
    }
    }
