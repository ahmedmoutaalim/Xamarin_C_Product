using ProductCrud.Models;
using ProductCrud.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductCrud
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowProductPage : ContentPage
    {
        ProductService services;
        public ShowProductPage()
        {
            InitializeComponent();
            services = new ProductService();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            showProduct();
        }
        private void showProduct()
        {
            var res = services.GetAllProduct().Result;
            lstData.ItemsSource = res;
        }

        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddProduct());
        }

        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Product obj = (Product)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new AddProduct(obj));
                        break;
                    case "Delete":
                        services.DeleteProduct(obj);
                        showProduct();
                        break;
                }
                lstData.SelectedItem = null;
            }
        }
    }
}