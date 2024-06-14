using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Repositories
{
    public class MakeUpBrandRepositories
    {
        private static DatabaseEntities3 db = new DatabaseEntities3();
        public static List<MakeupBrand> GetAllMakeupBrands()
        {
            return db.MakeupBrands.OrderByDescending(brand => brand.MakeupBrandRating).ToList();
        }
        public static MakeupBrand GetMakeupBrandById(int id)
        {
            return db.MakeupBrands.Find(id);
        }
        public static MakeupBrand GetLastMakeupBrand()
        {
            return db.MakeupBrands.ToList().LastOrDefault();
        }

        public static MakeupBrand AddMakeUpBrand(MakeupBrand makeupBrand)
        {
            db.MakeupBrands.Add(makeupBrand);
            db.SaveChanges();
            return makeupBrand;
        }

        public static MakeupBrand UpdateMakeupBrand(MakeupBrand makeup)
        {
            MakeupBrand makeupBrand = db.MakeupBrands.Find(makeup.MakeupBrandID);
            makeupBrand.MakeupBrandName = makeup.MakeupBrandName;
            makeupBrand.MakeupBrandRating = makeup.MakeupBrandRating;

            db.SaveChanges();

            return makeupBrand;
        }
        public static int DeleteMakeupBrandById(int id)
        {
            MakeupBrand deletedMakeupBrand = db.MakeupBrands.Find(id);
            if (deletedMakeupBrand != null)
            {
                db.MakeupBrands.Remove(deletedMakeupBrand);
            }
            return db.SaveChanges();
        }
    }
}