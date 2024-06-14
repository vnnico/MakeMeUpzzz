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
        private static Response<T> CreateErrorResponse<T>(string message)
        {
            return new Response<T>
            {
                Message = message,
                IsSuccess = false,
                Payload = default
            };
        }

        public static int GenerateIDMakeupType()
        {
            MakeupType lastMakeupType = MakeUpTypeRepositories.GetLastMakeupType();

            return lastMakeupType == null ? 1 : lastMakeupType.MakeupTypeID + 1;
        }

        public static Response<List<MakeupType>> GetAllMakeupTypes()
        {
            List<MakeupType> makeupTypes = MakeUpTypeRepositories.GetAllMakeupTypes();
            if (makeupTypes.Count > 0)
            {
                return new Response<List<MakeupType>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeupTypes
                };
            }
            return CreateErrorResponse<List<MakeupType>>("No makeup types found");
        }

        public static Response<MakeupType> GetMakeupTypeById(int id)
        {
            MakeupType makeupType = MakeUpTypeRepositories.GetMakeupTypeById(id);
            if (makeupType != null)
            {
                return new Response<MakeupType>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeupType
                };
            }
            return CreateErrorResponse<MakeupType>("Makeup type not found");
        }

        public static Response<MakeupType> InsertMakeupType(string name)
        {
            MakeupType makeupType = MakeUpTypeFactories.Create(GenerateIDMakeupType(), name);

            if (MakeUpTypeRepositories.InsertMakeupType(makeupType) == 0)
            {
                return CreateErrorResponse<MakeupType>("Failed to insert makeup type");
            }

            return new Response<MakeupType>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeupType
            };
        }

        public static Response<MakeupType> UpdateMakeupType(int id, string name)
        {
            MakeupType makeupType = MakeUpTypeFactories.Create(id, name);
            MakeupType updatedMakeupType = MakeUpTypeRepositories.UpdateMakeupType(makeupType);

            if (updatedMakeupType == null)
            {
                return CreateErrorResponse<MakeupType>("Failed to update makeup type");
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
            List<Makeup> makeups = MakeUpRepositories.GetAllMakeupsByMakeupTypeId(makeupTypeId);

            foreach (Makeup makeup in makeups)
            {
                if (MakeUpRepositories.DeleteMakeup(makeup.MakeupID) == null)
                {
                    return CreateErrorResponse<MakeupType>($"Failed to remove makeup with ID: {makeup.MakeupID}");
                }
            }

            if (MakeUpTypeRepositories.DeleteMakeupTypeById(makeupTypeId) == 0)
            {
                return CreateErrorResponse<MakeupType>("Failed to delete makeup type");
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
