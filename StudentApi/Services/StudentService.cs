using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBookingAPI.Data;
using StudentApi.Dto;
using System.Collections.Generic;
using System.Linq;
using HotelBookingAPI.Data;
using StudentApi.Dto;
using StudentApi.Models;
using HotelBookingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Dto;
using StudentApi.Models;

namespace StudentApi.Services
{
         public class StudentService : IStudentService
    {
        private readonly ApiContext _context;

        public StudentService(ApiContext context)
        {
            _context = context;
        }

        public string CreateStudentWithAddresses(StudentWithAddressesDto studentDto)
        {
            var student = new Student
            {
                StudentName = studentDto.StudentName
            };

            _context.Students.Add(student);
            _context.SaveChanges();

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

            return "Student created successfully";
        }

        public StudentWithAddressesDto GetStudentWithAddresses(int id)
        {
            var studentWithAddresses = _context.Students
                .Include(s => s.Addresses)
                .FirstOrDefault(s => s.Id == id);

            if (studentWithAddresses == null)
            {
                return null;
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

            return studentDto;
        }

        public string DeleteStudent(int id)
        {
            var student = _context.Students
                .Include(s => s.Addresses)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return "Student not found";
            }

            _context.Students.Remove(student);
            _context.StudentAddresses.RemoveRange(student.Addresses);
            _context.SaveChanges();

            return "Student and associated addresses deleted successfully";
        }
    }}

