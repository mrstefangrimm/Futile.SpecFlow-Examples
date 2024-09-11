// 2023, written by Stefan Grimm

using System.Collections.Generic;

namespace SpecFlowCalculator.Specs.Hooks
{
    public interface ICapabilitiesEx
    {
        IEnumerable<string> Capabilities { get; }

        void Add(string key, string value);

        void Clear();
    }
}
