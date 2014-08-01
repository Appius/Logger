using System.ComponentModel.DataAnnotations;
using Logger.App_GlobalResources;

namespace Logger.ViewModels
{
    public class LoginModel
    {
        [Required]
        [Display(ResourceType = typeof (Resources), Name = "EmailAddress")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof (Resources), Name = "Pass")]
        public string Password { get; set; }

        [Display(ResourceType = typeof (Resources), Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }
}