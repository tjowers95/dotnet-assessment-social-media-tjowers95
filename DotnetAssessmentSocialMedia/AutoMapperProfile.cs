using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Dtos;
using Profile = AutoMapper.Profile;

namespace DotnetAssessmentSocialMedia
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUserDto, User>()
                .ForAllOtherMembers(m => m.Ignore());
            
            CreateMap<Credentials, CredentialsDto>();
            
            CreateMap<Profile, ProfileDto>();
            
            CreateMap<User, UserResponseDto>()
                .ForMember(
                    dest => dest.Username,
                    opt => opt.MapFrom(src => src.Credentials.Username)
                );
        }
    }
}