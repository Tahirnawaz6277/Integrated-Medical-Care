﻿using imc_web_api.Dtos.AuthDtos;

namespace imc_web_api.Repository.AuthRepository
{
    public interface IRegisterRepository
    {
        Task AddUser(RegisterRequestDTO userData);
    }
}
