using Books4You.Views;
using System.Windows;

namespace Books4You
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginRegisterView view = new LoginRegisterView();
            view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            view.Show();
        }
    }
}
