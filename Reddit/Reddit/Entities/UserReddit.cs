using Microsoft.AspNetCore.Identity;

namespace Reddit.Entities
{
    public class UserReddit : IdentityUser
    {
        public string Name { get; set; }
    }
}
