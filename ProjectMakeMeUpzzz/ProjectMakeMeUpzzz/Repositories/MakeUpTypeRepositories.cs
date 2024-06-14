using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Repositories
{
    public class MakeUpTypeRepositories
    {
        private static DatabaseEntities3 db = new DatabaseEntities3();

        public static List<MakeupType> GetAllMakeupTypes()
        {
            return db.MakeupTypes.ToList();
        }
        public static MakeupType GetMakeupTypeById(int id)
        {
            return db.MakeupTypes.Find(id);
        }
        public static MakeupType GetLastMakeupType()
        {
            return db.MakeupTypes.ToList().LastOrDefault();
        }

        public static int InsertMakeupType(MakeupType makeup)
        {
            db.MakeupTypes.Add(makeup);
            return db.SaveChanges();
        }
        public static MakeupType UpdateMakeupType(MakeupType makeup)
        {
            MakeupType updatedMakeupType = GetMakeupTypeById(makeup.MakeupTypeID);
            updatedMakeupType.MakeupTypeName = makeup.MakeupTypeName;
            db.SaveChanges();

            return makeup;
        }
        public static int DeleteMakeupTypeById(int id)
        {
            MakeupType deletedMakeupType = GetMakeupTypeById(id);


            if (deletedMakeupType != null)
            {
                db.MakeupTypes.Remove(deletedMakeupType);
            }

            return db.SaveChanges();
        }
    }
}