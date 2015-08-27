using Assignment.Models;
using Assignment.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Assignment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Data store initializer
            System.Data.Entity.Database.SetInitializer(new Models.StoreInitializer());

            //ViewModel to Model
            Mapper.CreateMap<AddStudent, Student>();
            Mapper.CreateMap<AddProgram, Program>();
            Mapper.CreateMap<AddServiceRequest, ServiceRequest>();
            //Mapper.CreateMap<ServiceRequestEdit, ServiceRequest>();
            Mapper.CreateMap<ServiceRequestBase, EditServiceRequest>();

            //Model to ViewModel
            Mapper.CreateMap<Student, StudentList>();
            Mapper.CreateMap<Program, ProgramList>();
            Mapper.CreateMap<Program, ProgramBase>();
            Mapper.CreateMap<ServiceRequest, AddServiceRequest>();
            Mapper.CreateMap<ServiceRequest, ServiceRequestList>();//*
            Mapper.CreateMap<ServiceRequest, ServiceRequestBase>();
            //Mapper.CreateMap<ServiceRequest, ServiceRequestDetail>();
            //Mapper.CreateMap<ServiceRequest, ServiceRequestEdit>();
            Mapper.CreateMap<Program, ProgramBase>();
            Mapper.CreateMap<Student, studentBase>();

            //ViewModel to ViewModel
            Mapper.CreateMap<AddServiceRequest, ServiceRequestAddForm>();
            Mapper.CreateMap<ServiceRequestAddForm, AddServiceRequest>();


        }

    }
}
