namespace Blogs_Api_DotNet.Exceptions
{
    public class DuplicatedUserException : Exception
    {
        public DuplicatedUserException(string message) : base(message)
        {

        }
    }
}
