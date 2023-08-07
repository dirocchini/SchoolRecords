using AutoMapper;
using SchoolRecords.ApplicationServices.Schoolings.Commands.Query;
using SchoolRecords.ApplicationServices.Users.Commands.AddUser;
using SchoolRecords.ApplicationServices.Users.Commands.UpdateUser;
using SchoolRecords.ApplicationServices.Users.Queries.GetAllUsers;
using SchoolRecords.Domain.Entities;

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

            CreateMap<User, NewUserVm>();
            CreateMap<User, UpdatedUserVm>();
            CreateMap<User, UserVm>();
            CreateMap<Schooling, SchoolingVm>();

            CreateMap<UpdateUserCommand, User>()
                .ForMember(x => x.SchoolRecordId, opt => opt.Ignore())
                .ForMember(x => x.SchoolRecord, opt => opt.Ignore());
        }
    }
}
