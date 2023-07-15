using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppPOS1.Views;

namespace WpfAppPOS1.ViewModels
{
    public partial class AdminDashboardVM : ObservableObject
    {
        [ObservableProperty]
        public object currentView;

        [RelayCommand]
        public void OpenManageStaff()
        {
            CurrentView = new ManageStaff();
            //var newWindow = new Views.ManageStaff();
            //newWindow.Show();
        }

        //open manage product commond
        [RelayCommand]
        public void OpenManageProduct()
        {
            CurrentView = new ManageProduct();
            //var newWindow = new Views.ManageProduct();
            //newWindow.Show();
        }

        //open manage stock commond
        [RelayCommand]
        public void OpenManageStock()
        {
            CurrentView = new ManageStock();
            //var newWindow = new Views.ManageStock();
            //newWindow.Show();
        }

        //logout commond
        [RelayCommand]
        public void Logout()
        {
            var newWindow = new MainWindow();
            newWindow.Show();
            // Close current window
            Application.Current.Windows.OfType<AdminDashboard>().FirstOrDefault()?.Close();
        }
    }
}
