using AutoMapper;
using SchoolRecords.ApplicationServices.Interfaces;
using SchoolRecords.ApplicationServices.Users.Commands.AddUser;
using SchoolRecords.ApplicationServices.Users.Commands.UpdateUser;
using SchoolRecords.Domain.Entities;
using SchoolRecords.Domain.Interfaces;
using SchoolRecords.Shared.Constants.Validations.User;
using SchoolRecords.Shared.Notifications;

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
            var userExists = _userRepository.GetBy(x => x.Email.ToLower().Trim() == request.Email.ToLower().Trim()).FirstOrDefault();
            if (userExists != null)
            {
                NotificationContext.AddNotification("bad_request", UserValidationMessage.USER_EXISTS_SAME_EMAIL);
                return null;
            }



            SchoolingTypeEnum schoolingTypeEnum;

            var user = _mapper.Map<User>(request);

            if (Enum.TryParse<SchoolingTypeEnum>(request.SchoolingType, true, out schoolingTypeEnum))
            {
                var schooling = _scholingRepository.GetBy(x => x.Type == schoolingTypeEnum).FirstOrDefault();
                user.Schooling = schooling;
            }

            if (!user.IsValid)
                foreach (var err in user.Errors)
                    NotificationContext.AddNotification("bad_request", err);

            if (!NotificationContext.Succeeded)
                return null;

            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync();

            return user;
        }

        public async Task<bool?> DeleteUser(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                NotificationContext.AddNotification("bad_request", UserValidationMessage.USER_NOT_FOUND);

            if (!NotificationContext.Succeeded)
                return null;

            user.SetInactive();
            await _userRepository.SaveChangesAsync();

            return true;
        }

        public async Task<User> UpdateUser(UpdateUserCommand request)
        {
            var user = _userRepository.GetBy(x => x.Email.ToLower().Trim() == request.Email.ToLower().Trim()).FirstOrDefault();
            if (user == null)
            {
                NotificationContext.AddNotification("bad_request", UserValidationMessage.USER_NOT_FOUND);
                return null;
            }

            SchoolingTypeEnum schoolingTypeEnum;

            var schooling = _scholingRepository.GetById(request.SchoolingTypeId);
            if (schooling == null)
            {
                NotificationContext.AddNotification("bad_request", UserValidationMessage.SCHOOLING_NULL);
                return null;
            }

            user.Schooling = schooling;

            if (!user.IsValid)
                foreach (var err in user.Errors)
                    NotificationContext.AddNotification("bad_request", err);

            if (!NotificationContext.Succeeded)
                return null;


            user.Name = request.Name;
            user.Surname = request.Surname;
            user.BirthDate = request.BirthDate;
            user.Email = request.Email;

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();

            return user;
        }

        public List<User> GetAllActive()
        {
            var users = _userRepository.GetBy(x => x.Active == true, x => x.Schooling).ToList();
            return users;
        }
    }
}
