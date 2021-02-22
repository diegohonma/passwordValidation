using passwordValidation.Interfaces.Services;
using System.Linq;

namespace passwordValidation.Services
{
    public class MinimumRepeatCharsValidationService : IPasswordValidationService
    {
        public bool IsValid(string password) => !password.ToCharArray().GroupBy(it => it).Any(it => it.Count() > 1);
    }
}
