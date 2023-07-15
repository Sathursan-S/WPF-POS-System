using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using WpfAppPOS1.Models;

namespace WpfAppPOS1.ViewModels
{
    public partial class ManageStockVM : ObservableObject
    {
        //create observableproperty for viewmodel
        [ObservableProperty]
        public int stockId;
        [ObservableProperty]
        public int productId;
        [ObservableProperty]
        public int quantity;
        [ObservableProperty]
        public double costPrice;
        [ObservableProperty] 
        public double sellingPrice;
        [ObservableProperty]
        public DateTime lastUpdated;
        [ObservableProperty]
        ObservableCollection<Stock> stocks;
        [ObservableProperty]
        public ObservableCollection<int> products;


        private Stock _selectedStock;
        //selectedstock method
        public Stock SelectedStock
        {
            get { return _selectedStock; }
            set
            {
                SetProperty(ref _selectedStock, value);
                if (value != null)
                {
                    StockId = value.StockId;
                    ProductId = value.ProductID;
                    Quantity = value.Quantity;
                    CostPrice = value.CostPrice;
                    SellingPrice = value.SellingPrice;
                    LastUpdated = value.LastUpdated;
                }
            }
        }

        //find if edited
        public bool IsEdited
        {
            get
            {
                if (SelectedStock == null)
                {
                    return false;
                }
                return SelectedStock.ProductID != ProductId || SelectedStock.Quantity != Quantity || SelectedStock.CostPrice != CostPrice || SelectedStock.SellingPrice != SellingPrice || SelectedStock.LastUpdated != LastUpdated;
            }
        }

        //loadstocks method to load from db
        public void LoadStocks()
        {
            using (var db = new MyDbContext())
            {
                Stocks = new ObservableCollection<Stock>(db.Stocks.ToList());
                Products = new ObservableCollection<int>(db.Products.Select(p => p.ProductID).ToList());
            }
        }

        //addstock method
        [RelayCommand]
        public void CreateStock()
        {
            if (ProductId <= 0 || Quantity <= 0 || CostPrice <= 0 || SellingPrice <= 0)
            {
                MessageBox.Show("Please fill in all the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                using var db1 = new MyDbContext();
                if (db1.Products.Any(p => p.ProductID == ProductId))
                {
                    
                    var stock = new Stock
                    {
                        ProductID = ProductId,
                        Quantity = Quantity,
                        CostPrice = CostPrice,
                        SellingPrice = SellingPrice,
                        LastUpdated = DateTime.Now
                    };
                    using (var db = new MyDbContext())
                    {
                        db.Stocks.Add(stock);
                        db.SaveChanges();
                    }
                    Reset();
                    LoadStocks();
                }
                else
                {
                    MessageBox.Show("product not exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }

        //updatestock method
        [RelayCommand]
        public void UpdateStock()
        {
            if (IsEdited)
            {
                using var db = new MyDbContext();
                var stock = db.Stocks.Find(StockId);
                stock.ProductID = ProductId;
                stock.Quantity = Quantity;
                stock.CostPrice = CostPrice;
                stock.SellingPrice = SellingPrice;
                stock.LastUpdated = DateTime.Now;
                db.SaveChanges();

                LoadStocks();
                SelectedStock = null;
                Reset();
            }
            else
            {
                MessageBox.Show("No changes made", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        //deletestock method
        [RelayCommand]
        public void DeleteStock()
        {
            if (SelectedStock == null)
            {
                return;
            }
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this stock?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new MyDbContext())
                {
                    db.Stocks.Remove(SelectedStock);
                    db.SaveChanges();
                }
                LoadStocks();
            }
            SelectedStock = null;
            Reset();
        }

        //reset method
        [RelayCommand]
        public void Reset()
        {
            StockId = 0;
            ProductId = 0;
            Quantity = 0;
            CostPrice = 0;
            SellingPrice = 0;
            LoadStocks();
        }

        public ManageStockVM()
        {
            LoadStocks();
        }
    }
}