namespace DotnetAssessmentSocialMedia.Dtos
{
    public class CreateUserDto
    {
        public ProfileDto Profile { get; set; }
        
        public CredentialsDto Credentials { get; set; }
    }
}