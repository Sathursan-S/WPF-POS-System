using System;
using CommunityToolkit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WpfAppPOS1.Models;
using System.Collections;
using System.Windows;
using System.Threading;
using System.Windows.Input;
using System.Windows.Data;

namespace WpfAppPOS1.ViewModels
{
    public partial class SaleWindowVM : ObservableObject
    {
        //create observableproperty for viewmodel
        [ObservableProperty]
        public int cartItemId;
        [ObservableProperty]
        public int productId;
        [ObservableProperty]
        public int invoiceId;
        [ObservableProperty]
        public int quantity;
        [ObservableProperty]
        public double amountPaid;
        [ObservableProperty]
        public double change;
        [ObservableProperty]
        public double discount;
        [ObservableProperty]
        public double totalPrice;
        [ObservableProperty]
        public double subTotal;
        [ObservableProperty]
        ObservableCollection<CartItem> cartItems;
        [ObservableProperty]
        public ObservableCollection<CartItem> cart;
        [ObservableProperty]
        public ObservableCollection<Product> products;
        [ObservableProperty]
        public ObservableCollection<Invoice> invoices;
        [ObservableProperty]
        public Invoice curInv;
        [ObservableProperty]
        public CartItem selectedCartItem;
        [ObservableProperty]
        public User user_X;

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                IsPopupOpen = false; // Close the popup after selection
            }
        }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterProducts();
            }
        }

        [ObservableProperty]
        private ObservableCollection<Product> filteredProducts;

        [ObservableProperty]
        private bool isPopupOpen;
        public MessageBoxResult MessageBoxResult;

        [RelayCommand]
        private void SelectProduct()
        {
            if (isPopupOpen)
            {
                SelectedProduct = FilteredProducts.FirstOrDefault();

                SearchText= string.Empty;
            }
        }
        private void FilterProducts()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                FilteredProducts = Products;
            }
            else
            {
                string lowerSearchText = SearchText.ToLower();
                FilteredProducts = new ObservableCollection<Product>(Products
                    .Where(p => p.ProductID.ToString().Contains(lowerSearchText) ||
                                p.Name.ToLower().Contains(lowerSearchText)));
            }
            IsPopupOpen = !string.IsNullOrEmpty(SearchText) && FilteredProducts.Count > 0;
        }

        //create command for add button
        [RelayCommand]
        public void Add()
        {
            if (SelectedProduct == null)
            {
                MessageBox.Show("Please select a product");
                return;
            }
            //check avalablity in stock
            using var db= new MyDbContext();
            var seStock= db.Stocks.FirstOrDefault(x=>x.ProductID==SelectedProduct.ProductID);
            //var seStock = db.Stocks.Find(SelectedProduct.ProductID);
            if (seStock == null || Quantity > seStock.Quantity)
            {
                MessageBox.Show("Quantity is greater than stock or Out of stock");
                Quantity = 0;
                Discount = 0;
                return;
            }

            else
            {
                //create new stock
                CartItem cartItem = new CartItem(SelectedProduct, Quantity, Discount, CurInv);

                Cart.Add(cartItem);

                seStock.Quantity -= Quantity;
                db.SaveChanges();

                SubTotal = Cart.Sum(x => x.UnitPrice * x.Quantity);
                TotalPrice = SubTotal - Cart.Sum(x => x.Discount);

                Quantity = 0;
                Discount = 0;
                SelectedProduct= null;
            }
        }

        //create command for edit button
        [RelayCommand]
        public void Edit()
        {
            var cartItem = Cart.FirstOrDefault(x => x.CartItemID == SelectedCartItem.CartItemID);
            
            int newQuantity = 0;
            decimal newDiscount = 0;

            var quantityInput = Microsoft.VisualBasic.Interaction.InputBox("Enter the new quantity:", "Quantity", cartItem.Quantity.ToString());
            var discountInput = Microsoft.VisualBasic.Interaction.InputBox("Enter the new discount:", "Discount", cartItem.Discount.ToString());

            int.TryParse(quantityInput, out newQuantity);
            decimal.TryParse(discountInput, out newDiscount);

            cartItem.Quantity = newQuantity;
            cartItem.Discount = (double)newDiscount;

            // Reload data or update the UI accordingly
            var collectionView = CollectionViewSource.GetDefaultView(Cart);
            collectionView.Refresh();
        }

        //delete command
        [RelayCommand]
        public void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to Remove this item?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var cartItem1 = Cart.FirstOrDefault(x => x.CartItemID == SelectedCartItem.CartItemID);
                Cart.Remove(cartItem1);
                LoadData();
            }
        }

        private void LoadData()
        {
            using (var db = new MyDbContext())
            {
                Products = new ObservableCollection<Product>(db.Products.ToList());
                Invoices = new ObservableCollection<Invoice>(db.Invoices.ToList());
            }
        }

        //create invoice
        [RelayCommand]
        public void CreateInvoice()
        {
            //create new invoice
            Invoice invoice = new Invoice();
          
            using (var db = new MyDbContext())
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
            }
            LoadData();
        }

        [RelayCommand]
        public void Checkout()
        {
            //payed amound is graterthan total price
            if (AmountPaid < TotalPrice)
            {
                MessageBox.Show("Amount paid is less than total price");
                return;
            }
            CurInv.CartItems = Cart.ToList();
            CurInv.AmountTendered = AmountPaid;
            CurInv.DateTime = DateTime.Now;
            CurInv.Call();

            using (var db = new MyDbContext())
            {
                db.Invoices.Add(CurInv);
                db.SaveChanges();
            }

            TotalPrice = CurInv.Total;
            Change= CurInv.Change;

            MessageBox.Show($"Total\t : {TotalPrice} \nChange : {Change}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Reset();
        }

        [RelayCommand]
        public void Reset()
        {
            Cart.Clear();
            CurInv = new Invoice();
            SubTotal = 0;
            AmountPaid = 0;
            TotalPrice = 0;
            Change = 0;
        }

        [RelayCommand]
        public void Cancel()
        {
            foreach (var item in CurInv.CartItems)
            {
                using var db = new MyDbContext();
                var seStock = db.Stocks.FirstOrDefault(x => x.ProductID == item.ProductID);
                seStock.Quantity += item.Quantity;
                db.SaveChanges();
            }
            Cart.Clear();
            //CurInv = new Invoice();
            SubTotal = 0;
            AmountPaid = 0;
            TotalPrice = 0;
            Change = 0;
        }

        //create constructor
        public SaleWindowVM()
        {
            LoadData();
            CurInv = new Invoice();
            Cart = new ObservableCollection<CartItem>();
            CartItems = new ObservableCollection<CartItem>();
        }

        public SaleWindowVM(User user)
        {
            User_X = user;
            LoadData();
            CurInv = new Invoice();
            Cart = new ObservableCollection<CartItem>();
            CartItems = new ObservableCollection<CartItem>();
        }
    }
}
