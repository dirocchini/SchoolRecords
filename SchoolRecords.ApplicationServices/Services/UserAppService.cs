using SchoolRecords.ApplicationServices.Interfaces;
using SchoolRecords.Domain.Entities;
using SchoolRecords.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.ApplicationServices.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUser(User user)
        {
            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
