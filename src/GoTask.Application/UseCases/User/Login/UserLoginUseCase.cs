using GoTask.Communication.Requests;
using GoTask.Communication.Response;
using GoTask.Domain.Data.Interface;
using GoTask.Domain.Security.Cryptography;
using GoTask.Domain.Security.Token;
using GoTask.Exception.Exceptions;

namespace GoTask.Application.UseCases.User.Login
{
    internal class UserLoginUseCase : IUserLoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordEncripter _bcrypt;
        private readonly IAccessTokenGenerator _accessToken;

        public UserLoginUseCase(IUserRepository userRepository, IPasswordEncripter bcrypt, IAccessTokenGenerator accessToken)
        {
            _userRepository = userRepository;
            _bcrypt = bcrypt;
            _accessToken = accessToken;
        }

        public async Task<ResponseLoginUserJson> Execute(RequestLoginUserJson request)
        {
            var user = await _userRepository.GetUserByEmailAndPassword(request.Email);
            if (user is null)
            {
                throw new InvalidLoginException();
            }

            var passwordMatch = _bcrypt.Verify(request.Password, user.Password);

            if (passwordMatch == false)
            {
                throw new InvalidLoginException();
            }

            return new ResponseLoginUserJson
            {
                Token = _accessToken.Generate(user)
            };
        }
    }
}
