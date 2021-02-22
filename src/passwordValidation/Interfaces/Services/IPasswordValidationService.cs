namespace passwordValidation.Interfaces.Services
{
    public interface IPasswordValidationService
    {
        bool IsValid(string password);
    }
}
