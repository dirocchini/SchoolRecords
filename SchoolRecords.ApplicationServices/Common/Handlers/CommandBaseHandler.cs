using AutoMapper;
using SchoolRecords.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
