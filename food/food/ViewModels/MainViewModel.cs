﻿

namespace food.ViewModels
{
    using System.Windows.Input;
    using Views;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;
    using System.Collections.ObjectModel;
    using System;
    using food.Helpers;

    public class MainViewModel
    {
        #region Properties
        public Login1ViewModel Login1 { get; set; }
        public WelcomePageViewModel WelcomePage { get; set; }
        public LoginViewModel Login {get;set;}
        public EditProductViewModel EditProduct { get; set; }
        public ProductsViewModel Products { get; set; }
        public AddProductViewModel AddProduct { get; set; }
        public RegisterViewModel Register { get; set; }
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        
        #endregion

        #region Constructors
        public MainViewModel()
        {

            instance = this;
            //this.LoadMenu();
        }

        #endregion
        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }


        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();

            this.Menu.Add(new MenuItemViewModel
            {
                Icon="ic_info",
                PageName="AboutPage",
                Title=Languages.About,
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_phonelink_setup",
                PageName = "SetupPage",
                Title = Languages.Setup,
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = Languages.Exit,
            });
        }
        #endregion


        #region Commands
        public ICommand AddProductCommand
        {
            get
            {
                return new RelayCommand(GoToAddProduct);
            }
        }
        private async void GoToAddProduct()
        {
            this.AddProduct = new AddProductViewModel();
            await App.Navigator.PushAsync(new AddProductPage());
        } 
        #endregion


    }
}
