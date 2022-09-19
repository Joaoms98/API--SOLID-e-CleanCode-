namespace APIEstudos.Core.Exceptions
{

[Serializable]
    public class UserExistsException : Exception
    {
        public UserExistsException() : base() { }
        public UserExistsException(string message) : base(message) { }
    }
}