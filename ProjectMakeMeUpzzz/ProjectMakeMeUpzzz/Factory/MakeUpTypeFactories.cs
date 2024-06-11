using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Factory
{
    public class MakeUpTypeFactories
    {
        public static MakeupType CreateMakeupType(int makeupTypeID,  string makeupTypeName)
        {

            return new MakeupType
            {
                MakeupTypeID = makeupTypeID,
                MakeupTypeName = makeupTypeName
            };

        }
    }
}