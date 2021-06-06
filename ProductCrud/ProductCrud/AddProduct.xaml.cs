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
    public partial class AddProduct : ContentPage
    {
        ProductService _services;
        bool _isUpdate;
        int ProductID;
        public AddProduct()
        {
            InitializeComponent();
            _services = new ProductService();
            _isUpdate = false;
        }
        public AddProduct(Product obj)
        {
            InitializeComponent();
            _services = new ProductService();
            if (obj != null)
            {
                ProductID = obj.Id;
                Name.Text = obj.Name;
                Discription.Text = obj.Discription;
                Price.Text = obj.Price;
                _isUpdate = true;
            }
        }
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            Product obj = new Product();
            obj.Name = Name.Text;
            obj.Discription= Discription.Text;
            obj.Price = Price.Text;
            if (_isUpdate)
            {
                obj.Id = ProductID;
                await _services.UpdateProduct(obj);
            }
            else
            {
                _services.InsertProduct(obj);
            }
            await this.Navigation.PopAsync();
        }
    }
}