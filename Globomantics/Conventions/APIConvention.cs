using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Globomantics.Conventions
{
    public class APIConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            controller.ControllerName = controller.ControllerName.Replace("Api", "");
        }
    }
}
