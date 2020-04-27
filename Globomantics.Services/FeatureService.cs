using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Globomantics.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly Dictionary<string, bool> _featureStates;

        public FeatureService(string webRootPath)
        {
            var file = Path.Combine(webRootPath, "features.json");

            _featureStates = JsonConvert.DeserializeObject<Dictionary<string, bool>>(File.ReadAllText(file));
        }

        public bool IsFeatureActive(string featureName)
        {
            return _featureStates.TryGetValue(featureName, out var isEnabled) && isEnabled;
        }
    }
}
