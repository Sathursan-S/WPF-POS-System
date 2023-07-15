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
using System.Windows.Controls;
using WpfAppPOS1.Models;


namespace WpfAppPOS1.ViewModels
{
    public partial class ManageStaffVM : ObservableObject
    {
        //create observableproperty for viewmodel
        [ObservableProperty]
        public int id;
        [ObservableProperty]
        public string username;
        [ObservableProperty]
        public string password;
        [ObservableProperty]
        public string firstname;
        [ObservableProperty]
        public string lastname;
        [ObservableProperty]
        public int phone;
        [ObservableProperty]
        public bool isAdmin;
        [ObservableProperty]
        ObservableCollection<User> users;

        private User _selectedStaff;
        //selectedstaff metode
        public User SelectedStaff
        {
            get { return _selectedStaff; }
            set
            {
                SetProperty(ref _selectedStaff, value);
                if (value != null)
                {
                    Id = value.Id;
                    Username = value.Username;
                    Password = Password;
                    Firstname = value.FirstName;
                    Lastname = value.LastName;
                    Phone = value.Phone;
                    IsAdmin = value.IsAdmin;
                }
            }
        }

        //find is edited
        public bool IsEdited
        {
            get
            {
                if (SelectedStaff == null)
                {
                    return false;
                }
                return SelectedStaff.Username != Username || SelectedStaff.IsAdmin != IsAdmin || SelectedStaff.FirstName != Firstname || SelectedStaff.LastName != Lastname || SelectedStaff.Phone != Phone || !SelectedStaff.VerifyPassword(Password);
            }
        }

        //loadsaff method to load from db
        public void LoadStaff()
        {
            using (var db = new MyDbContext())
            {
                Users = new ObservableCollection<User>(db.Users.ToList());
            }
        }

        //addstaff metode
        [RelayCommand]
        public void CreateStaff()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Firstname))
            {
                MessageBox.Show("Please fill in all the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                var staff = new User
                {
                    Username = Username,
                    IsAdmin = IsAdmin,
                    FirstName = Firstname,
                    LastName = Lastname,
                    Phone = Phone
                };
                staff.GeneratePasswordHash(Password);
                using (var db = new MyDbContext())
                {
                    db.Users.Add(staff);
                    db.SaveChanges();
                }
                Reset();
                LoadStaff();
            }
        }
        //updatestaff metode
        [RelayCommand]
        public void UpdateStaff()
        {
            if (IsEdited)
            {
                using var db = new MyDbContext();
                var staff = db.Users.Find(id);
                staff.Username = Username;
                staff.IsAdmin = IsAdmin;
                staff.FirstName = Firstname;
                staff.LastName = Lastname;
                staff.Phone = Phone;
                if (!string.IsNullOrEmpty(Password))
                {
                    staff.GeneratePasswordHash(Password);
                }
                db.SaveChanges();

                LoadStaff();
                SelectedStaff = null;
                Reset();
            }
            else
            {
                MessageBox.Show("No changes made", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        
        //deletestaff metode
        [RelayCommand]
        public void DeleteStaff()
        {
            if (SelectedStaff == null)
            {
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this person?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new MyDbContext())
                {
                    db.Users.Remove(SelectedStaff);
                    db.SaveChanges();
                }
                LoadStaff();
            }
            SelectedStaff = null;
            Reset();
        }
        //reset metode
        [RelayCommand]
        public void Reset()
        {
            Id = 0;
            Username= "";
            Password = "";
            Firstname = "";
            Lastname = "";
            Phone = 0;
            IsAdmin = false;
            LoadStaff();
        }

        public ManageStaffVM()
        {
            LoadStaff();
        }
    }
}
