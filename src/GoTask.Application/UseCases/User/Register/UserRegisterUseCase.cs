using GoTask.Communication.Requests;
using GoTask.Domain.Data.Interface;

namespace GoTask.Application.UseCases.User.Register
{
    public class UserRegisterUseCase : IUserRegisterUseCase
    {
        private readonly IUserRepository _userRepository;

        public UserRegisterUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async System.Threading.Tasks.Task Execute(RequestRegisterUserJson request)
        {
            var user = new Domain.Entities.User
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password
            };

            var encodePass = await EncodePassword(user);

            user.Password = encodePass;

            await _userRepository.Post(user);
        }

        private async Task<string> EncodePassword(Domain.Entities.User req)
        {
            return BCrypt.Net.BCrypt.HashPassword(req.Password);
        }
    }
}
