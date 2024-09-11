// 2023, written by Stefan Grimm

using SpecFlow.Actions.WindowsAppDriver;
using SpecFlowCalculator.Specs.Hooks;
using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.UnitTestProvider;

[assembly: RuntimePlugin(typeof(ConfigurationRuntimePluginPatch))]

namespace SpecFlowCalculator.Specs.Hooks {
  public class ConfigurationRuntimePluginPatch : IRuntimePlugin
    {
        public void Initialize(
            RuntimePluginEvents runtimePluginEvents,
            RuntimePluginParameters runtimePluginParameters,
            UnitTestProviderConfiguration unitTestProviderConfiguration)
        {
            runtimePluginEvents.RegisterGlobalDependencies += RuntimePluginEvents_RegisterGlobalDependencies;
        }

        private void RuntimePluginEvents_RegisterGlobalDependencies(object sender, RegisterGlobalDependenciesEventArgs e)
        {
            e.ObjectContainer.RegisterTypeAs<CapabilitiesEx, ICapabilitiesEx>();
            e.ObjectContainer.RegisterTypeAs<AppDriverCliEx, IAppDriverCli>();
        }
    }
}
