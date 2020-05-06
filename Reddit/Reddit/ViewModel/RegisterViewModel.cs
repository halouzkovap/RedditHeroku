using System.ComponentModel.DataAnnotations;

namespace Reddit.ViewModel
{
    public class RegisterViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; } = "User";
    }
}
