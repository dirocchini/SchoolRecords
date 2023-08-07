using AutoMapper;
using MediatR;
using SchoolRecords.ApplicationServices.Common.Handlers;
using SchoolRecords.ApplicationServices.Interfaces;
using SchoolRecords.ApplicationServices.Users.Queries.GetAllUsers;
using SchoolRecords.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.ApplicationServices.Schoolings.Commands.Query
{
    public class GetAllSchoolingQuery : IRequest<List<SchoolingVm>>
    {
        public class Handler : CommandBaseHandler, IRequestHandler<GetAllSchoolingQuery, List<SchoolingVm>>
        {
            private readonly ISchoolingRepository _schoolingRepository;

            public Handler(IMapper mapper, ISchoolingRepository schoolingRepository) : base(mapper)
            {
                _schoolingRepository = schoolingRepository;
            }

            public async Task<List<SchoolingVm>> Handle(GetAllSchoolingQuery request, CancellationToken cancellationToken)
            {
                var schoolings = _schoolingRepository.GetAllActive();
                var schoolingVms = _mapper.Map<List<SchoolingVm>>(schoolings);

                return schoolingVms;
            }
        }
    }
}
