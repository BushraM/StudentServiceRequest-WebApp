using Assignment.Models;
using Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.Text.RegularExpressions;
using System.Data.Entity.Core.Objects;


namespace Assignment.Controllers
{
    public class ServiceRequestManager
    {
        private DataContext ds = new DataContext();
        
        public ServiceRequestBase AddNewServiceRequest(AddServiceRequest newItem)
        {
            var program = ds.Program.Find(newItem.ProgramId);
            var student = ds.Student.Where(i => i.studentNumber == newItem.studentNumber).SingleOrDefault();
            
            if (program != null && student != null)
            {

                var service = Mapper.Map<ServiceRequest>(newItem);
                //removes the html and other special tags and converts it to plain text
                service.description = removeHtmlTags(newItem.description);

                service.program = program;
                service.student = student;

                service.dateLogged = DateTime.Now;
                service.dateUpdated = DateTime.Now;
                service.Title = newItem.ServiceTitle;

                ds.ServiceRequest.Add(service);
                ds.SaveChanges();

                return Mapper.Map<ServiceRequestBase>(service);
            }
            else
            {
                return null;
            }
        }

        //Removes HTML and other tags created by the rich text editor
        private string removeHtmlTags(string htmlString)
        {
            string htmlTagPattern = "<.*?>";
            var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            htmlString = regexCss.Replace(htmlString, string.Empty);
            htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
            htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            htmlString = htmlString.Replace("&nbsp;", string.Empty);

            return htmlString;
        }
        public ServiceRequestBase EditServiceRequest(ServiceRequestBase newItem)
        {
            var fetchedObject = ds.ServiceRequest.Find(newItem.Id);

            if (fetchedObject == null)
            {
                return null;
            }
            else
            {
                DateTime dateCreateFromDatabase = fetchedObject.dateLogged;
                newItem.dateUpdated = DateTime.Now;
                newItem.dateLogged = dateCreateFromDatabase;
                ds.Entry(fetchedObject).CurrentValues.SetValues(newItem);
                ds.SaveChanges();

                // Prepare and return the object. The automapper will also map the datelogged property (which we don't want)
                ServiceRequestBase serviceRequestbase = Mapper.Map<ServiceRequestBase>(fetchedObject);

                //replace the dateLogged back to original
                serviceRequestbase.dateLogged = dateCreateFromDatabase;

                return serviceRequestbase;
            }
        }



        // Delete existing
        public bool DeleteServiceRequestById(int id)
        {
            // Attempt to fetch the object
            var fetchedObject = ds.ServiceRequest.Find(id);

            if (fetchedObject == null)
            {
                return false;
            }
            else
            {
                ds.ServiceRequest.Remove(fetchedObject);
                ds.SaveChanges();
                return true;
            }
        }

        //gets all Service Requests for a student using student number
        public IEnumerable<ServiceRequestList> getServiceRequestByStudentNumber(string studentNumber)
        {
            var fetchedObjects = ds.ServiceRequest.Include("Student").Include("Program").Where(Service => (Service.student.studentNumber == studentNumber)).AsEnumerable<ServiceRequest>();    
             return Mapper.Map<IEnumerable<ServiceRequestList>>(fetchedObjects);
        }

        //gets all Service Requests of all students in a specific program
        public IEnumerable<ServiceRequestList> getServiceRequestByProgramCode(string programCode)
        {
            var fetchedObjects = ds.ServiceRequest.Include("Student").Include("Program").Where(Service => (Service.program.programCode == programCode)).AsEnumerable<ServiceRequest>();
            return Mapper.Map<IEnumerable<ServiceRequestList>>(fetchedObjects);
        }

        public IEnumerable<ServiceRequestList> getServiceRequestByStatus(string status)
        {
            var fetchedObjects = ds.ServiceRequest.Include("Student").Include("Program").Where(Service => (Service.status == status)).AsEnumerable<ServiceRequest>();
            return Mapper.Map<IEnumerable<ServiceRequestList>>(fetchedObjects);
        }
        
        //gets all Service Requests of all students
        public IEnumerable<ServiceRequestList> getAllServiceRequests()
        {
            var fetchedObjects = ds.ServiceRequest.Include("Program").Include("Student").ToList();
            return Mapper.Map<IEnumerable<ServiceRequestList>>(fetchedObjects);
        }

        //gets all Service Requests of all students for a specific date range
        public IEnumerable<ServiceRequestList> getServiceRequestByDate(DateTime fromDate, DateTime toDate)
        {
            var fetchedObjects = ds.ServiceRequest.Include("Program").Include("Student").Where(Service => (Service.dateLogged >= fromDate && Service.dateLogged <= toDate));
            return Mapper.Map<IEnumerable<ServiceRequestList>>(fetchedObjects);
        }


        //gets all Service Requests for a student using username
        public IEnumerable<ServiceRequestBase> getServiceRequestByUserName(string username)
        {
            var fetchedObjects = ds.ServiceRequest.Where(Service => (Service.student.username == username));
            return Mapper.Map<IEnumerable<ServiceRequestBase>>(fetchedObjects);
        }



        public ServiceRequestBase GetServiceRequestById(int id)
        {
            var fetchedObject = ds.ServiceRequest.Include("Student").Include("Program").SingleOrDefault(i => i.Id == id);
            ServiceRequestBase s = new ServiceRequestBase();

            if (fetchedObject != null)
            {

                var serviceRequestBase = Mapper.Map<ServiceRequestBase>(fetchedObject);

                serviceRequestBase.studentNumber = fetchedObject.student.studentNumber;
                serviceRequestBase.ServiceTitle = fetchedObject.Title;
                serviceRequestBase.StudentName = fetchedObject.student.firstName + "," + fetchedObject.student.lastName;
                serviceRequestBase.ProgramCode = fetchedObject.program.programCode;
                serviceRequestBase.description = removeHtmlTags(fetchedObject.description);
                serviceRequestBase.notes = removeHtmlTags(fetchedObject.notes);

                return serviceRequestBase;
            }
            else
            {
                return null;
            }
        }

    }
}