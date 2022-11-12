using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Globomantics.Constraints
{
    public class VersionConstraint : IRouteConstraint
    {
        private double requiredVersion;

        public VersionConstraint(double version)
        {
            this.requiredVersion = version;
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            double requestVersion;
            var urlVersion = values["version"].ToString()?.Substring(1);

            if (double.TryParse(urlVersion, out requestVersion))
            {
                return requestVersion >= requiredVersion &&
                    requestVersion < requiredVersion + 1;
            }

            return false;
        }
    }
}
