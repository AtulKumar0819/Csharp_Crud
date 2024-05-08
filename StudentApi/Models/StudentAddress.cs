using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.Models
{
    public class StudentAddress
    {
        
    [Key]
    public int Id { get; set; }

    [Required]
    public string Street { get; set; }

    [Required]
    public string City { get; set; }

    public string State { get; set; }

    [Required]
    public string Country { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }
}
    
}