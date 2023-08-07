using AutoMapper;
using MediatR;
using SchoolRecords.ApplicationServices.Interfaces;
using SchoolRecords.ApplicationServices.Users.Commands.AddUser;
using SchoolRecords.Domain.Entities;
using SchoolRecords.Domain.Interfaces;
using SchoolRecords.Shared.Constants;
using SchoolRecords.Shared.Constants.Validations.User;
using SchoolRecords.Shared.Notifications;
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
        protected readonly IMapper _mapper;

        public NotificationContext NotificationContext { get; }

        public UserAppService(IUserRepository userRepository, ISchoolingRepository scholingRepository, NotificationContext notificationContext, IMapper mapper)
        {
            _userRepository = userRepository;
            _scholingRepository = scholingRepository;
            NotificationContext = notificationContext;
            _mapper = mapper;
        }

        public async Task<User> AddUser(AddUserCommand request)
        {
            var userExists = _userRepository.GetBy(x=>x.Email.ToLower().Trim() == request.Email.ToLower().Trim()).FirstOrDefault();
            if(userExists != null)
            {
                NotificationContext.AddNotification("bad_request", UserValidationMessage.USER_EXISTS_SAME_EMAIL);
                return null;
            }



            SchoolingTypeEnum schoolingTypeEnum;
            
            var user = _mapper.Map<User>(request);

            if (Enum.TryParse<SchoolingTypeEnum>(request.SchoolingTypr, true, out schoolingTypeEnum))
            {
                var schooling = _scholingRepository.GetBy(x => x.Type == schoolingTypeEnum).FirstOrDefault();
                user.Schooling = schooling;
            }
            
            if(!user.IsValid)
                foreach (var err in user.Errors)
                    NotificationContext.AddNotification("bad_request", err);

            if (!NotificationContext.Succeeded)
                return null;

            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync();

            return user;
        }
    }
}
