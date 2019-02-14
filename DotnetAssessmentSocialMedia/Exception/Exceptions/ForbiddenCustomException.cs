using System.Net;

namespace DotnetAssessmentSocialMedia.Exception.Exceptions
{
    public class ForbiddenCustomException : BaseCustomException
    {
        public ForbiddenCustomException(string message, string description) : base(message, description, (int)HttpStatusCode.Forbidden)
        {
        }
    }
}