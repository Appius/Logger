using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Logger.App_GlobalResources;

namespace Logger.ViewModels
{
    public class RegisterModel
    {
        [EmailAddress(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "EmailIsInvalid",
            ErrorMessage = null)]
        [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "EmailIsRequired")]
        [Display(ResourceType = typeof (Resources), Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NoPass")]
        [Category("Security")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,18}$",
            ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NoValidPass")]
        [PasswordPropertyText(true)]
        [Display(ResourceType = typeof(Resources), Name = "Pass")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NoConfirmPass")]
        [Category("Security")]
        [PasswordPropertyText(true)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "ConfirmPassAndPassDonotMatch")]
        //TODO: why don't work?
        //http://20fingers2brains.blogspot.com/2013/03/compare-data-annotation-attribute-in.html
        [Display(ResourceType = typeof(Resources), Name = "ConfirmPass")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "PleaseEnterYourName")]
        [Display(ResourceType = typeof (Resources), Name = "FirstName")]
        [StringLength(100, ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "RequirementPass",
            MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "PleaseEnterYourLastName")]
        [Display(ResourceType = typeof (Resources), Name = "LastName")]
        [StringLength(100, ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "RequirementPass",
            MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "BirthdayIsRequired")]
        [Display(ResourceType = typeof (Resources), Name = "Birthday")]
        [RegularExpression(@"^(3[01]|[12][0-9]|0?[1-9])\.(1[0-2]|0?[1-9])\.(?:[0-9]{2})?[0-9]{2}$",
            ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "BirthdayFormatInvalid")]
        public string Birthday { get; set; }
    }
}