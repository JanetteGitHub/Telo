﻿
namespace food.ViewModels
{
    using System;
    using System.Linq;
    using System.Windows.Input;
    using common.Models;
    using Helpers;
    using Views;
    using GalaSoft.MvvmLight.Command;
    using Services;
    using Xamarin.Forms;

    public class ProductItemViewModel: Product
    {
        #region Attributes
        private ApiServices apiService;
        #endregion

        #region Constructors
        public ProductItemViewModel()
        {
            this.apiService = new ApiServices();
        }
        #endregion

        #region Commands
        public ICommand EditProductCommand
        {
            get
            {
                return new RelayCommand(EditProduct);
            }
        }

        private async void EditProduct()
        {
            MainViewModel.GetInstance().EditProduct = new EditProductViewModel(this);
            await App.Navigator.PushAsync(new EditProductPage());
        }

        public ICommand DeleteProductCommand
        {
            get
            {
                return new RelayCommand(DeleteProduct);
            }
        }

        private async void DeleteProduct()
        {
            var answer = await Application.Current.MainPage.DisplayAlert(
                Languages.Confirm,
                Languages.DeleteConfirmation,
                Languages.Yes,
                Languages.No);
            if (!answer)
            {
                return;
            }
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                
                await Application.Current.MainPage.DisplayAlert(Languages.Error, connection.Message, Languages.Accept);
                return;

            }
            var url = Application.Current.Resources["UrlApi"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlProductsController"].ToString();
            var response = await this.apiService.Delete(url, prefix, controller,this.ProductId,Settings.TokenType,Settings.AccessToken);
            if (!response.IsSuccess)
            {
                
                await Application.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }
            var productsViewModel = ProductsViewModel.GetInstance();
            var deleteProduct = productsViewModel.MyProducts.Where(p => p.ProductId == this.ProductId).FirstOrDefault();
            if (deleteProduct != null)
            {
                productsViewModel.MyProducts.Remove(deleteProduct);
            }
            productsViewModel.RefreshList();
        }
        #endregion
    }
}
