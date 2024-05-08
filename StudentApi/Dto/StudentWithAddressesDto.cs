using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.Dto
{
    public class StudentWithAddressesDto
    {
        public int Id { get; set; }
         public string StudentName { get; set; }
    public List<AddressDto> Addresses { get; set; }  
    }
}