using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentApi.Models
{
    public class Student
    {
    [Key]
    public int Id { get; set; }

    [Required]
    public string StudentName { get; set; }

 public ICollection<StudentAddress> Addresses { get; set; }



    }
}