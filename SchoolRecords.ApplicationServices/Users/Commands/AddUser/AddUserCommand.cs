using AutoMapper;
using MediatR;
using SchoolRecords.ApplicationServices.Common.Handlers;
using SchoolRecords.ApplicationServices.Interfaces;

namespace SchoolRecords.ApplicationServices.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<NewUserVm>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public string SchoolingType { get; set; }


        public class Handler : CommandBaseHandler, IRequestHandler<AddUserCommand, NewUserVm>
        {
            private readonly IUserAppService _userAppService;

            public Handler(IMapper mapper, IUserAppService userAppService) : base(mapper)
            {
                _userAppService = userAppService;
            }

            public async Task<NewUserVm> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userAppService.AddUser(request);
                if (user == null) return null;
                return _mapper.Map<NewUserVm>(user);
            }
        }
    }
}