using AutoMapper;
using MediatR;
using SchoolRecords.ApplicationServices.Common.Handlers;
using SchoolRecords.ApplicationServices.Interfaces;
using SchoolRecords.Domain.Entities;
using SchoolRecords.Domain.Interfaces;
using SchoolRecords.Shared.Constants;
using SchoolRecords.Shared.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.ApplicationServices.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<NewUserVm>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public string SchoolingTypr { get; set; }


        public class Handler : CommandBaseHandler, IRequestHandler<AddUserCommand, NewUserVm>
        {
            public NotificationContext NotificationContext { get; }
            private readonly IUserAppService _userAppService;

            public Handler(IMapper mapper, IUserAppService userAppService, NotificationContext notificationContext) : base(mapper)
            {
                _userAppService = userAppService;
                NotificationContext = notificationContext;
            }

            public async Task<NewUserVm> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                SchoolingTypeEnum schoolingTypeEnum;
                if (!Enum.TryParse<SchoolingTypeEnum>(request.SchoolingTypr, out schoolingTypeEnum))
                    NotificationContext.AddNotification("bad_request", ExceptionMessage.SCHOOLING_NOT_FOUND);


                if (!NotificationContext.Succeeded)
                    return null;

                await _userAppService.AddUser(_mapper.Map<User>(request));
                return new NewUserVm { };
            }
        }
    }
}