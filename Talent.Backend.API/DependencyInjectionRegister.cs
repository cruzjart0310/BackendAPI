using Microsoft.Extensions.DependencyInjection;
using Talent.Backend.Bussiness;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.DataAccessEF.Contracts;
using Talent.Backend.DataAccessEF.Repositories;
using Talent.Backend.Service;
using Talent.Backend.Service.Contracts;

namespace Talent.Backend.API
{
    public static class DependencyInjectionRegister
    {
        public static void AddRegistration(this IServiceCollection services)
        {
            //[Singleton] Genera una sola instancia y simpre devuelve la misma
            //[Trasient] Genera una sola instancia cada vez que se invoca
            //[Scope] Genera una sola instancia dentro de un contexto determinado

            AddRegistrationServices(services);
            AddRegistrationBussines(services);
            AddRegistrationRepositories(services);
        }

        private static void AddRegistrationServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }

        private static void AddRegistrationBussines(IServiceCollection services)
        {
            services.AddTransient<IUserBussiness, UserBussiness>();
        }

        private static void AddRegistrationRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
