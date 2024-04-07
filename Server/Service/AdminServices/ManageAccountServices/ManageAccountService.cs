using imc_web_api.Dtos.AuthDtos;
using imc_web_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.AdminServices.ManageAccountServices
{
    public class ManageAccountService : IManageAccountService
    {
        private readonly UserManager<user> _userManager;
        private readonly ImcDbContext _imcDbContext;

        public ManageAccountService(UserManager<user> userManager, ImcDbContext imcDbContext)
        {
            _userManager = userManager;
            _imcDbContext = imcDbContext;
        }

        //---> AddUser
        public async Task<user> AddUser(RegisterRequestDTO UserInputReguest)
        {
            var checkUser = await _userManager.FindByEmailAsync(UserInputReguest.Email);
            if (checkUser == null)
            {
                var newUser = new user
                {
                    FirstName = UserInputReguest.FirstName,
                    LastName = UserInputReguest.LastName,
                    Email = UserInputReguest.Email,
                    UserName = UserInputReguest.Email,
                    PhoneNumber = UserInputReguest.PhoneNumber,
                    Gender = UserInputReguest.Gender,
                    Role = UserInputReguest.Role,

                    ServiceProvidertypeId = UserInputReguest.ServiceProvidertypeId,

                    User_QualificationId = UserInputReguest.User_QualificationId
                };

                var CreatedUser = await _userManager.CreateAsync(newUser, UserInputReguest.Password);
                if (CreatedUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, UserInputReguest.Role);

                    return newUser;
                }
                else
                {
                    throw new Exception("User creation failed. Please check the provided data.");
                }
            }
            else
            {
                throw new Exception("User Already Exist With this Email!");
            }
        }

        //---> DeleteUser



        public async Task<user?> DeleteUser(Guid id)
        {
            var user = await _userManager.Users
                .Include(u => u.ServiceProviderType)
                .Include(u => u.User_Qualification)
                .Include(u => u.OrdersByUser)
                .Include(u => u.services)
                .FirstOrDefaultAsync(u => u.Id == id.ToString());

            if (user == null)
            {
                return null;
            }

            // Get all orders for the user
            var orders = await _imcDbContext.Orders
                .Where(order => order.OrderByUserId == user.Id)
                .ToListAsync();

            // Delete associated order items for each order
            foreach (var order in orders)
            {
                var orderItems = await _imcDbContext.OrderItems
                    .Where(item => item.OrderId == order.Id)
                    .ToListAsync();

                _imcDbContext.OrderItems.RemoveRange(orderItems);
            }

            // Delete user-related entities
            if (user.ServiceProviderType != null)
            {
                _imcDbContext.ServiceProviderTypes.Remove(user.ServiceProviderType);
            }

            if (user.User_Qualification != null)
            {
                _imcDbContext.User_Qualifications.Remove(user.User_Qualification);
            }

            if (user.services != null)
            {
                _imcDbContext.Services.RemoveRange(user.services);
            }

            // Delete the user
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return null;
            }

            return user;
        }









        //-----------------------------end
        //public async Task<user?> DeleteUser(Guid id)
        //{
        //    var user = await _userManager.Users

        // .Include(u => u.ServiceProviderType)
        // .Include(u => u.User_Qualification)
        // .Include(u => u.OrdersByUser)
        // .Include(u => u.services)
        // .FirstOrDefaultAsync(u => u.Id == id.ToString());

        //    if (user == null)
        //    {
        //        return null;
        //    }



        //    if (user.ServiceProviderType != null)
        //    {
        //        _imcDbContext.ServiceProviderTypes.Remove(user.ServiceProviderType);
        //    }

        //    if (user.User_Qualification != null)
        //    {
        //        _imcDbContext.User_Qualifications.Remove(user.User_Qualification);
        //    }

        //    if (user.services != null)
        //    {
        //        foreach (var service in user.services)
        //        {

        //            var orderItems = _imcDbContext.OrderItems.Where(oi => oi.ServiceId == service.Id);
        //            _imcDbContext.OrderItems.RemoveRange(orderItems);
        //            _imcDbContext.Services.RemoveRange(service);
        //        }
        //    }



        //    var result = await _userManager.DeleteAsync(user);

        //    if (!result.Succeeded)
        //    {
        //        return null;
        //    }
        //    return user;
        //}

        //---> GetUserById
        public async Task<user?> GetUserById(Guid id)
        {
            return await _userManager.Users
                .Include(U => U.ServiceProviderType)
                .Include(U => U.User_Qualification)
                .FirstOrDefaultAsync(u => u.Id == id.ToString());
        }

        //---> GetUsers
        public async Task<List<user>> GetUsers(string? filterOn = null, string? filterQuery = null, int pageNumber = 1, int pageSize = 100)
        {
            var data = _userManager.Users

                 .Include(u => u.ServiceProviderType)
                 .Include(u => u.User_Qualification)
                 .Include(u => u.OrdersByUser)
                 .Include(u => u.services).AsQueryable();

            //if (filterOn.Equals("firstname", StringComparison.OrdinalIgnoreCase))
            //{
            //    data=data.Where(u => u.FirstName.Contains(filterQuery));
            //}

            //var pagination = (pageNumber - 1) * pageSize;
            //data = data.Skip(pagination).Take(pageSize);
            return await data.ToListAsync();
        }

        //---> UpdateUser
        public async Task<user?> UpdateUser(Guid id, RegisterRequestDTO UserInputReguest)
        {
            var existingUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id.ToString());

            if (existingUser != null)
            {
                existingUser.FirstName = UserInputReguest.FirstName;
                existingUser.LastName = UserInputReguest.LastName;
                existingUser.Email = UserInputReguest.Email;
                existingUser.UserName = UserInputReguest.Email;
                existingUser.PhoneNumber = UserInputReguest.PhoneNumber;
                existingUser.Gender = UserInputReguest.Gender;
                existingUser.Role = UserInputReguest.Role;

                var result = await _userManager.UpdateAsync(existingUser);
                if (result.Succeeded)
                {
                    return existingUser;
                }
                else
                {
                    throw new Exception("Faild to update user!");
                }
            }
            return null;
        }
    }
}