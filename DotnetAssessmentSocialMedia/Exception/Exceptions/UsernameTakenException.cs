using System.Net;

namespace DotnetAssessmentSocialMedia.Exception.Exceptions
{
    public class UsernameTakenException : BaseCustomException
    {
        public UsernameTakenException() : base("Username taken", "The username provided is already in use", (int)HttpStatusCode.BadRequest)
        {
        }
    }
}