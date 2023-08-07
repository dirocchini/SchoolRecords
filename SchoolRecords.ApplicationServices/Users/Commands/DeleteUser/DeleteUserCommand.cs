using AutoMapper;
using MediatR;
using SchoolRecords.ApplicationServices.Common.Handlers;
using SchoolRecords.ApplicationServices.Interfaces;
using SchoolRecords.ApplicationServices.Users.Commands.AddUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.ApplicationServices.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool?>
    {
        public string UserEmail { get; set; }



        public class Handler : CommandBaseHandler, IRequestHandler<DeleteUserCommand, bool?>
        {
            private readonly IUserAppService _userAppService;

            public Handler(IMapper mapper, IUserAppService userAppService) : base(mapper)
            {
                _userAppService = userAppService;
            }

            public async Task<bool?> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var deleted = await _userAppService.DeleteUser(request.UserEmail);
                if (deleted == null) return false;

                return true;
            }
        }
    }
}