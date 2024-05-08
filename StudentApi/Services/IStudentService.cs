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
    public interface IStudentService
    {
        string CreateStudentWithAddresses(StudentWithAddressesDto studentDto);

        StudentWithAddressesDto GetStudentWithAddresses(int id);
        
        string DeleteStudent(int id);
    }

}
