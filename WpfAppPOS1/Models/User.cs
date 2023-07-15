using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPOS1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public bool IsAdmin { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }

        public User()
        {
            Id = GenerateNewID();
        }

        // generate unique user id
        private static int _lastID = 1001;
        public static int GenerateNewID()
        {
            return _lastID++;
        }

        //// generate new unique staff id
        //public static string GenerateNewStaffID()
        //{
        //    return "STF" + GenerateNewID().ToString("D3");
        //}

        //// create staff method using createuser method
        //public static User CreateStaff(string username, string password, bool isAdmin, string firstName, string lastName, int phone)
        //{
        //    var staff = new User
        //    {
        //        Username = username,
        //        IsAdmin = isAdmin,
        //        FirstName = firstName,
        //        LastName = lastName,
        //        Phone = phone,
        //        DateJoined = DateTime.Now
        //    };
        //    staff.GeneratePasswordHash(password);
        //    return staff;
        //}

        //// update staff method with staffid
        //public static void UpdateStaff(int id, string username, string password, bool isAdmin, string firstName, string lastName, int phone)
        //{
        //    using var db = new MyDbContext();
        //    var staff = db.Users.Find(id);
        //    staff.Username = username;
        //    staff.IsAdmin = isAdmin;
        //    staff.FirstName = firstName;
        //    staff.LastName = lastName;
        //    staff.Phone = phone;
        //    staff.GeneratePasswordHash(password);
        //    db.SaveChanges();
        //}

        public bool VerifyPassword(string password)
        {
            using var hmac = new HMACSHA512(PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != PasswordHash[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void GeneratePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            PasswordSalt = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
