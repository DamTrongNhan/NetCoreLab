using Microsoft.AspNetCore.Identity;
using NetCore5Api.Models;

namespace NetCore5Api.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
