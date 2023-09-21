using Microsoft.AspNetCore.Identity;

namespace NetCore5Api.Data
{
    public class ApplicationUser : IdentityUser

    {
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;

    }
}
