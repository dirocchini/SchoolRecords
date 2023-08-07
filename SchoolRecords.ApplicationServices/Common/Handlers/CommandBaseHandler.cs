using AutoMapper;

namespace SchoolRecords.ApplicationServices.Common.Handlers
{
    public abstract class CommandBaseHandler
    {
        protected readonly IMapper _mapper;

        protected CommandBaseHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
