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
            private readonly IUserAppService _userAppService;

            public Handler(IMapper mapper, IUserAppService userAppService) : base(mapper)
            {
                _userAppService = userAppService;
            }

            public async Task<NewUserVm> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                await _userAppService.AddUser(request);
                return new NewUserVm { };
            }
        }
    }
}