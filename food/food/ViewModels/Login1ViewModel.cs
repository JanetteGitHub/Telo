
namespace food.ViewModels
{
    using System;
    using System.Windows.Input;
    using food.Views;
    using GalaSoft.MvvmLight.Command;
    using Helpers;
    using Services;
    using Xamarin.Forms;
    public class Login1ViewModel:BaseViewModel
    {
        #region Attributes
        private ApiServices apiService;
        private bool isRunning;
        private bool isEnabled;

        #endregion

        #region Properties
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRemembered { get; set; }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { this.SetValue(ref this.isRunning, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }

        #endregion

        #region Constructors
        public Login1ViewModel()
        {
            this.apiService = new ApiServices();
            this.IsEnabled = true;
            
        }
        

        #endregion

        #region Commands
        public ICommand Login1Command
        {
            get
            {
                return new RelayCommand(Login1);
            }
        }
            

        private async void Login1()
        {

            this.IsRunning = true;
            this.IsEnabled = false;
            var connection = await this.apiService.CheckConnection();



            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(Languages.Error, connection.Message, Languages.Accept);
                return;

            }

            //var url = Application.Current.Resources["UrlApi"].ToString();
            ////var token = await this.apiService.GetToken(url, this.Email, this.Password);
           

            //if (token == null || string.IsNullOrEmpty(token.AccessToken))
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.SomethingWrong, Languages.Accept);
            //    return;
            //}

            //Settings.TokenType = token.TokenType;
            //Settings.AccessToken = token.AccessToken;
            //Settings.IsRemembered = this.IsRemembered;

            MainViewModel.GetInstance().WelcomePage = new WelcomePageViewModel();
            Application.Current.MainPage = new WelcomePage();

            this.IsRunning = false;
            this.IsEnabled = true;


        }

        #endregion
    }
}
