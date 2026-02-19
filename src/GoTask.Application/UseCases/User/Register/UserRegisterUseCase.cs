using AutoMapper;
using GoTask.Communication.Requests;
using GoTask.Communication.Response;
using GoTask.Domain.Data.Interface;
using GoTask.Exception.Exceptions;

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
            Validate(request);

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

        private void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidation();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var erroMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(erroMessages);
            }
        }

        private async Task<string> EncodePassword(Domain.Entities.User req)
        {
            return BCrypt.Net.BCrypt.HashPassword(req.Password);
        }
    }
}
