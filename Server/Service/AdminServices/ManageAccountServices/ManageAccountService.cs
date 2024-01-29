using imc_web_api.Dtos.AuthDtos;
using imc_web_api.Models;
using Microsoft.AspNetCore.Identity;
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

        //---> AddUser
        public async Task<user> AddUser(RegisterRequestDTO UserInputReguest)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //---> DeleteUser
        public async Task<user> DeleteUser(Guid id)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id.ToString());

                if (user == null)
                {
                    throw new Exception("User not found");
                }

                var result = await _userManager.DeleteAsync(user);

                if (!result.Succeeded)
                {
                    throw new Exception("Failed to delete user.");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //---> GetUserById
        public async Task<user> GetUserById(Guid id)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id.ToString());
                if (user == null)
                {
                    return null;
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //---> GetUsers
        public async Task<List<user>> GetUsers()
        {
            try
            {
                return await _userManager.Users

                     .Include(u => u.ServiceProviderType)
                     .Include(u => u.User_Qualification)
                     .Include(u => u.order)
                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //---> UpdateUser
        public async Task<user> UpdateUser(Guid id, RegisterRequestDTO UserInputReguest)
        {
            try
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
                else
                {
                    throw new Exception("User not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred during user update. Details: {ex.Message}");
            }
        }
    }
}