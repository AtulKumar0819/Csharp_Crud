using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBookingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Dto;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController :  Controller
    {
       private readonly ApiContext _context;

        public StudentController(ApiContext context)
        {
            _context = context;
        }
// [HttpPost]
//         // Create/Edit
//         public JsonResult CreateEdit(Student Student)
//         {
//             if(Student.Id == 0)
//             {
//                 _context.Students.Add(Student);
//             } else
//             {
//                 var StudentInDb = _context.Students.Find(Student.Id);

//                 if (StudentInDb == null)
//                     return new JsonResult(NotFound());

//                 StudentInDb = Student;
//             }
//             _context.SaveChanges();

//             return new JsonResult(Ok(Student));

//         }

//            [HttpGet]
//         public string GetString()
//         {
//            return "successfull" ;
//         }

//         // Get
//         [HttpGet]
//         public JsonResult Get(int id)
//         {
//             var result = _context.Students.Find(id);

//             if (result == null)
//                 return new JsonResult(NotFound());

//             return new JsonResult(Ok(result));
//         }

//         // Delete
//         [HttpDelete]
//         public JsonResult Delete(int id)
//         {
//             var result = _context.Students.Find(id);

//             if (result == null)
//                 return new JsonResult(NotFound());

//             _context.Students.Remove(result);
//             _context.SaveChanges();

//             return new JsonResult(NoContent());
//         }

//         // Get all
//         [HttpGet()]
//         public JsonResult GetAll()
//         {
//             var result = _context.Students;

//             return new JsonResult(Ok(result));
//         } 
         [HttpPost]
        public String CreateStudentWithAddresses(StudentWithAddressesDto studentDto)
        {

            if (!ModelState.IsValid)
            {
                return "successfull";
            }

            ICollection<StudentAddress> StudentAddress = null;

            var student = new Student
            {
                StudentName = studentDto.StudentName,
                Addresses = StudentAddress
            }; 

            _context.Students.Add(student);
            _context.SaveChanges();

            // Create address entities
            foreach (var addressDto in studentDto.Addresses)
            {

                var address = new StudentAddress
                {
                    StudentId = student.Id,
                    Street = addressDto.Street,
                    City = addressDto.City,
                    State = addressDto.State,
                    Country = addressDto.Country
                };

                _context.StudentAddresses.Add(address);
            }

            _context.SaveChanges();

            return "successfull";
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentWithAddresses(int id)
        {
            var studentWithAddresses = _context.Students
                .Include(s => s.Addresses) 
                .FirstOrDefault(s => s.Id == id);

            if (studentWithAddresses == null)
            {
                return NotFound();
            }

            var studentDto = new StudentWithAddressesDto
            {
                StudentName = studentWithAddresses.StudentName,
                Addresses = studentWithAddresses.Addresses.Select(a => new AddressDto
                {
                    Street = a.Street,
                    City = a.City,
                    State = a.State,
                    Country = a.Country
                }).ToList()
            };

            return Ok(studentDto);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students
                .Include(s => s.Addresses)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);

            _context.StudentAddresses.RemoveRange(student.Addresses);

            _context.SaveChanges();

            return Ok("Student and associated addresses deleted successfully.");
        }
    }
    }
