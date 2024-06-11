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
    public class MakeupTypeHandler
    {
        public static int GenerateIDMakeupType()
        {
            MakeupType makeup = MakeUpTypeRepositories.GetLastMakeupType();

            if (makeup == null)
            {
                return 1;
            }
            return makeup.MakeupTypeID + 1;
        }

        public static Response<List<MakeupType>> GetAllMakeupTypes()
        {
            List<MakeupType> makeups = MakeUpTypeRepositories.GetAllMakeupTypes();
            if (makeups.Count > 0)
            {
                return new Response<List<MakeupType>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeups
                };
            }
            return new Response<List<MakeupType>>
            {
                Message = "No makeups found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<MakeupType> GetMakeupTypeById(int id)
        {
            MakeupType makeup = MakeUpTypeRepositories.GetMakeupTypeById(id);
            if (makeup != null)
            {
                return new Response<MakeupType>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeup
                };
            }
            return new Response<MakeupType>
            {
                Message = "Makeup not found",
                IsSuccess = false,
                Payload = null
            };
        }
        public static Response<MakeupType> InsertMakeupType(string name)
        {
            MakeupType makeup = MakeUpTypeFactories.CreateMakeupType(GenerateIDMakeupType(), name);

            if (MakeUpTypeRepositories.InsertMakeupType(makeup) == 0)
            {
                return new Response<MakeupType>
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<MakeupType>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeup
            };
        }

        public static Response<MakeupType> UpdateMakeupType(int id, string name)
        {
            MakeupType makeupType = MakeUpTypeFactories.CreateMakeupType(id, name);
            MakeupType updatedMakeupType = MakeUpTypeRepositories.UpdateMakeupType(makeupType);
            if (updatedMakeupType == null)
            {
                return new Response<MakeupType>
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }
            return new Response<MakeupType>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeupType
            };
        }

        public static Response<MakeupType> RemoveMakeupType(int makeupTypeId)
        {
            MakeupType makeupType = MakeUpTypeRepositories.GetMakeupTypeById(makeupTypeId);
            List<Makeup> makeups = MakeUpRepositories.GetMakeupsByMakeupTypeId(makeupTypeId);
            if (makeups.Count > 0)
            {
                foreach (Makeup makeup in makeups)
                {
                    if (MakeUpRepositories.DeleteMakeup(makeup.MakeupID) == null)
                    {
                        return new Response<MakeupType>
                        {
                            Message = "Failed to remove makeup id:" + makeup.MakeupID,
                            IsSuccess = false,
                            Payload = null
                        };
                    }
                }
            }
            if (MakeUpTypeRepositories.DeleteMakeupTypeById(makeupTypeId) == 0)
            {
                return new Response<MakeupType>
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }
            return new Response<MakeupType>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeupType
            };
        }
    }
}