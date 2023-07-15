using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppPOS1.Models;

namespace WpfAppPOS1.ViewModels
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string username;
        [ObservableProperty]
        public string password;


        [RelayCommand]
        public void LogIn()
        {
            // Retrieve user with matching username from database
            User user_X = GetUserFromDatabase(Username);

            // If user exists and password matches, login successful
            if (user_X != null && user_X.VerifyPassword(Password))
            {
                // Password is correct, open new window
                if (user_X.IsAdmin)
                {
                    var newWindow = new Views.AdminDashboard();
                    newWindow.Show();
                }
                else
                {
                    // Create an instance of the SaleWindowVM and pass the User_X data
                    SaleWindowVM saleWindowVM = new SaleWindowVM(user_X);

                    // Open the SaleWindow and set its DataContext to the SaleWindowVM
                    var saleWindow = new Views.SaleWindow();
                    saleWindow.DataContext = saleWindowVM;
                    saleWindow.Show();

                    //var newWindow = new Views.SaleWindow();
                    //newWindow.Show();
                    //MessageBox.Show("staf Dasboard");
                }

                // Close current window
                Application.Current.MainWindow.Close();
            }
            else
            {
                // Password is incorrect, show error message
                MessageBox.Show("Incorrect username or password.");
            }
        }

        private User GetUserFromDatabase(string username)
        {
            using (var db = new MyDbContext())
            {
                return db.Users.FirstOrDefault(u => u.Username == username);
            }
        }
    }
}
