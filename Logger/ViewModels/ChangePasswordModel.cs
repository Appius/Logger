using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Logger.App_GlobalResources;

namespace Logger.ViewModels
{
    public class ChangePasswordModel
    {
        /// <summary>
        ///     Старый пароль
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NoPass")]
        [Category("Security")]
        [DataType(DataType.Password)]
        [PasswordPropertyText(true)]
        [Display(ResourceType = typeof(Resources), Name = "CurrentPass")]
        public string OldPassword { get; set; }

        /// <summary>
        ///     Новый пароль
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NoPass")]
        [Category("Security")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,18}$",
            ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NoValidPass")]
        [PasswordPropertyText(true)]
        [Display(ResourceType = typeof(Resources), Name = "NewPass")]
        public string NewPassword { get; set; }

        /// <summary>
        ///     Подтверждение пароля
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NoConfirmPass")]
        [Category("Security")]
        [PasswordPropertyText(true)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "NewPassAndConfirmDontMatch")]
        [Display(ResourceType = typeof(Resources), Name = "ConfirmPass")]
        public string ConfirmPassword { get; set; }
    }
}