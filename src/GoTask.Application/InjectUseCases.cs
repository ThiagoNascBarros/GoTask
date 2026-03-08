using GoTask.Application.Mapper;
using GoTask.Application.UseCases.Tasks.Register;
using GoTask.Application.UseCases.Tasks.GetAll;
using GoTask.Application.UseCases.User.Login;
using GoTask.Application.UseCases.User.Register;
using Microsoft.Extensions.DependencyInjection;
using GoTask.Application.UseCases.Tasks.Update;

namespace GoTask.Application
{
    public static class InjectUseCases
    {

        public static void AddUseCases(this IServiceCollection services)
        {
            AddUses(services);
            AddAutoMapper(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapping>());
        }

        private static void AddUses(this IServiceCollection services)
        {
            services.AddScoped<IUserRegisterUseCase, UserRegisterUseCase>();
            services.AddScoped<IUserLoginUseCase, UserLoginUseCase>();
            services.AddScoped<ITaskRegisterUseCase, TaskRegisterUseCase>();
            services.AddScoped<ITaskGetAllUseCase, TaskGetAllUseCase>();
            services.AddScoped<ITaskUpdateUseCase, TaskUpdateUseCase>();
        }

    }
}
