using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.ViewModels
{
    public class StudentList
    {
        public int Id { get; set; }

        [Display(Name = "Student Number")]
        public string studentNumber { get; set; }

        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "user name")]
        public string username { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }
    }

    public class AddStudent
    {
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "user name")]
        public string username { get; set; }

        [Required]
        [Display(Name = "Student Number")]
        [StringLength(9, ErrorMessage = "{0} is {1} digits long")] 
        public string studentNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
    }

    public class studentBase : AddStudent
    {
        public int Id { set; get; }
    }


}