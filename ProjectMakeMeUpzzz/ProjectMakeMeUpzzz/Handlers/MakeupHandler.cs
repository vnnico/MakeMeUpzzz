using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;
using ProjectMakeMeUpzzz.Factory;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Repositories;
using ProjectMakeMeUpzzz.Views;

namespace ProjectMakeMeUpzzz.Handlers
{
    public class MakeupHandler
    {
        public static int GenerateIDMakeup()
        {
            Makeup makeup = MakeUpRepositories.GetLastMakeup();

            if (makeup == null)
            {
                return 1;
            }
            return makeup.MakeupID + 1;
        }

        public static Response<List<Makeup>> GetAllMakeups()
        {
            List<Makeup> makeups = MakeUpRepositories.GetAllMakeups();
            if (makeups.Count > 0)
            {
                return new Response<List<Makeup>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeups
                };
            }
            return new Response<List<Makeup>>
            {
                Message = "No makeups found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<Makeup> GetMakeupById(int id)
        {
            Makeup makeup = MakeUpRepositories.GetMakeupById(id);
            if (makeup != null)
            {
                return new Response<Makeup>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeup
                };
            }
            return new Response<Makeup>
            {
                Message = "Makeup not found",
                IsSuccess = false,
                Payload = null
            };
        }
        public static Response<Makeup> InsertMakeup(string name, int price, int weight, int typeid, int brandid)
        {
            Makeup makeup = MakeUpFactories.CreateMakeup(GenerateIDMakeup(), name, price, weight, typeid, brandid);

            if (MakeUpRepositories.InsertMakeup(makeup) == 0)
            {
                return new Response<Makeup>
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<Makeup>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeup
            };
        }

        public static Response<Makeup> UpdateMakeup(int id, string name, int price, int weight, int typeid, int brandid)
        {
            Makeup makeup = MakeUpFactories.CreateMakeup(id, name, price, weight, typeid, brandid);
            Makeup updatedMakeup = MakeUpRepositories.UpdateMakeup(makeup);

            if (updatedMakeup == null)
            {
                return new Response<Makeup>
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<Makeup>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeup
            };
        }

        public static Response<Makeup> DeleteMakeup(int id)
        {
            try
            {
                Makeup deletedMakeup = MakeUpRepositories.DeleteMakeup(id);
                if (deletedMakeup != null)
                {
                    return new Response<Makeup>
                    {
                        IsSuccess = true,
                        Message = "Makeup deleted successfully.",
                        Payload = deletedMakeup
                    };
                }
                else
                {
                    return new Response<Makeup>
                    {
                        IsSuccess = false,
                        Message = "Failed to delete makeup. Makeup with the given ID does not exist.",
                        Payload = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response<Makeup>
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}",
                    Payload = null
                };
            }
        }

      
    }
}
