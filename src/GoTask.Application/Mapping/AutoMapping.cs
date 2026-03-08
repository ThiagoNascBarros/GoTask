using AutoMapper;
using GoTask.Application.UseCases.Tasks.GetAll;
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
            CreateMap<ResponseUpdateTaskJson, Tasks>();
        }

        private void EntityToResponse()
        {
            CreateMap<Tasks, ResponseRegisterTaskJson>();
            CreateMap<Tasks, ResponseGetAllTaskJson>();
            CreateMap<Tasks, ResponseUpdateTaskJson>();
            CreateMap<User, ResponseRegisteredUserJson>();
        }
    }
}
