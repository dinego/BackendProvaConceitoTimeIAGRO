using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enum
{
    public enum EOrdination
    {
        [Display(Name = "ASC")]
        [Description("ASC")]
        ASC = 1,
        [Display(Name = "DESC")]
        [Description("DESC")]
        DESC = 2
    }
}
