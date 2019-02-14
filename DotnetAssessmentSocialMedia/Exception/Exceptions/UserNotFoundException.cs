namespace DotnetAssessmentSocialMedia.Exception.Exceptions
{
    public class UserNotFoundException : NotFoundCustomException
    {

        public UserNotFoundException() : this("User not found", "A user with the given username does not exist")
        {
        }
        
        private UserNotFoundException(string message, string description) : base(message, description)
        {
        }
    }
}