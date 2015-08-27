using Assignment.Models;
using Assignment.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class ServiceRequestController : Controller
    {
        private ServiceRequestManager m = new ServiceRequestManager();
       
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Index()
        {
            return View(m.getAllServiceRequests());
        }

        public ActionResult confirm()
        {
            return View();
        }

        public ActionResult Create()
        { 
            ProgramManager pm = new ProgramManager();
            var addForm = new ServiceRequestAddForm();
            
            addForm.program = new SelectList(pm.getAllPrograms(), "Id", "programCode");

            return View(addForm);
        }


        [HttpPost]
        public ActionResult Create(AddServiceRequest newItem)
        {
            var sr = new ServiceRequestBase();
            ProgramManager pm = new ProgramManager();
            StudentManager sm = new StudentManager();

            if (ModelState.IsValid)
            {
                //Student Number does not exisit in the database
                if ( sm.getStudentByStudentNumber(newItem.studentNumber) == 0)
                {
                    ViewBag.StudentInvalidErrorMessage = "*Student Number does not exisit in the system";

                    var addForm = Mapper.Map<ServiceRequestAddForm>(newItem);
                    addForm.program = new SelectList(pm.getAllPrograms(), "Id", "programCode");
                    
                    return View(addForm);
                }


                var addetItem = m.AddNewServiceRequest(newItem);

                if (addetItem == null)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    return RedirectToAction("confirm");
                }
            }
            else
            {
                var addForm = Mapper.Map<ServiceRequestAddForm>(newItem);
                addForm.program = new SelectList(pm.getAllPrograms(), "Id", "programCode");
                

                return View(addForm);
            }
        }


        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Details(int Id)
        {
            return View(m.GetServiceRequestById(Id));
        }

        
        // GET: /ServiceRequest/Edit/5
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Edit(int id)
        {
            ServiceRequestBase fetchedObject = m.GetServiceRequestById(id);
            ProgramManager pm = new ProgramManager();


            if (fetchedObject == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                EditServiceRequest editObject = new EditServiceRequest();

                editObject.description = fetchedObject.description;
                editObject.notes = fetchedObject.notes;
                editObject.ServiceTitle = fetchedObject.ServiceTitle;
                editObject.studentNumber = fetchedObject.studentNumber;
                editObject.ProgramCode = fetchedObject.ProgramCode;
                editObject.StudentName = fetchedObject.StudentName;
                
                return View(editObject);
            }
        }

        // POST: /ServiceRequest/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Edit(int id, ServiceRequestBase newItem)
        {
            if (ModelState.IsValid & id == newItem.Id)
            {
                // Attempt to update the item
                ServiceRequestBase editedItem = m.EditServiceRequest(newItem);

                if (editedItem == null)
                {
                    // There was a problem updating the object
                    return View(newItem);
                }
                else
                {
                    //item was edited
                    TempData["statusMessage"] = "Edits have been saved.";
                    return RedirectToAction("details", new { id = editedItem.Id });
                }
            }
            else
            {
                // Return the object so the user can edit it correctly
                return View(newItem);
            }
        }

        //GET: ?ServiceRequest/Delete/5
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Delete(int? id)
        {
           
             ServiceRequestBase itemToDelete = m.GetServiceRequestById(id.GetValueOrDefault());
             
            if (itemToDelete == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(itemToDelete);
            }
        }


        // POST: /ServiceRequest/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Delete(int id)
        {
            // Attempt to delete the item
            if (m.DeleteServiceRequestById(id))
            {
                // Succesful - item was deleted
                TempData["statusMessage"] = "*Service Request was deleted.";
            }
            else
            {
                // Request was not successful
                TempData["statusMessage"] = "Unable to delete Service Request.";
            }
            return RedirectToAction("index");
        }


        /* -----------------------------------------------------------------
         * 
         *          SEARCH REPORTS 
         * 
         *------------------------------------------------------------------*/

        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Report()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult StudentNumberReport(String studentNumber)
        {
            
            var serviceRequest = m.getServiceRequestByStudentNumber(studentNumber);

            if (serviceRequest != null)
            {
                return View(serviceRequest);
            }
            else
            {
                //did not find service request
                TempData["statusMessage"] = "Can not find Service Request with the student number "+studentNumber;
                return RedirectToAction("Report");
            }
       }
       
        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult ProgramReport(String programCode)
        {
            
            var serviceRequest = m.getServiceRequestByProgramCode(programCode);

            if (serviceRequest != null)
            {
                return View(serviceRequest);
            }
            else
            {
                //did not find service request
                TempData["statusMessage"] = "Can not find Service Request with the program code: "+programCode;
                return RedirectToAction("Report");
            }
       }

        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult StatusReport(String status)
        {
            var serviceRequest = m.getServiceRequestByStatus(status);

            if (serviceRequest != null)
            {
                return View(serviceRequest);
            }
            else
            {
                //did not find service request
                TempData["statusMessage"] = "Can not find Service Request with the status: " + status;
                return RedirectToAction("Report");
            }
        }

        //Used with the date picker
        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult DateReport(ServiceRequestReportForm values)
        {

            var serviceRequest = m.getServiceRequestByDate(values.fromDate, values.toDate);

            if (serviceRequest != null)
            {
                return View(serviceRequest);
            }
            else
            {
                return RedirectToAction("Report");
            }
        }
    }

}


