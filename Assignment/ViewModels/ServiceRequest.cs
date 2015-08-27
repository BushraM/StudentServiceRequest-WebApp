using Assignment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.ViewModels
{

    public class ServiceRequestList
    {

        public int Id { get; set; }

        public Student student { get; set; }

        public Program program { get; set; }

        [Display(Name = "Student Number")]
        public string studentNumber { get; set; }

        [Display(Name = "Student First Name")]
        public string studentName { get; set; }

        [Display(Name = "Student Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Program")]
        public string programCode { get; set; }

        [Display(Name = "Date Logged")]
        public DateTime dateLogged { get; set; }

        [Display(Name = "Status")]
        public string status { get; set; }

        [Display(Name = "Priority")]
        public string priority { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }


    }

    public class ServiceRequestAddForm
    {
        [Required]
        [StringLength(9)] 
        [Display(Name = "Student Number")]
        public string studentNumber { get; set; }

        [Required]
        [Display(Name = "Program")]
        public SelectList program { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string ServiceTitle { get; set; }
        
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public SelectList category { get; set; }

    }

    public class AddServiceRequest
    {
        [Required]
        //[StringLength(9, ErrorMessage="Student Number must be 9 length long")]
        [Display(Name = "Student Number")]
        public string studentNumber { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string ServiceTitle { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Program Code")]
        public string ProgramCode { get; set; }

        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        
        [Required]
        [Display(Name = "Program Id")]
        public int ProgramId { get; set; }
        
       
        [Required]
        [Display(Name = "Student Id")]
        public int StudentId { get; set; }

        [AllowHtml]
        public string notes { get; set; }

        public string priority { get; set; }

        [Display(Name = "date logged")]
        public DateTime dateLogged { get; set; }
        
        [Display(Name = "date updated")]
        public DateTime dateUpdated { get; set; }
        
        public string status { get; set; }

       public AddServiceRequest()
        {
             notes = "";
             priority = "Low";
             status = "Open";
             ServiceTitle = "";
             studentNumber = "";
             description  = "";
        }

    }

    public class ServiceRequestBase : AddServiceRequest
    {
        [Display(Name = "Service Request Id")]
        public int Id { get; set; }

    }

    public class EditServiceRequest : ServiceRequestAddForm
    {
        [Required]
        [Display(Name = "Status")]
        public SelectList status { get; set; }


        [Required]
        [Display(Name = "Note")]
        public string notes { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public SelectList priority { get; set; }

        [Display(Name = "Program Code")]
        public string ProgramCode { get; set; }

        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

    }

    public class ServiceRequestReportForm
    {
        [Display(Name = "Logged From")]
        public DateTime fromDate { get; set; }

        [Display(Name = "To")]
        public DateTime toDate { get; set; }
    }
  
}