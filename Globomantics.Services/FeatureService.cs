using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Globomantics.Services
{
    public class FeatureService : IFeatureService
    {
        private IHostingEnvironment _hostingEnvironment;
        private Dictionary<string, bool> _featureStates = new Dictionary<string, bool>();

        public FeatureService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "features.json");

            _featureStates = JsonConvert.DeserializeObject<Dictionary<string, bool>>
                (File.ReadAllText(path));
        }

        public bool IsFeatureActive(string featureName)
        {
            return _featureStates[featureName];
        }
    }
}
