namespace DCOM.WPF.MVVM.IRequestFocus
{
    using MVVM;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Security.Authentication;
    using System.Windows.Input;

    public class MainWindowViewModel : INotifyPropertyChanged, IRequestFocus
    {
        private readonly ILoginService loginService;
        private string username;
        private string password;

        public MainWindowViewModel(ILoginService loginService)
        {
            this.loginService = loginService;
            LoginCommand = new ActionCommand(p => Login());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<FocusRequestedEventArgs> FocusRequested;

        public ICommand LoginCommand { get; }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        private void Login()
        {
            try
            {
                loginService.Login(Username, Password);
            }
            catch (AuthenticationException)
            {
                OnFocusRequested(nameof(Password));
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnFocusRequested(string propertyName)
        {
            FocusRequested?.Invoke(this, new FocusRequestedEventArgs(propertyName));
        }
    }
}