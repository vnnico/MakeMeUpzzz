using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Factory
{
    public class MakeUpTypeFactories
    {
        public static MakeupType CreateMakeupType(int id,  string name)
        {
            return new MakeupType
            {
                MakeupTypeID = id,
                MakeupTypeName = name
            };
        }
    }
}