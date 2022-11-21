using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Globomantics.Constraints
{
    public class ActionVersionConstraints : IActionConstraint
    {
        private double requiredVersion;

        public ActionVersionConstraints(double version)
        {
            this.requiredVersion = version;
        }

        public int Order { get; set; }

        public bool Accept(ActionConstraintContext context)
        {
            double parsedVersion = 0;

            if (double.TryParse(context.RouteContext.HttpContext.Request
                .Headers["x-version"].ToString(), out parsedVersion))
            {
                return parsedVersion >= requiredVersion &&
                    parsedVersion < requiredVersion + 1;
            }

            return false;
        }
    }
}
