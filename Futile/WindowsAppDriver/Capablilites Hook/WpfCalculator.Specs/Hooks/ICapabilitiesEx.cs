using System.Collections.Generic;

namespace WpfCalculator.Specs.Hooks;

public interface ICapabilitiesEx {
  IEnumerable<string> Capabilities { get; }

  void Add(string key, string value);

  void Clear();
}
