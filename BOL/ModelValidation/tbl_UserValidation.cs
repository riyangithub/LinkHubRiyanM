using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [MetadataType(typeof(tbl_UserValidation))]
    public partial class tbl_User{        
        public string ConfirmPassword { get; set; }
    }
    public class tbl_UserValidation
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    public class UniqueUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LinkHubDbEntities db = new LinkHubDbEntities();
            string urlValue = value.ToString();
            int count = db.tbl_Url.Where(x => x.Url == urlValue).ToList().Count();
            if (count != 0)
            {
                return new ValidationResult("User Alreay Exist");
            }
            else
            {
                return ValidationResult.Success;
            }

        }
    }
}
