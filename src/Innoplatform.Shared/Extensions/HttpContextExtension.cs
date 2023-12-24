
using Innoplatform.Service.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Innoplatform.Shared.Extensions
{
    public static class HttpContextExtension
    {
        public static void InitAccessor(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            HttpContextHelper.Accessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
        }
    }
}
