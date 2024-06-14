using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Factory;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;
using ProjectMakeMeUpzzz.Repositories;

namespace ProjectMakeMeUpzzz.Handlers
{
    public class MakeupBrandHandler
    {
   

        public static Response<List<MakeupBrand>> GetAllMakeupBrands()
        {
            List<MakeupBrand> makeupBrands = MakeUpBrandRepositories.GetAllMakeupBrands();
            if (makeupBrands.Count > 0)
            {
                return new Response<List<MakeupBrand>>
                {
                    Message = "No Makeup Brands founded",
                    IsSuccess = true,
                    Payload = makeupBrands
                };
            }
            return new Response<List<MakeupBrand>>
            {
                Message = "No Makeup Brands founded",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<MakeupBrand> GetMakeupBrandById(int id)
        {
            MakeupBrand makeupBrand = MakeUpBrandRepositories.GetMakeupBrandById(id);
            if (makeupBrand == null)
            {
                return new Response<MakeupBrand>
                {
                    Message = "No Makeup Brands founded",
                    IsSuccess = false,
                    Payload = null
                };
           
            }
            return new Response<MakeupBrand>
            {
                Message = "No Makeup Brands founded",
                IsSuccess = true,
                Payload = makeupBrand
            };

        }
        public static Response<MakeupBrand> InsertMakeupBrand(string name, int rating)
        {

            MakeupBrand lastMakeupBrand = MakeUpBrandRepositories.GetLastMakeupBrand();
            int id = Convert.ToInt32(lastMakeupBrand.MakeupBrandID);
            if (lastMakeupBrand == null)
            {
                id = 1;
            }
            else
            {
                id += 1;
            };
            MakeupBrand makeupBrand = MakeUpBrandFactories.Create(id, name, rating);

            if (MakeUpBrandRepositories.AddMakeUpBrand(makeupBrand) == null)
            {
                return new Response<MakeupBrand>
                {
                    Message = "Failed to Insert new make up brand",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<MakeupBrand>
            {
                Message = "Successfully added new Make up brand",
                IsSuccess = true,
                Payload = makeupBrand
            };
        }

        public static Response<MakeupBrand> UpdateMakeupBrand(int id, string name, int rating)
        {
            MakeupBrand makeupBrand = MakeUpBrandFactories.Create(id, name, rating);
            MakeupBrand updatedMakeupBrand = MakeUpBrandRepositories.UpdateMakeupBrand(makeupBrand);

            if (updatedMakeupBrand == null)
            {
                return new Response<MakeupBrand>
                {
                    Message = "Failed to update make up brand",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<MakeupBrand>
            {
                Message = "Successfully updated make up brand",
                IsSuccess = true,
                Payload = makeupBrand
            };

        }

        public static Response<MakeupBrand> RemoveMakeupBrandById(int brandId)
        {
            MakeupBrand makeupBrand = MakeUpBrandRepositories.GetMakeupBrandById(brandId);

            List<Makeup> makeupBrands = MakeUpRepositories.GetAllMakeupsByBrandId(brandId);

            if (makeupBrands.Count > 0)
            {
                foreach (Makeup makeup in makeupBrands)
                {
                    if (MakeUpRepositories.DeleteMakeup(makeup.MakeupID) == null)
                    {
                        return new Response<MakeupBrand>
                        {
                            Message = "Failed to remove",
                            IsSuccess = false,
                            Payload = null
                        };
                    }
                }
            }
            if (MakeUpBrandRepositories.DeleteMakeupBrandById(brandId) == 0)
            {
                return new Response<MakeupBrand>
                {
                    Message = "Failed to delete make up brand",
                    IsSuccess = false,
                    Payload = null
                };
            }
            return new Response<MakeupBrand>
            {
                Message = "Successfully remove make up brand",
                IsSuccess = true,
                Payload = makeupBrand
            };
        }
    }
}