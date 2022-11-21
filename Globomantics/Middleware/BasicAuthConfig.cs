using Microsoft.AspNetCore.Builder;

namespace Globomantics.Middleware
{
    public class BasicAuthConfig
    {
        public void Configure(IApplicationBuilder builder)
        {
            builder.UseMiddleware<BasicAuthMiddleware>();
        }
    }
}
