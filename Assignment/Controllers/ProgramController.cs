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
    public class ProgramController : Controller
    {
        ProgramManager m = new ProgramManager();
        
        //
        // GET: /Program/
        
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Index()
        {
            return View(m.getAllPrograms());
        }


        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Create(AddProgram newItem)
        {
            if (ModelState.IsValid)
            {
                m.createProgram(newItem);
                return RedirectToAction("index");
            }
            else
            {
                return View(newItem);
            }
        }

        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Details(int id)
        {
            var fetchedObject = m.GetProgramById(id);

            if (fetchedObject == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(fetchedObject);
            }
        }


        // GET: /Program/Delete/5
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Delete(int? id)
        {
            ProgramBase itemToDelete = m.GetProgramById(id.GetValueOrDefault());

            if (itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

         
        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Delete(int id)
        {
            // Attempt to delete the item
            if (m.DeleteProgramById(id))
            {
                // Succesful - item was deleted
                TempData["statusMessage"] = "*Program was deleted.";
            }
            else
            {
                // Request was not successful
                TempData["statusMessage"] = "Unable to delete program.";
            }
            return RedirectToAction("details", new { id = id });
        }


        // GET: /Program/Edit/5
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Edit(int id)
        {
            ProgramBase fetchedObject = m.GetProgramById(id);

            if (fetchedObject == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(fetchedObject);
            }
        }


        // POST: /Program/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Edit(int id, ProgramBase newItem)
        {
            if (ModelState.IsValid & id == newItem.Id)
            {
                // Attempt to update the item
                ProgramBase editedItem = m.EditProgram(newItem);

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


	}
}