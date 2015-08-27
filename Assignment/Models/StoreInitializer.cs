using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class StoreInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
     
           // Add initial objects to the store
           var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
           var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

           //Create Role Admin if it does not exist 
            
           if (!RoleManager.RoleExists("Admin"))
           {
               var roleresult = RoleManager.Create(new IdentityRole("Admin"));
           }
           
            //Create User=Admin with password=123456
            var user = new ApplicationUser();
            user.UserName = "Admin";
            var adminresult = UserManager.Create(user, "123456");

            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, "Admin");
            }


            

            //Creating coordinator role & coordinator users

            if (!RoleManager.RoleExists("Coordinator"))
            {
                var roleresult2 = RoleManager.Create(new IdentityRole("Coordinator"));
            }



            //************************************//
            //creating coordinator user
            var user2 = new ApplicationUser();
            user2.UserName = "IanTipson";
            var Cordresult2 = UserManager.Create(user2, "password1");

            //Add User Admin to Role Admin
            if (Cordresult2.Succeeded)
            {
                var result = UserManager.AddToRole(user2.Id, "Coordinator");
            }
            //**********************************//



            //************************************//
            //creating coordinator user
            var user3 = new ApplicationUser();
            user3.UserName = "ScottApted";
            var Cordresult3 = UserManager.Create(user3, "password2");

            //Add User Admin to Role Admin
            if (Cordresult3.Succeeded)
            {
                var result = UserManager.AddToRole(user3.Id, "Coordinator");
            }
            //**********************************//



            //************************************//
            //creating coordinator user
            var user4 = new ApplicationUser();
            user4.UserName = "PatHarper";
            var Cordresult4 = UserManager.Create(user4, "password3");

            //Add User Admin to Role Admin
            if (Cordresult4.Succeeded)
            {
                var result = UserManager.AddToRole(user4.Id, "Coordinator");
            }
            //**********************************//



            //************************************//
            //creating coordinator user
            var user5 = new ApplicationUser();
            user5.UserName = "TimMcKenna";
            var Cordresult5 = UserManager.Create(user5, "password5");

            //Add User Admin to Role Admin
            if (Cordresult5.Succeeded)
            {
                var result = UserManager.AddToRole(user5.Id, "Coordinator");
            }
            //**********************************//



            //************************************//
            //creating coordinator user
            var user6 = new ApplicationUser();
            user6.UserName = "PeterMcIntyre";
            var Cordresult6 = UserManager.Create(user6, "password6");

            //Add User Admin to Role Admin
            if (Cordresult6.Succeeded)
            {
                var result = UserManager.AddToRole(user6.Id, "Coordinator");
            }
            //**********************************//



            //Initializing students
            Student student1 = new Student()
            {
                firstName = "James",
                lastName = "Jones",
                studentNumber = "017622234",
                email = "JJ@myseneca.ca",
                username = "JJ"
            };
            context.Student.Add(student1);

            Student student2 = new Student()
            {
                firstName = "Robert",
                lastName = "Hughes",
                studentNumber = "141455324",
                email = "RH1@myseneca.ca",
                username = "RH1"
            };
            context.Student.Add(student2);

            Student student3 = new Student()
            {
                firstName = "Michael",
                lastName = "Pham",
                studentNumber = "121545366",
                email = "MP@myseneca.ca",
                username = "MP"
            };
            context.Student.Add(student3);

            Student student4 = new Student()
            {
                firstName = "Shannon",
                lastName = "Butler",
                studentNumber = "484321123",
                email = "SB@myseneca.ca",
                username = "SB"
            };
            context.Student.Add(student4);

            Student student5 = new Student()
            {
                firstName = "Brandon",
                lastName = "Cook",
                studentNumber = "325654549",
                email = "BC@myseneca.ca",
                username = "BC"
            };
            context.Student.Add(student5);

            Student student6 = new Student()
            {
                firstName = "Bushra",
                lastName = "Mohamed",
                studentNumber = "018633123",
                email = "bomohamed@myseneca.ca",
                username = "bomohamed@myseneca.ca"
            };
            context.Student.Add(student6);

            context.SaveChanges();

            //Initializing Program

            Program program1 = new Program()
            {
                programCode = "CPA",
                programDescription = "3-Year Computer Programming And Analysis advanced diploma"
            };
            context.Program.Add(program1);

            Program program2 = new Program()
            {
                programCode = "CPD",
                programDescription = "2-Year Computer Programming Diploma"
            };
            context.Program.Add(program2);

            Program program3 = new Program()
            {
                programCode = "CNS",
                programDescription = "2-Year Computer Networking and Technical Support Diploma"
            };
            context.Program.Add(program3);

            Program program4 = new Program()
            {
                programCode = "CTY",
                programDescription = "3-Year Computer Systems Technology advanced diploma"
            };
            context.Program.Add(program4);

            Program program5 = new Program()
            {
                programCode = "BSD",
                programDescription = "4-Year Bachelor of Technology (Software Development) Degree"
            };
            context.Program.Add(program5);

 
            context.SaveChanges();

            //Initializing Service Requests

            ServiceRequest serviceRequest1 = new ServiceRequest()
            {
                student = student1,
                //category
                //note
                notes = "Will not refund fees",
                category = "course related issue",
                dateLogged = new DateTime(2014, 9, 15).AddHours(3.5),
                dateUpdated = DateTime.Now,
                description = "Droping OOP345 course",
                program = program1,
                priority = "Low",
                status = "Open",
                Title = "Droping a course",
            };

            context.ServiceRequest.Add(serviceRequest1);

            ServiceRequest serviceRequest2 = new ServiceRequest()
            {
                student = student2,
                notes = "currently in 3rd semester",
                category = "program related issue",
                dateLogged = new DateTime(2014, 9, 6).AddHours(2.0),
                dateUpdated = DateTime.Now,
                description = "I want to switch into the CPA progrm from the CTY program. How many credits will I be able to transfer into the program?",
                program = program3,
                priority = "Medium",
                status = "Open",
                Title = "Switching programs",
            };

            context.ServiceRequest.Add(serviceRequest2);

            ServiceRequest serviceRequest3 = new ServiceRequest()
            {
                student = student6,
                notes = "Still needs 6 more credits",
                category = "program related issue",
                dateLogged = new DateTime(2014,6,7).AddHours(7.7),
                dateUpdated = DateTime.Now,
                description = "I want to switch into the CPA progrm from the CTY program. How many credits will I be able to transfer into the program?",
                program = program1,
                priority = "Medium",
                status = "close",
                Title = "Request to graduate",
            };

            context.ServiceRequest.Add(serviceRequest3);
            context.SaveChanges();
        }
    }
}