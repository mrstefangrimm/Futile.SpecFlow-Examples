using System.Windows;

namespace SpecFlowCalculator
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            string displayedArgs = string.Empty;
            if (e.Args != null) {
                displayedArgs = string.Join(" ", e.Args);
            }
            var window = new MainWindow(displayedArgs);
            window.Show();
        }
    }
}
