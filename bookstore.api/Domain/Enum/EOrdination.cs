using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

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
