using System;
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
                .ForMember(dest => dest.Credentials, opt => opt.MapFrom(src => src.Credentials))
                .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))
                .ForAllOtherMembers(m => m.Ignore());

            CreateMap<Tweet, TweetResponseDto>()
                .ForMember(dest => dest.TweetContent, opt => opt.MapFrom(src => src.TweetContent))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Author.Credentials.Username));

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