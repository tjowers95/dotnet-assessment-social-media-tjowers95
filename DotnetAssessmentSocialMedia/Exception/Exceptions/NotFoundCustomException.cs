using System.Net;

namespace DotnetAssessmentSocialMedia.Exception.Exceptions
{
    public class NotFoundCustomException : BaseCustomException
    {
        public NotFoundCustomException(string message, string description) : base(message, description, (int)HttpStatusCode.NotFound)
        {
        }

    }
}