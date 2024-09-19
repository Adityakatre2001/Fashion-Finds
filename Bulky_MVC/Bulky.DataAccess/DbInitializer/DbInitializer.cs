using FashionFinds.DataAcess.Data;
using FashionFinds.Models;
using FashionFinds.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionFinds.DataAccess.DbInitializer {
    public class DbInitializer : IDbInitializer {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db) {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }


        public void Initialize() {


            //migrations if they are not applied
            try {
                if (_db.Database.GetPendingMigrations().Count() > 0) {
                    _db.Database.Migrate();
                }
            }
            catch(Exception ex) { }

            //Role manager is used to crete role
            //User manager is used to create users

            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult()) {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();// As Initialize method is not
                                                                                                      // marked as async (i.e., it's a synchronous method),
                                                                                                      // so await cannot be used directly. so we used GetAwaiter()
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();


                //if roles are not created, then we will create admin user as well
                //By default it will add to our db
                _userManager.CreateAsync(new ApplicationUser {
                    UserName = "admin@fashionFinds.com",
                    Email = "admin@fashionFinds.com",
                    Name = "Aditya Katre",
                    PhoneNumber = "9561889057",
                    StreetAddress = "Akurdi Pune",
                    State = "Maharastra",
                    PostalCode = "411035",
                    City = "Pune"
                }, "Admin123*").GetAwaiter().GetResult();


                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@fashionFinds.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

            }

            return;
        }
    }
}
