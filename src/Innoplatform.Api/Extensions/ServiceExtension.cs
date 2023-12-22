using Innoplatform.Data.IRepositories;
using Innoplatform.Data.Repositories;
using Innoplatform.Service.Mappings;

namespace Innoplatform.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
