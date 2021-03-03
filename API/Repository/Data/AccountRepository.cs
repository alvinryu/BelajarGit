using API.Context;
using API.Models;
using API.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly IConfiguration _configuration;

        public AccountRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            _configuration = configuration;
        }

        public UserVM Login(LoginVM loginVM)
        {
            var _userRepository = new GeneralDapperRepository<UserVM>(_configuration);

            _parameters.Add("@Email", loginVM.Email);
            _parameters.Add("@Password", loginVM.Password);
            var result = _userRepository.Query("SP_RetrieveLogin", _parameters);
            return result;
        }
    }
}