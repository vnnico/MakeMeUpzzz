using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Repositories
{
    public class MakeUpRepositories
    {
        private static DatabaseEntities3 db = new DatabaseEntities3();
        public static List<Makeup> GetAllMakeups()
        {
            return db.Makeups.ToList();
        }

        public static List<Makeup> GetAllMakeupsByMakeupTypeId(int typeId)
        {
            return db.Makeups.Where(x => x.MakeupTypeID == typeId).ToList();
        }
        public static List<Makeup> GetAllMakeupsByBrandId(int brandId)
        {
            return db.Makeups.Where(x => x.MakeupBrandID == brandId).ToList();
        }

        public static Makeup GetMakeupById(int id)
        {
            return db.Makeups.Find(id);
        }
        public static Makeup GetLastMakeup()
        {
            return db.Makeups.ToList().LastOrDefault();
        }


        public static int InsertMakeup(Makeup makeup)
        {
            db.Makeups.Add(makeup);
            return db.SaveChanges();
        }

        public static Makeup UpdateMakeup(Makeup makeup)
        {
            Makeup updatedMakeup = GetMakeupById(makeup.MakeupID);

            updatedMakeup.MakeupName = makeup.MakeupName;
            updatedMakeup.MakeupPrice = makeup.MakeupPrice;
            updatedMakeup.MakeupWeight = makeup.MakeupWeight;
            updatedMakeup.MakeupTypeID = makeup.MakeupTypeID;
            db.SaveChanges();
            return makeup;
        }

        public static Makeup DeleteMakeup(int id)
        {
            Makeup deletedMakeup = GetMakeupById(id);
            if (deletedMakeup != null)
            {
                db.Makeups.Remove(deletedMakeup);
                db.SaveChanges();
            }
            return deletedMakeup;
        }
        
    }
}