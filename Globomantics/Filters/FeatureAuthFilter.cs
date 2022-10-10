using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace Globomantics.Filters
{
    public class FeatureAuthFilter : Attribute, IAuthorizationFilter
    {
        public string FeatureName { get; set; }

        private Dictionary<string, bool> FeatureStatus = new Dictionary<string, bool>
        {
            { "Loan", false },
            { "Insurance", true },
            { "Resource", true }
        };

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!FeatureStatus[FeatureName])
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
