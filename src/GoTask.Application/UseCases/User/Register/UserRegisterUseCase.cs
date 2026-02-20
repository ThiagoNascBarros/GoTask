using AutoMapper;
using FluentValidation.Results;
using GoTask.Communication.Requests;
using GoTask.Communication.Response;
using GoTask.Domain.Data.Interface;
using GoTask.Domain.Security.Cryptography;
using GoTask.Domain.Security.Token;
using GoTask.Exception.Exceptions;

namespace GoTask.Application.UseCases.User.Register
{
    public class UserRegisterUseCase : IUserRegisterUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordEncripter _encripter;
        private readonly IAccessTokenGenerator _accessToken;

        public UserRegisterUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IPasswordEncripter encripter, IAccessTokenGenerator accessToken)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _encripter = encripter;
            _accessToken = accessToken;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            await Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _encripter.Encrypt(user.Password);

            await _userRepository.Post(user);
            await _unitOfWork.Commit();


            return new ResponseRegisteredUserJson()
            {
                Name = user.FullName,
                Token = this._accessToken.Generate(user),
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


    }
}
