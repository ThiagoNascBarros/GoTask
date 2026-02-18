using GoTask.Application.UseCases.User.Register;
using Microsoft.Extensions.DependencyInjection;

namespace GoTask.Application
{
    public static class InjectUseCases
    {

        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUserRegisterUseCase, UserRegisterUseCase>();
        }

    }
}
