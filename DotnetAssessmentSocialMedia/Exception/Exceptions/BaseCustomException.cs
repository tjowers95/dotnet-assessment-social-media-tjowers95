namespace DotnetAssessmentSocialMedia.Exception.Exceptions
{
    public class BaseCustomException : System.Exception
    {
        public int Code { get; }

        public string Description { get; }

        public BaseCustomException(string message, string description, int code) : base(message)
        {
            Description = description;
            Code = code;
        }
    }
}