using Assignment.Models;
using Assignment.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Controllers
{
    public class StudentManager
    {
        //reference to the data context
        private DataContext ds = new DataContext();
        
        //Creating student
        public Student createStudent(AddStudent newItem)
        {
            Student student = Mapper.Map<Student>(newItem);

            ds.Student.Add(student);
            ds.SaveChanges();

            return student;
        }

        public int getStudentByStudentNumber(string studentNumber)
        {

            return ds.Student.Where(i => i.studentNumber == studentNumber).Count();

        }

        public studentBase getStudentById(int Id)
        {
            var fetchedObject = ds.Student.Find(Id);

            if (fetchedObject == null)
            {
                return null;
            }
            else
            {
                return Mapper.Map<studentBase>(fetchedObject);
            }
        }

        //gets all the students in the data store
        public IEnumerable<StudentList> getAllStudents()
        {
            var fetchedObjects = ds.Student.ToList();
            return Mapper.Map<IEnumerable<StudentList>>(fetchedObjects);
        }


        public bool DeleteStudentById(int id)
        {
            // Attempt to fetch the object
            var fetchedObject = ds.Student.Find(id);

            if (fetchedObject == null)
            {
                return false;
            }
            else
            {
                ds.Student.Remove(fetchedObject);
                ds.SaveChanges();

                return true;
            }
        }


        public studentBase EditStudent(studentBase newItem)
        {
            var fetchedObject = ds.Student.Find(newItem.Id);

            if (fetchedObject == null)
            {
                return null;
            }
            else
            { 
                ds.Entry(fetchedObject).CurrentValues.SetValues(newItem);
                ds.SaveChanges();

                return Mapper.Map<studentBase>(fetchedObject);
            }
        }

    }
}