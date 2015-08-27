using Assignment.Models;
using Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class StudentController : Controller
    {
        private StudentManager m = new StudentManager();
        //
        // GET: /Student/

        [Authorize (Roles = "Admin, Coordinator")]
        public ActionResult Index()
        {
            return View(m.getAllStudents());
        }

        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Create(AddStudent newItem)
        {
            if (ModelState.IsValid)
            {
                m.createStudent(newItem);
                return RedirectToAction("index");
            }
            else
            {
                return View(newItem);
            }
        }


        // GET: /Student/Details/5
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Details(int id)
        {
            var fetchedObject = m.getStudentById(id);

            if (fetchedObject == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(fetchedObject);
            }
        }

        // GET: /Student/Delete/5
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Delete(int? id)
        {
            studentBase itemToDelete = m.getStudentById(id.GetValueOrDefault());

            if (itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: /Student/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Delete(int id)
        {
            // Attempt to delete the item
            if (m.DeleteStudentById(id))
            {
                // Succesful - item was deleted
                TempData["statusMessage"] = "*Student was deleted.";
            }
            else
            {
                // Request was not successful
                TempData["statusMessage"] = "Unable to delete student.";
            }
            return RedirectToAction("details", new { id = id });
        }

        // GET: /Student/Edit/5
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Edit(int id)
        {
            studentBase fetchedObject = m.getStudentById(id);

            if (fetchedObject == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(fetchedObject);
            }
        }



        // POST: /Student/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Edit(int id, studentBase newItem)
        {
            if (ModelState.IsValid & id == newItem.Id)
            {
                studentBase editedItem = m.EditStudent(newItem);

                if (editedItem == null)
                {
                    // There was a problem updating the object
                    return View(newItem);
                }
                else
                {
                    // Succesful - item was edited
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
        

	}
}