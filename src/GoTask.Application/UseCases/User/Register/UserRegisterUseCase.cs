using AutoMapper;
using FluentValidation.Results;
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
            user.Password = await EncodePassword(user);

            var result = await _userRepository.Post(user);
            await _unitOfWork.Commit();


            return new ResponseRegisteredUserJson()
            {
                Name = result.FullName,
                Token = "test",
            };
        }

        private async Task Validate(RequestRegisterUserJson request)
        {
            var result = new RegisterUserValidation().Validate(request);

            var emailExists = await _userRepository.ExistsUserWithEmail(request.Email);
            if (emailExists)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "Este email já está registrado."));
            }

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
