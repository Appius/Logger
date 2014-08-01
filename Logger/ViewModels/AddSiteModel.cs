using System;
using System.ComponentModel.DataAnnotations;
using Logger.App_GlobalResources;

namespace Logger.ViewModels
{
    public class AddSiteModel
    {
        [Required]
        [Display(ResourceType = typeof (Resources), Name = "SiteName")]
        [StringLength(100, ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "RequirementPass",
            MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(ResourceType = typeof (Resources), Name = "SiteUrl")]
        public string Url { get; set; }

        [Display(ResourceType = typeof (Resources), Name = "Description")]
        [StringLength(1024, ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "RequirementDesc")
        ]
        public string Description { get; set; }
    }
}