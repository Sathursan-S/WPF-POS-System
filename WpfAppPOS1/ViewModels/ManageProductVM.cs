using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppPOS1.Models;

namespace WpfAppPOS1.ViewModels
{
    public partial class ManageProductVM : ObservableObject
    {
        // create observable properties for ViewModel
        [ObservableProperty]
        public int productId;
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public decimal unitPrice;
        [ObservableProperty]
        public int quantityInStock;
        [ObservableProperty]
        public string description;
        [ObservableProperty]
        public ObservableCollection<Product> products;

        // create selected product property and its setter
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                SetProperty(ref _selectedProduct, value);
                if (value != null)
                {
                    ProductId = value.ProductID;
                    Name = value.Name;
                    UnitPrice = value.UnitPrice;
                    Description = value.Description;
                    QuantityInStock = GetQuantity(value.ProductID);
                }
            }
        }
        //get quntity of a product with productid from stock table
        public int GetQuantity(int productId)
        {
            using var db = new MyDbContext();
            var product = db.Products.Find(productId);
            var stock = db.Stocks.Find(product);
            return stock.Quantity;
        }

        // create a boolean property to check if a product is being edited
        public bool IsEdited
        {
            get
            {
                if (SelectedProduct == null)
                {
                    return false;
                }
                return SelectedProduct.Name != Name || SelectedProduct.UnitPrice != UnitPrice || SelectedProduct.Description != Description;
            }
        }

        // method to load products from database
        public void LoadProducts()
        {
            using (var db = new MyDbContext())
            {
                Products = new ObservableCollection<Product>(db.Products.ToList());
            }
        }

        // create a method to add a new product
        [RelayCommand]
        public void CreateProduct()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Please enter a name for the product.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var product = new Product
            {
                Name = Name,
                UnitPrice = UnitPrice,
                //QuantityInStock = QuantityInStock,
                Description = Description
            };

            using (var db = new MyDbContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }

            Reset();
            LoadProducts();
        }

        // create a method to update a product
        [RelayCommand]
        public void UpdateProduct()
        {
            if (IsEdited)
            {
                using (var db = new MyDbContext())
                {
                    var product = db.Products.Find(ProductId);
                    product.Name = Name;
                    product.UnitPrice = UnitPrice;
                    //product.QuantityInStock = QuantityInStock;
                    product.Description = Description;
                    db.SaveChanges();
                }

                LoadProducts();
                SelectedProduct = null;
                Reset();
            }
            else
            {
                MessageBox.Show("No changes made.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        // create a method to delete a product
        [RelayCommand]
        public void DeleteProduct()
        {
            if (SelectedProduct == null)
            {
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new MyDbContext())
                {
                    db.Products.Remove(SelectedProduct);
                    db.SaveChanges();
                }
                LoadProducts();
            }
            SelectedProduct = null;
            Reset();
        }

        // Method to reset the form
        [RelayCommand]
        public void Reset()
        {
            ProductId = 0;
            Name = "";
            UnitPrice = 0;
            QuantityInStock = 0;
            Description = "";
            LoadProducts();
        }

        // Constructor to load products on initialization
        public ManageProductVM()
        {
            LoadProducts();
        }
    }
}