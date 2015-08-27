using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string studentNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
      
    }

    public class Program
    {
        public int Id { get; set; }

        [Display(Name = "Program Code")]
        public string programCode { get; set; }

        [Display(Name = "Program Description")]
        public string programDescription { get; set; }
    }

    public class ServiceRequest
    {
        public ServiceRequest()
        {
            this.priority = "Low";
            this.status = "Open";
            this.notes = "";
            description = " ";
        }

       public int Id { get; set; }
       public Student student { get; set; }
       public Program program { get; set; }
       public string Title { get; set; }
       public string description { get; set; }
       public string category { get; set; }
       public string notes { get; set; }
       public string priority { get; set; }
       public DateTime dateLogged { get; set; }
       public DateTime dateUpdated { get; set; }
       public string status { get; set; }
    }

}