namespace DCOM.WPF.MVVM.IRequestFocus
{

    using System.Windows;

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var service   = new LoginService();
            var viewModel = new MainWindowViewModel(service);
            var view      = new MainWindow
                            {
                                DataContext = viewModel
                            };

            view.ShowDialog();
        }
    }
}