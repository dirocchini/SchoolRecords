using AutoMapper;
using SchoolRecords.ApplicationServices.Users.Commands.AddUser;
using SchoolRecords.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.ApplicationServices.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddUserCommand, User>()
                .ForMember(x => x.SchoolingId, opt => opt.Ignore())
                .ForMember(x => x.Schooling, opt => opt.Ignore())
                .ForMember(x => x.SchoolRecordId, opt => opt.Ignore())
                .ForMember(x => x.SchoolRecord, opt => opt.Ignore());
        }
    }
}
