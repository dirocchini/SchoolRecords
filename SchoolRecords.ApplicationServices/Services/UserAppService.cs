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
        private readonly ISchoolingRepository _scholingRepository;

        public UserAppService(IUserRepository userRepository, ISchoolingRepository scholingRepository)
        {
            _userRepository = userRepository;
            _scholingRepository = scholingRepository;
        }

        public async Task AddUser(User user)
        {
            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
