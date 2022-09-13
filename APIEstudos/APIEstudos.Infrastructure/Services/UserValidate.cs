using APIEstudos.Domain.Services;

namespace APIEstudos.Infrastructure.Services
{
    public class UserValidate : IUserValidate
    {
        /// <summary>
        /// Method for validated if name and email is null, and if email contains caracters required
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="email">Email of the user</param>
        /// <returns>true or exception message</returns>
        public bool UserIsValid(string name, string email)
        {
            if(!email.Contains("@") && !email.Contains(".com"))
            {
                throw new Exception("Invalid email address provided");
            }
            
            if(string.IsNullOrEmpty(name))
            {
                throw new Exception("Name must not be empty.");
            }
            
            return true;
        }
    }
}