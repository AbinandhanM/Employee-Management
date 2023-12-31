﻿using EmployeeAPI.Interfaces;
using EmployeeAPI.Models.DTOs;
using EmployeeAPI.Models;
using System.Security.Cryptography;
using System.Text;
using UserManagementAPI.Interfaces;

namespace EmployeeAPI.Services
{
    public class ManageUserService : IManageUser
    {
        private readonly IRepo<int, User> _userRepo;
        private readonly IRepo<int, Employee> _employeeRepo;
        private readonly ITokenGenerate _tokenService;
        private readonly IGeneratePassword _passwordService;
        

        public ManageUserService(IRepo<int, User> userRepo,
            IRepo<int, Employee> employeeRepo,
            IGeneratePassword passwordService,
            ITokenGenerate tokenService
            )
        {
            _userRepo = userRepo;
            _employeeRepo = employeeRepo;
            _tokenService = tokenService;
            _passwordService = passwordService;
           
        }

        public async Task<Employee?> AddEmployee(Employee employee)
        {
            UserDTO? user = null;
            var hmac = new HMACSHA512();
            string? generatedPassword = await _passwordService.GeneratePassword(employee);
            employee.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(generatedPassword));
            employee.User.PasswordKey = hmac.Key;
            employee.User.Status = "InActive";
            var userResult = await _userRepo.Add(employee.User);
            var employeeResult = await _employeeRepo.Add(employee);
            if (userResult != null && employeeResult != null)
            {
                return employeeResult;
            }
            return null;
        }

        public async Task<User?> ChangeStatus(UpdateUserStatus user)
        {
            var employees = await _userRepo.GetAll();
            if (employees != null) 
            {
                var employeeStatusUpdate = employees.FirstOrDefault(e => e.UserId == user.userId);
                if (employeeStatusUpdate != null)
                {
                    employeeStatusUpdate.Status = user.status;
                    var updatedUser = await _userRepo.Update(employeeStatusUpdate);
                    return updatedUser;
                }
            }
            return null;
        }

         public async Task<UserDTO?> Login(UserDTO user)
         {
            var userData = await _userRepo.Get(user.UserID);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.PasswordKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.PasswordHash[i])
                        return null;
                }
                if (userData.Status == "Active")
                {
                    user = new UserDTO();
                    user.UserID = userData.UserId;
                    user.Role = userData.Role;
                    user.Token = _tokenService.GenerateToken(user);
                    return user;
                }
            }
            return null;
        }

        public async Task<UserDTO?> Register(Employee employee)
        {

            UserDTO? user = null;
            var employeeResult = await AddEmployee(employee);
            if (employeeResult != null)
            {
                var userResult = await _userRepo.Get(employeeResult.ID);
                if (userResult != null)
                {
                    user = new UserDTO();
                    user.UserID = userResult.UserId;
                    user.Role = userResult.Role;
                    user.Token = _tokenService.GenerateToken(user);
                    return user;
                }
            }
            return null;

        }
    }
}
