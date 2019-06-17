
namespace food.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using food.common.Models;
    using food.Services;
    using Xamarin.Forms;

    public class ProductsViewModel:BaseViewModel 
    {
        private ApiServices apiService;
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get{ return this.products; }
            set { this.SetValue(ref this.products, value); }
        }
        public ProductsViewModel()
        {
            this.apiService = new ApiServices();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            var response = await this.apiService.GetList<Product>("https://foodapi20190615091957.azurewebsites.net", "/api", "/Products");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error",response.Message,"Aceptar");
                return;
            }
            var list = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(list);

        }
    }
}
