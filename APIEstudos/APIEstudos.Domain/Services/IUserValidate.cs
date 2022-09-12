namespace APIEstudos.Domain.Services
{
    public interface IUserValidate
    {
        public bool UserIsValid(string name, string email);
    }
}