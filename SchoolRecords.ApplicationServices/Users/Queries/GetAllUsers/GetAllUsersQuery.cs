using AutoMapper;
using MediatR;
using SchoolRecords.ApplicationServices.Common.Handlers;
using SchoolRecords.ApplicationServices.Interfaces;

namespace SchoolRecords.ApplicationServices.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserVm>>
    {
        public class Handler : CommandBaseHandler, IRequestHandler<GetAllUsersQuery, List<UserVm>>
        {
            private readonly IUserAppService _userAppService;

            public Handler(IMapper mapper, IUserAppService userAppService) : base(mapper)
            {
                _userAppService = userAppService;
            }

            public async Task<List<UserVm>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var users = _userAppService.GetAllActive();
                var usersVm = _mapper.Map<List<UserVm>>(users);

                return usersVm ;
            }
        }
    }
}
