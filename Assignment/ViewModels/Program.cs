using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.ViewModels
{
    public class AddProgram
    {
        [Required]
        [Display(Name = "Program Code")]
        public string programCode { get; set; }

        [Required]
        [Display(Name = "Program Description")]
        public string programDescription { get; set; }
    }

    public class ProgramList
    {
        
        public int Id { get; set; }

        [Display(Name = "Program Code")]
        public string programCode { get; set; }

        [Display(Name = "Program Description")]
        public string programDescription { get; set; }
    }

    public class ProgramBase : AddProgram
    {
        public int Id { get; set; }

    }

    


}