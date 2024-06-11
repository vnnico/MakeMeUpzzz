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
        public static int GenerateIDMakeupBrand()
        {
            MakeupBrand makeup = MakeUpBrandRepositories.GetLastMakeupBrand();

            if (makeup == null)
            {
                return 1;
            }
            return makeup.MakeupBrandID + 1;
        }

        public static Response<List<MakeupBrand>> GetAllMakeupBrands()
        {
            List<MakeupBrand> makeups = MakeUpBrandRepositories.GetAllMakeupBrands();
            if (makeups.Count > 0)
            {
                return new Response<List<MakeupBrand>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeups
                };
            }
            return new Response<List<MakeupBrand>>
            {
                Message = "No makeups found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<MakeupBrand> GetMakeupBrandById(int id)
        {
            MakeupBrand makeup = MakeUpBrandRepositories.GetMakeupBrandById(id);
            if (makeup != null)
            {
                return new Response<MakeupBrand>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeup
                };
            }
            return new Response<MakeupBrand>
            {
                Message = "Makeup not found",
                IsSuccess = false,
                Payload = null
            };
        }
        public static Response<MakeupBrand> InsertMakeupBrand(string name, int rating)
        {
            MakeupBrand makeup = MakeUpBrandFactories.CreateMakeUpBrand(GenerateIDMakeupBrand(), name, rating);

            if (MakeUpBrandRepositories.InsertMakeupBrand(makeup) == 0)
            {
                return new Response<MakeupBrand>
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<MakeupBrand>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeup
            };
        }

        public static Response<MakeupBrand> UpdateMakeupBrand(int id, string brandName, int rating)
        {
            MakeupBrand makeupBrand = MakeUpBrandFactories.CreateMakeUpBrand(id, brandName, rating);
            MakeupBrand updatedMakeupBrand = MakeUpBrandRepositories.UpdateMakeupBrand(makeupBrand);
            if (updatedMakeupBrand == null)
            {
                return new Response<MakeupBrand>
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<MakeupBrand>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeupBrand
            };

        }

        public static Response<MakeupBrand> RemoveMakeupBrandById(int brandId)
        {
            MakeupBrand makeupBrand = MakeUpBrandRepositories.GetMakeupBrandById(brandId);
            List<Makeup> makeups = MakeUpRepositories.GetMakeupsByBrandId(brandId);
            if (makeups.Count > 0)
            {
                foreach (Makeup makeup in makeups)
                {
                    if (MakeUpRepositories.DeleteMakeup(makeup.MakeupID) == null)
                    {
                        return new Response<MakeupBrand>
                        {
                            Message = "Failed to remove makeup id:" + makeup.MakeupID,
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
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }
            return new Response<MakeupBrand>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeupBrand
            };
        }
    }
}