namespace DCOM.WPF.MVVM.IRequestFocus
{
    using MVVM;
    using System.Windows;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            UsernameTextBox.Focus();
            UsernameTextBox.SelectAll();

            IRequestFocus focus = (IRequestFocus)DataContext;

            focus.FocusRequested += OnFocusRequested;
        }

        private void OnFocusRequested(object sender, FocusRequestedEventArgs e)
        {
            var viewModel = (MainWindowViewModel)DataContext;

            switch (e.PropertyName)
            {
                case nameof(viewModel.Password):
                    PasswordTextBox.Focus();
                    PasswordTextBox.SelectAll();
                    break;
            }
        }
    }
}