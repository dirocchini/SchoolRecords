using AutoMapper;
using MediatR;
using SchoolRecords.ApplicationServices.Common.Handlers;
using SchoolRecords.ApplicationServices.Interfaces;

namespace SchoolRecords.ApplicationServices.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdatedUserVm>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int SchoolingTypeId { get; set; }


        public class Handler : CommandBaseHandler, IRequestHandler<UpdateUserCommand, UpdatedUserVm>
        {
            private readonly IUserAppService _userAppService;

            public Handler(IMapper mapper, IUserAppService userAppService) : base(mapper)
            {
                _userAppService = userAppService;
            }

            public async Task<UpdatedUserVm> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userAppService.UpdateUser(request);
                if (user == null) return null;

                return _mapper.Map<UpdatedUserVm>(user);
            }
        }
    }
}