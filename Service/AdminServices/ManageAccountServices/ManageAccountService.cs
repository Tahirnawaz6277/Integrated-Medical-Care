using imc_web_api.Dtos;
using imc_web_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.AdminServices.ManageAccountServices
{
    public class ManageAccountService : IManageAccountService
    {
        private readonly UserManager<user> _userManager;

        public ManageAccountService(UserManager<user> userManager)
        {
            _userManager = userManager;
        }

        public async Task<user> AddUser(RegisterRequestDTO UserInputReguest)
        {
            try
            {
                var checkUser = await _userManager.FindByEmailAsync(UserInputReguest.Email);
                if (checkUser == null)
                {
                    var newUser = new user
                    {
                        firstName = UserInputReguest.firstName,
                        lastName = UserInputReguest.lastName,
                        Email = UserInputReguest.Email,
                        UserName = UserInputReguest.Email,
                        contact = UserInputReguest.contact,
                        gender = UserInputReguest.gender,
                        Role = UserInputReguest.Role,
                    };

                    var CreatedUser = await _userManager.CreateAsync(newUser, UserInputReguest.password);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<IActionResult> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<user> GetUserById()
        {
            throw new NotImplementedException();
        }

        public async Task<List<user>> GetUsers()
        {
            try
            {
                return await _userManager.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<user> UpdateUser(Guid id, RegisterRequestDTO UserInputReguest)
        {
            throw new NotImplementedException();
        }
    }
}