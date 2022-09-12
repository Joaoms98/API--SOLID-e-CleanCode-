using APIEstudos.Domain.Services;

namespace APIEstudos.Infrastructure.Services
{
    public class UserValidate : IUserValidate
    {
        public bool UserIsValid(string name, string email)
        {
            if(email.Contains("@") && email.Contains(".com"))
            {
                if(!string.IsNullOrEmpty(name))
                {
                    return true;
                }

                throw new Exception("Name must not be empty.");
            }
            else
            {
                throw new Exception("Invalid email address provided");
            }
        }
    }
}