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
        }

        private void EntityToResponse()
        {
            CreateMap<User, ResponseRegisteredUserJson>();
        }
    }
}
