namespace DotnetAssessmentSocialMedia.Exception.Exceptions
{
    public class InvalidCredentialsException : ForbiddenCustomException
    {
        public InvalidCredentialsException() : this("Invalid credentials", "The credentials provided do not match with the credentials on file")
        {
        }

        private InvalidCredentialsException(string message, string description) : base(message, description)
        {
        }
    }
}