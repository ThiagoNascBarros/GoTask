using AutoMapper;
using GoTask.Communication.Requests;
using GoTask.Communication.Response;
using GoTask.Domain.Data.Interface;

namespace GoTask.Application.UseCases.User.Register
{
    public class UserRegisterUseCase : IUserRegisterUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserRegisterUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            var user = _mapper.Map<Domain.Entities.User>(request);

            var encodePass = await EncodePassword(user);

            user.Password = encodePass;

            var result = await _userRepository.Post(user);
            await _unitOfWork.Commit();

            return new ResponseRegisteredUserJson()
            {
                Name = result.FullName,
                Token = "test",
            };
        }

        private async Task<string> EncodePassword(Domain.Entities.User req)
        {
            return BCrypt.Net.BCrypt.HashPassword(req.Password);
        }
    }
}
