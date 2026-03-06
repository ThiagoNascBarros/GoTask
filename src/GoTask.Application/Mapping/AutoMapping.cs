using AutoMapper;
using GoTask.Communication.Requests;
using GoTask.Communication.Response;
using GoTask.Domain.Entities;

namespace GoTask.Application.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestRegisterUserJson, User>();
            CreateMap<RequestRegisterTaskJson, Tasks>();
        }

        private void EntityToResponse()
        {
            CreateMap<Tasks, ResponseRegisterTaskJson>();
            CreateMap<GoTask.Domain.Entities.Tasks, ResponseRegisterTaskJson>();
            CreateMap<User, ResponseRegisteredUserJson>();
        }
    }
}
