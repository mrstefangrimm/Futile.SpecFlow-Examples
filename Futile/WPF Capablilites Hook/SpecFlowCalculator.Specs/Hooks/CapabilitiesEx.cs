// 2023, written by Stefan Grimm

using System.Collections.Generic;

namespace SpecFlowCalculator.Specs.Hooks
{
    public class CapabilitiesEx : ICapabilitiesEx {

        private Dictionary<string, string> _scenarioCapablilies { get; } = new Dictionary<string, string>();

        public IEnumerable<string> Capabilities
        {
            get
            {
                return _scenarioCapablilies.Keys;
            }
        }

        public void Add(string key, string value)
        {
            _scenarioCapablilies.Add(key, value);
        }

        public void Clear()
        {
            _scenarioCapablilies.Clear();
        }
  }
}
