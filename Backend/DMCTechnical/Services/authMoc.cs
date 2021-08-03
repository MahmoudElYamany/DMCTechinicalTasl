using Context;
using Microsoft.AspNetCore.Identity;
using Models;
using Services.Interface;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class authMoc :Iauth
    {
        private readonly UserManager<Customer> _user;
        private readonly ApiContext _db;
        private readonly RoleManager<IdentityRole> _role;

        public authMoc(UserManager<Customer> user, ApiContext db, RoleManager<IdentityRole> role)
        {
            _user = user;
            _db = db;
            _role = role;
        }

        public async Task<Customer> RegisterAsync(RegisterModel rm)
        {

            if (await _user.FindByEmailAsync(rm.Email) != null)
                return new Customer { Message = "E-mail already Existed" };
            if (await _user.FindByNameAsync(rm.Username) != null)
                return new Customer { Message = "UserName already Existed" };
            var user = new Customer()
            {
                FName = rm.Firstname,
                LName = rm.Lastname,
                Email = rm.Email,
                UserName = rm.Username,
                Country_Id = rm.countryid,
                City_Id = rm.cityid,
                birthday = rm.birthdate,
                PhoneNumber = rm.phone,
                Gender = rm.Gender,
                JoinedDate = DateTime.Now,
                IsActive = true
            };
            var result = await _user.CreateAsync(user, rm.Password);
            if (!result.Succeeded)
            {
                var errs = "";
                foreach (var item in result.Errors)
                {
                    errs = $"{item.Description} , ";
                }
                return new Customer { Message = errs };
            }
            await _user.AddToRoleAsync(user, "User");

            return new Customer { 
                Message = "scuccess",
                UserName = rm.Username
            };
        }

        public async Task<Customer> LogInAsync(LogInModel lm)
        {
            var user = lm.Username.Contains('@') ? await _user.FindByEmailAsync(lm.Username) : await _user.FindByNameAsync(lm.Username);

            var ValidPassword = await _user.CheckPasswordAsync(user, lm.Password);
            if (user.IsActive == true)
            {
                if (user == null || !ValidPassword)
                {
                    return new Customer { Message = "Invalid Username or Password" };

                }
                else
                {
                    Customer auth = new Customer
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                    };

                    return auth;
                }
            }
            else
                return new Customer() { Message = "Invalid details" };
        }

        public async Task<Customer> RegisterAsyncAdmin(RegisterModel rm)
        {
            if (await _user.FindByEmailAsync(rm.Email) != null)
                return new Customer { Message = "E-mail already Existed" };
            if (await _user.FindByNameAsync(rm.Username) != null)
                return new Customer { Message = "UserName already Existed" };
            var user = new Customer()
            {
                FName = rm.Firstname,
                LName = rm.Lastname,
                Email = rm.Email,
                UserName = rm.Username,
                Country_Id = rm.countryid,
                City_Id = rm.cityid,
                birthday = rm.birthdate,
                PhoneNumber = rm.phone,
                Gender = rm.Gender,
                JoinedDate = DateTime.Now,
                IsActive = true
            };
            var result = await _user.CreateAsync(user, rm.Password);
            if (!result.Succeeded)
            {
                var errs = "";
                foreach (var item in result.Errors)
                {
                    errs = $"{item.Description} , ";
                }
                return new Customer { Message = errs };
            }
            await _user.AddToRoleAsync(user, "Admin");

            return new Customer { Message = "scuccess" };
        }
    }
}
