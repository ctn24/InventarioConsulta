namespace InventarioConsulta.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string user1;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string User1
        {
            get { return this.user1; }
            set { SetValue(ref this.user1, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;

            this.user1 = "ctn";
            this.Password = "1234";
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.User1))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un usuario.",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar una contraseña.",
                    "Aceptar");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if (this.User1 != "ctn" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Usuario o contraseña incorrecta.",
                    "Aceptar");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            this.User1 = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Inventory = new InventoryViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new InventoryPage());
        }
        #endregion
    }
}
