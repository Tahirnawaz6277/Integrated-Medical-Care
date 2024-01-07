﻿using imc_web_api.Dtos;
using imc_web_api.Models;
using imc_web_api.Repository;
using Microsoft.AspNetCore.Identity;

namespace imc_web_api.Service.AuthService
{
    public class RegisterService : IRegistrationService
    {
        //creat api
        //update api
        //delete api
        //get api

        private readonly IRegisterRepository _registerRepository;
        private readonly UserManager<user> _userManager;
        public RegisterService(IRegisterRepository registerRepository  , UserManager<user> userManager)
        {
            _registerRepository = registerRepository;
            _userManager = userManager;
        }


        public async  Task<user> AddUser(RegisterRequestDTO userData)
        {

            if (userData == null)
            {
                throw new Exception("Invalid Credential!");
            }

            //user object
            var userIdentity = new user
            {
                firstName = userData.firstName,
                lastName = userData.lastName,
                Email = userData.Email,
                UserName = userData.Email,
                contact = userData.contact,
                gender = userData.gender,
                Role = userData.Role,
            };
            // check the User is Already Exist
            var isExistingUser = await _userManager.FindByEmailAsync(userData.Email) != null;

            if (isExistingUser)
            {
            
                throw new Exception("User already exists.");
            }

            var registerdUser = await _userManager.CreateAsync(userIdentity, userData.password);

            if (!registerdUser.Succeeded)
            {
                
                throw new Exception("Failed to register user.");
            }
            if (!string.IsNullOrWhiteSpace(userData.Role))
            {
                //Add Role For the user
                registerdUser = await _userManager.AddToRoleAsync(userIdentity, userData.Role);

                if (!registerdUser.Succeeded)
                {
              
                    // Rollback user creation if adding role fails
                    await _userManager.DeleteAsync(userIdentity);
            
                    throw new Exception("Failed to assign role to user.");

                }
            }
            return userIdentity;
        }
    }
}
